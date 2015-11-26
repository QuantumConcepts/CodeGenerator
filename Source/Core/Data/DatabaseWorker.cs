using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.CodeGenerator.Core.Utils;
using System.Linq;
using QuantumConcepts.Common.Extensions;
using QuantumConcepts.CodeGenerator.Core.Exceptions;
using System.Text.RegularExpressions;

namespace QuantumConcepts.CodeGenerator.Core.Data
{
    public abstract class DatabaseWorker
    {
        public abstract string Name { get; }
        public virtual IList<DatabaseParameter> Parameters { get { return null; } }

        protected abstract DataTable GetTables(Project project, Connection connection);
        protected abstract DataTable GetViews(Project project, Connection connection);
        protected abstract DataTable GetColumns(Project project, Connection connection);
        protected abstract DataTable GetForeignKeys(Project project, Connection connection);
        protected abstract DataTable GetUniqueIndices(Project project, Connection connection);

        protected virtual void ExtractTableInfo(DataRow dr, out string schemaName, out string name)
        {
            schemaName = dr.TryGetValue<string>(QueryConstants.TableOrView.SchemaName);
            name = dr.TryGetValue<string>(QueryConstants.TableOrView.Name);
        }

        protected virtual void ExtractViewInfo(DataRow dr, out string schemaName, out string name)
        {
            ExtractTableInfo(dr, out schemaName, out name);
        }

        protected virtual void ExtractColumnInfo(DataRow dr, out string forParent, out string name, out string schemaName, out string tableName, out decimal sequence, out string databaseDataType, out decimal length, out string defaultValue, out bool nullable, out bool primaryKey)
        {
            forParent = dr.TryGetValue<string>(QueryConstants.Column.For);
            name = dr.TryGetValue<string>(QueryConstants.Column.Name);
            schemaName = dr.TryGetValue<string>(QueryConstants.TableOrView.SchemaName);
            tableName = dr.TryGetValue<string>(QueryConstants.TableOrView.Name);
            sequence = dr.TryGetValue<decimal>(QueryConstants.Column.Sequence);
            databaseDataType = dr.TryGetValue<string>(QueryConstants.Column.DataType);
            length = dr.TryGetValue<decimal>(QueryConstants.Column.Length);
            defaultValue = dr.TryGetValue<string>(QueryConstants.Column.DefaultValue);
            nullable = dr.TryGetValue<bool>(QueryConstants.Column.Nullable);
            primaryKey = dr.TryGetValue<bool>(QueryConstants.Column.PrimaryKey);
        }

        protected virtual void ExtractForeignKeyInfo(DataRow dr, out string name, out string parentTableSchemaName, out string parentTableName, out string parentColumnName, out string referencedTableSchemaName, out string referencedTableName, out string referencedColumnName)
        {
            name = dr.TryGetValue<string>(QueryConstants.ForeignKey.Name);
            parentTableSchemaName = dr.TryGetValue<string>(QueryConstants.ForeignKey.ParentTableSchemaName);
            parentTableName = dr.TryGetValue<string>(QueryConstants.ForeignKey.ParentTableName);
            parentColumnName = dr.TryGetValue<string>(QueryConstants.ForeignKey.ParentColumnName);
            referencedTableSchemaName = dr.TryGetValue<string>(QueryConstants.ForeignKey.ReferencedTableSchemaName);
            referencedTableName = dr.TryGetValue<string>(QueryConstants.ForeignKey.ReferencedTableName);
            referencedColumnName = dr.TryGetValue<string>(QueryConstants.ForeignKey.ReferencedColumnName);
        }

        protected virtual void ExtractUniqueIndexInfo(DataRow dr, out string name, out string schemaName, out string tableName, out string columnName)
        {
            name = dr.TryGetValue<string>(QueryConstants.Index.Name);
            schemaName = dr.TryGetValue<string>(QueryConstants.TableOrView.SchemaName);
            tableName = dr.TryGetValue<string>(QueryConstants.TableOrView.Name);
            columnName = dr.TryGetValue<string>(QueryConstants.Column.Name);
        }

        public abstract void ValidateConnection(Connection connection);
        public abstract IEnumerable<DataTypeMappingConfiguration> GetDataTypeMappingConfigurations();

        public void Refresh(Project project, Connection connection)
        {
            List<string> tableErrors = new List<string>();
            List<string> viewErrors = new List<string>();
            List<string> columnErrors = new List<string>();
            List<string> fkErrors = new List<string>();
            List<string> uxErrors = new List<string>();
            Dictionary<string, List<string>> allErrors = null;

            RefreshTables(project, connection, ref tableErrors);
            RefreshViews(project, connection, ref viewErrors);
            RefreshColumns(project, connection, ref columnErrors);
            RefreshForeignKeys(project, connection, ref fkErrors);
            RefreshUniqueIndices(project, connection, ref uxErrors);

            allErrors = new Dictionary<string, List<string>>()
            {
                ["tables"] = tableErrors,
                ["views"] = viewErrors,
                ["columns"] = columnErrors,
                ["foreign keys"] = fkErrors,
                ["unique indices"] = uxErrors,
            };
            allErrors = allErrors.Where(o => o.Value.Count > 0).ToDictionary(o => o.Key, o => o.Value);

            if (allErrors.Any())
            {
                StringBuilder message = new StringBuilder();

                message.AppendLine("The following error(s) occurred while refreshing the database schema.");

                foreach (var item in allErrors)
                {
                    message.AppendLine();
                    message.AppendLine($"While refreshing {item.Key}...");

                    foreach (var error in item.Value)
                    {
                        string[] lines = Regex.Split(error, @"\r?\n");

                        foreach (var line in lines)
                            message.AppendLine($"    {line}");
                    }
                }

                throw new ApplicationException(message.ToString());
            }
        }

        private void RefreshTables(Project project, Connection connection, ref List<string> errors)
        {
            DataTable dataTable = GetTables(project, connection);
            var duplicates = FindDuplicates(dataTable, QueryConstants.TableOrView.SchemaName, QueryConstants.TableOrView.Name);

            if (duplicates.Any())
            {
                errors.Add(FormatDuplicates(duplicates));
                return;
            }

            //Add tables to the project
            foreach (DataRow dr in dataTable.Rows)
            {
                string schemaName;
                string name;
                TableMapping tm;

                ExtractTableInfo(dr, out schemaName, out name);
                tm = project.FindTableMapping(connection.Name, schemaName, name);

                if (tm == null)
                {
                    tm = new TableMapping(connection.Name, schemaName, name, name, null, null, null, null);
                    tm.JoinToProject(project);
                    project.TableMappings.Add(tm);
                }
                else if (!string.Equals(tm.SchemaName, schemaName))
                    tm.SchemaName = schemaName;
            }

            RemoveNonExistantTables(project, connection, dataTable);
        }

        private void RemoveNonExistantTables(Project project, Connection connection, DataTable dataTable)
        {
            List<TableMapping> toConsider = project.TableMappings.Where(o => string.Equals(o.ConnectionName, connection.Name)).ToList();
            List<TableMapping> toRemove = new List<TableMapping>();

            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[QueryConstants.TableOrView.SchemaName], dataTable.Columns[QueryConstants.TableOrView.Name] };

            foreach (TableMapping tm in toConsider)
            {
                DataRow match = dataTable.Rows.Find(new[] { tm.SchemaName, tm.TableName });

                //Find() is not case sensitive so ensure the case matches otherwise we could end up with duplicate items.
                if (match == null || (!match[QueryConstants.TableOrView.SchemaName].Equals(tm.SchemaName) && !match[QueryConstants.TableOrView.Name].Equals(tm.TableName)))
                    toRemove.Add(tm);
            }

            foreach (TableMapping tm in toRemove)
                project.TableMappings.Remove(tm);
        }

        private void RefreshViews(Project project, Connection connection, ref List<string> errors)
        {
            DataTable dataTable = GetViews(project, connection);
            var duplicates = FindDuplicates(dataTable, QueryConstants.TableOrView.SchemaName, QueryConstants.TableOrView.Name);

            if (duplicates.Any())
            {
                errors.Add(FormatDuplicates(duplicates));
                return;
            }

            //Add tables to the project
            foreach (DataRow dr in dataTable.Rows)
            {
                string schemaName;
                string name;
                ViewMapping vm;

                ExtractTableInfo(dr, out schemaName, out name);
                vm = project.FindViewMapping(connection.Name, schemaName, name);

                if (vm == null)
                {
                    vm = new ViewMapping(connection.Name, schemaName, name, name, null, null, null, null);
                    vm.JoinToProject(project);
                    project.ViewMappings.Add(vm);
                }
                else if (!string.Equals(vm.SchemaName, schemaName))
                    vm.SchemaName = schemaName;
            }

            RemoveNonExistantViews(project, connection, dataTable);
        }

        private void RemoveNonExistantViews(Project project, Connection connection, DataTable dataTable)
        {
            List<ViewMapping> toConsider = project.ViewMappings.Where(o => string.Equals(o.ConnectionName, connection.Name)).ToList();
            List<ViewMapping> toRemove = new List<ViewMapping>();

            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[QueryConstants.TableOrView.SchemaName], dataTable.Columns[QueryConstants.TableOrView.Name] };

            foreach (ViewMapping vm in toConsider)
            {
                DataRow match = dataTable.Rows.Find(new[] { vm.SchemaName, vm.TableName });

                //Find() is not case sensitive so ensure the case matches otherwise we could end up with duplicate items.
                if (match == null || (!match[QueryConstants.TableOrView.SchemaName].Equals(vm.SchemaName) && !match[QueryConstants.TableOrView.Name].Equals(vm.TableName)))
                    toRemove.Add(vm);
            }

            foreach (ViewMapping tm in toRemove)
                project.TableMappings.Remove(tm);
        }

        private void RefreshColumns(Project project, Connection connection, ref List<string> errors)
        {
            DataTable dataTable = GetColumns(project, connection);
            TableMapping currentTableOrViewMapping = null;
            var duplicates = FindDuplicates(dataTable, QueryConstants.TableOrView.SchemaName, QueryConstants.TableOrView.Name, QueryConstants.Column.Name);

            if (duplicates.Any())
            {
                errors.Add(FormatDuplicates(duplicates));
                return;
            }

            foreach (DataRow dr in dataTable.Rows)
            {
                string forParent;
                string name;
                string schemaName;
                string tableName;
                decimal sequence;
                string databaseDataType;
                decimal length;
                string defaultValue;
                bool nullable;
                bool primaryKey;
                DataTypeMapping dataTypeMapping;
                ColumnMapping cm;
                bool nullableInDatabase;
                string dataType = null;

                ExtractColumnInfo(dr, out forParent, out name, out schemaName, out tableName, out sequence, out databaseDataType, out length, out defaultValue, out nullable, out primaryKey);
                dataTypeMapping = project.FindDataTypeMapping(databaseDataType);
                nullableInDatabase = nullable;

                if (currentTableOrViewMapping == null || !currentTableOrViewMapping.TableName.Equals(tableName))
                {
                    if (QueryConstants.Column.ForTable.Equals(forParent))
                        currentTableOrViewMapping = project.FindTableMapping(connection.Name, schemaName, tableName);
                    else if (QueryConstants.Column.ForView.Equals(forParent))
                        currentTableOrViewMapping = project.FindViewMapping(connection.Name, schemaName, tableName);
                    else
                        throw new ApplicationException("Unknown 'for' value: {0}".FormatString(forParent));
                }

                cm = currentTableOrViewMapping.FindColumnMapping(name);

                if (dataTypeMapping != null)
                {
                    dataType = dataTypeMapping.ApplicationDataType;
                    nullable = (nullable && (dataTypeMapping.Nullable || (cm != null && cm.EnumerationMapping != null)));
                }

                if (cm == null)
                {
                    cm = new ColumnMapping(currentTableOrViewMapping, name, sequence, dataType, databaseDataType, length, defaultValue, nullable, nullableInDatabase, primaryKey, null, null);
                    currentTableOrViewMapping.ColumnMappings.Add(cm);
                }
                else
                {
                    cm.Sequence = sequence;
                    cm.DataType = dataType;
                    cm.DatabaseDataType = databaseDataType;
                    cm.Length = length;
                    cm.DefaultValue = defaultValue;
                    cm.Nullable = nullable;
                    cm.NullableInDatabase = nullableInDatabase;
                    cm.PrimaryKey = primaryKey;
                }
            }

            RemoveNonExistantColumns(project, connection, dataTable);
        }

        private void RemoveNonExistantColumns(Project project, Connection connection, DataTable dataTable)
        {
            List<TableMapping> toConsider = project.TableMappings.Where(o => string.Equals(o.ConnectionName, connection.Name)).ToList();

            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[QueryConstants.TableOrView.SchemaName], dataTable.Columns[QueryConstants.TableOrView.Name], dataTable.Columns[QueryConstants.Column.Name] };

            //Check for columns which are no longer in the table
            foreach (TableMapping tm in toConsider)
            {
                List<ColumnMapping> remove = new List<ColumnMapping>();

                foreach (ColumnMapping cm in tm.ColumnMappings)
                {
                    DataRow match = dataTable.Rows.Find(new string[] { tm.SchemaName, tm.TableName, cm.ColumnName });

                    //Find() is not case sensitive so ensure the case matches otherwise we could end up with duplicate items.
                    if (match == null || (!match[QueryConstants.TableOrView.SchemaName].Equals(tm.SchemaName) && !match[QueryConstants.TableOrView.Name].Equals(tm.TableName) && !match[QueryConstants.Column.Name].Equals(cm.ColumnName)))
                        remove.Add(cm);
                }

                foreach (ColumnMapping cm in remove)
                    tm.ColumnMappings.Remove(cm);
            }
        }

        private void RefreshForeignKeys(Project project, Connection connection, ref List<string> errors)
        {
            DataTable dataTable = GetForeignKeys(project, connection);
            var duplicates = FindDuplicates(dataTable, QueryConstants.ForeignKey.Name);

            if (duplicates.Any())
            {
                var offendingRows = dataTable
                    .Rows.Cast<DataRow>()
                    .Where(o => duplicates.Keys.Contains(o[QueryConstants.ForeignKey.Name])).ToList();

                offendingRows.ForEach(o => dataTable.Rows.Remove(o));

                errors.Add(FormatDuplicates(duplicates));
            }

            foreach (DataRow dr in dataTable.Rows)
            {
                string name;
                string parentTableSchemaName;
                string parentTableName;
                string parentColumnName;
                string referencedTableSchemaName;
                string referencedTableName;
                string referencedColumnName;
                ForeignKeyMapping fkm;
                ColumnMapping parentColumnMapping;
                ColumnMapping referencedColumnMapping;

                ExtractForeignKeyInfo(dr, out name, out parentTableSchemaName, out parentTableName, out parentColumnName, out referencedTableSchemaName, out referencedTableName, out referencedColumnName);
                fkm = project.FindForeignKeyMapping(connection.Name, name);
                parentColumnMapping = project.FindTableMapping(connection.Name, parentTableSchemaName, parentTableName).FindColumnMapping(parentColumnName);
                referencedColumnMapping = project.FindTableMapping(connection.Name, referencedTableSchemaName, referencedTableName).FindColumnMapping(referencedColumnName);

                if (fkm == null)
                {
                    fkm = new ForeignKeyMapping(project, connection.Name, name, parentColumnMapping, referencedColumnMapping, null, null);
                    project.ForeignKeyMappings.Add(fkm);
                }
                else
                {
                    fkm.ParentColumnMapping = parentColumnMapping;
                    fkm.ReferencedColumnMapping = referencedColumnMapping;
                }
            }

            RemoveNonExistantForeignKeys(project, connection, dataTable);
        }

        private void RemoveNonExistantForeignKeys(Project project, Connection connection, DataTable dataTable)
        {
            List<ForeignKeyMapping> toConsider = project.ForeignKeyMappings.Where(o => string.Equals(o.ConnectionName, connection.Name)).ToList();
            List<ForeignKeyMapping> toRemove = new List<ForeignKeyMapping>();

            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[QueryConstants.ForeignKey.Name] };

            foreach (ForeignKeyMapping fk in project.ForeignKeyMappings)
            {
                DataRow match = dataTable.Rows.Find(fk.ForeignKeyName);

                //Find() is not case sensitive so ensure the case matches otherwise we could end up with duplicate items.
                if (match == null || !match[QueryConstants.ForeignKey.Name].Equals(fk.ForeignKeyName))
                    toRemove.Add(fk);
            }

            foreach (ForeignKeyMapping fk in toRemove)
                project.ForeignKeyMappings.Remove(fk);
        }

        private void RefreshUniqueIndices(Project project, Connection connection, ref List<string> errors)
        {
            DataTable dataTable = GetUniqueIndices(project, connection);
            UniqueIndexMapping currentUniqueIndexMapping = null;
            var duplicates = FindDuplicates(dataTable, QueryConstants.Index.Name, QueryConstants.TableOrView.Name, QueryConstants.Column.Name);

            if (duplicates.Any())
            {
                errors.Add(FormatDuplicates(duplicates));
                return;
            }

            foreach (DataRow dr in dataTable.Rows)
            {
                string name;
                string schemaName;
                string tableName;
                string columnName;
                ColumnMapping cm = null;

                ExtractUniqueIndexInfo(dr, out name, out schemaName, out tableName, out columnName);
                cm = project.FindTableMapping(connection.Name, schemaName, tableName).FindColumnMapping(columnName);

                if (currentUniqueIndexMapping == null || !currentUniqueIndexMapping.UniqueIndexName.Equals(name))
                {
                    currentUniqueIndexMapping = cm.TableMapping.FindUniqueIndexMapping(name);

                    if (currentUniqueIndexMapping == null)
                    {
                        currentUniqueIndexMapping = new UniqueIndexMapping(name, null, null);
                        cm.TableMapping.UniqueIndexMappings.Add(currentUniqueIndexMapping);
                    }
                }

                if (!currentUniqueIndexMapping.ColumnMappings.Contains(cm))
                    currentUniqueIndexMapping.ColumnMappings.Add(cm);
            }

            RemoveNonExistantUniqueIndices(project, connection, dataTable);

        }

        private void RemoveNonExistantUniqueIndices(Project project, Connection connection, DataTable dataTable)
        {
            List<TableMapping> toConsider = project.TableMappings.Where(o => string.Equals(o.ConnectionName, connection.Name)).ToList();

            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[QueryConstants.Index.Name], dataTable.Columns[QueryConstants.TableOrView.Name], dataTable.Columns[QueryConstants.Column.Name] };

            //Check for unique indices which are no longer in the table
            foreach (TableMapping tm in toConsider)
            {
                List<UniqueIndexMapping> removeUniqueIndexMappings = new List<UniqueIndexMapping>();

                foreach (UniqueIndexMapping uim in tm.UniqueIndexMappings)
                {
                    List<ColumnMapping> removeColumnMappings = new List<ColumnMapping>();

                    foreach (ColumnMapping cm in uim.ColumnMappings)
                        if (dataTable.Rows.Find(new string[] { uim.UniqueIndexName, tm.TableName, cm.ColumnName }) == null)
                            removeColumnMappings.Add(cm);

                    //If all columns are being removed then the unique index no longer exists.
                    if (removeColumnMappings.Count == uim.ColumnMappings.Count)
                        removeUniqueIndexMappings.Add(uim);
                    else
                    {
                        foreach (ColumnMapping cm in removeColumnMappings)
                            uim.ColumnMappings.Remove(cm);
                    }
                }

                foreach (UniqueIndexMapping uim in removeUniqueIndexMappings)
                    tm.UniqueIndexMappings.Remove(uim);
            }
        }

        private void RemoveDuplicateUniqueIndices(Project project, Connection connection)
        {
            List<TableMapping> toConsider = project.TableMappings.Where(o => string.Equals(o.ConnectionName, connection.Name)).ToList();

            foreach (TableMapping tm in toConsider)
            {
                foreach (UniqueIndexMapping uim in tm.UniqueIndexMappings.Where(o => !o.Exclude))
                {
                    foreach (UniqueIndexMapping uim2 in tm.UniqueIndexMappings.Where(o => !o.Exclude && !o.UniqueIndexName.Equals(uim.UniqueIndexName)))
                    {
                        if (uim.ColumnMappings.Count == uim2.ColumnMappings.Count)
                        {
                            bool duplicate = true;

                            foreach (ColumnMapping cm in uim.ColumnMappings)
                            {
                                if (!uim2.ColumnMappings.Contains(cm))
                                {
                                    duplicate = false;
                                    break;
                                }
                            }

                            if (duplicate)
                                uim2.Exclude = true;
                        }
                    }
                }
            }
        }

        private string FormatDuplicates(Dictionary<string, int> duplicates)
        {
            if (duplicates != null && duplicates.Count > 0)
            {
                StringBuilder message = new StringBuilder();

                message.AppendLine("The following duplicate entries were detected:");

                foreach (var item in duplicates)
                    message.AppendLine($"    {item.Key} ({item.Value})");

                return message.ToString();
            }

            return null;
        }

        private Dictionary<string, int> FindDuplicates(DataTable dataTable, params string[] columns)
        {
            Dictionary<string, int> duplicates = new Dictionary<string, int>();

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    StringBuilder item = new StringBuilder();
                    bool isFirst = true;

                    foreach (string column in columns)
                    {
                        if (!isFirst)
                            item.Append("; ");
                        else
                            isFirst = false;

                        item.Append(row[column].ToString());
                    }

                    if (duplicates.ContainsKey(item.ToString()))
                        duplicates[item.ToString()]++;
                    else
                        duplicates.Add(item.ToString(), 1);
                }

                duplicates = (from d in duplicates
                              where d.Value > 1
                              select d).ToDictionary(o => o.Key, o => o.Value);
            }

            return duplicates;
        }

        public static DatabaseWorker GetInstance(Connection connection)
        {
            string databaseType = connection.DatabaseType;

            if (databaseType.IsNullOrEmpty())
                throw new EmptyDatabaseWorkerSpecifiedException();
            else
            {
                DatabaseWorker worker = DatabaseWorkerManager.Instance[connection.DatabaseType];

                if (worker == null)
                    throw new NonExistentDatabaseWorkerSpecifiedException("Could not locate database worker named: {0}.".FormatString(databaseType));

                return worker;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
