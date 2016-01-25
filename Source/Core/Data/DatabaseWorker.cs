using QuantumConcepts.CodeGenerator.Core.Exceptions;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Core.Data {

    public abstract class DatabaseWorker {
        public abstract string Name { get; }
        public virtual IList<DatabaseParameter> Parameters { get { return null; } }

        protected abstract DataTable GetTables(Project project);

        protected abstract DataTable GetViews(Project project);

        protected abstract DataTable GetColumns(Project project);

        protected abstract DataTable GetForeignKeys(Project project);

        protected abstract DataTable GetUniqueIndices(Project project);

        protected virtual void ExtractTableInfo(DataRow dr, out string schemaName, out string name) {
            schemaName = dr.TryGetValue<string>(QueryConstants.TableOrView.SchemaName);
            name = dr.TryGetValue<string>(QueryConstants.TableOrView.Name);
        }

        protected virtual void ExtractViewInfo(DataRow dr, out string schemaName, out string name) {
            ExtractTableInfo(dr, out schemaName, out name);
        }

        protected virtual void ExtractColumnInfo(DataRow dr, out string forParent, out string name, out string schemaName, out string tableName, out decimal sequence, out string databaseDataType, out decimal length, out string defaultValue, out bool nullable, out bool primaryKey) {
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

        protected virtual void ExtractForeignKeyInfo(DataRow dr, out string name, out string parentTableSchemaName, out string parentTableName, out string parentColumnName, out string referencedTableSchemaName, out string referencedTableName, out string referencedColumnName) {
            name = dr.TryGetValue<string>(QueryConstants.ForeignKey.Name);
            parentTableSchemaName = dr.TryGetValue<string>(QueryConstants.ForeignKey.ParentTableSchemaName);
            parentTableName = dr.TryGetValue<string>(QueryConstants.ForeignKey.ParentTableName);
            parentColumnName = dr.TryGetValue<string>(QueryConstants.ForeignKey.ParentColumnName);
            referencedTableSchemaName = dr.TryGetValue<string>(QueryConstants.ForeignKey.ReferencedTableSchemaName);
            referencedTableName = dr.TryGetValue<string>(QueryConstants.ForeignKey.ReferencedTableName);
            referencedColumnName = dr.TryGetValue<string>(QueryConstants.ForeignKey.ReferencedColumnName);
        }

        protected virtual void ExtractUniqueIndexInfo(DataRow dr, out string name, out string schemaName, out string tableName, out string columnName) {
            name = dr.TryGetValue<string>(QueryConstants.Index.Name);
            schemaName = dr.TryGetValue<string>(QueryConstants.TableOrView.SchemaName);
            tableName = dr.TryGetValue<string>(QueryConstants.TableOrView.Name);
            columnName = dr.TryGetValue<string>(QueryConstants.Column.Name);
        }

        public abstract void ValidateConnection(Project project);

        public abstract IEnumerable<DataTypeMappingConfiguration> GetDataTypeMappingConfigurations();

        public void Refresh(Project project) {
            RefreshTables(project);
            RefreshViews(project);
            RefreshColumns(project);
            RefreshForeignKeys(project);
            RefreshUniqueIndices(project);
        }

        private void RefreshTables(Project project) {
            DataTable dataTable = GetTables(project);

            //Add tables to the project
            foreach (DataRow dr in dataTable.Rows) {
                string schemaName;
                string name;
                Entity tm;

                ExtractTableInfo(dr, out schemaName, out name);
                tm = project.FindTableMapping(schemaName, name);

                if (tm == null) {
                    tm = new Entity(schemaName, name, name, null, null, null, null);
                    tm.JoinToProject(project);
                    project.Entities.Add(tm);
                }
                else if (!string.Equals(tm.SchemaName, schemaName))
                    tm.SchemaName = schemaName;
            }

            try {
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[QueryConstants.TableOrView.SchemaName], dataTable.Columns[QueryConstants.TableOrView.Name] };
            }
            catch (Exception ex) {
                if (!CheckDuplicates("tables", dataTable, QueryConstants.TableOrView.SchemaName, QueryConstants.TableOrView.Name))
                    throw new ApplicationException("An error occurred while refreshing the tables.", ex);
            }

            //Check for tables which are no longer in the database
            if (project.Entities.Count != dataTable.Rows.Count) {
                List<Entity> remove = new List<Entity>();

                foreach (Entity tm in project.Entities) {
                    DataRow match = dataTable.Rows.Find(new[] { tm.SchemaName, tm.Name });

                    //Find() is not case sensitive so ensure the case matches otherwise we could end up with duplicate items.
                    if (match == null || (!match[QueryConstants.TableOrView.SchemaName].Equals(tm.SchemaName) && !match[QueryConstants.TableOrView.Name].Equals(tm.Name)))
                        remove.Add(tm);
                }

                foreach (Entity tm in remove)
                    project.Entities.Remove(tm);
            }
        }

        private void RefreshViews(Project project) {
            DataTable dataTable = GetViews(project);

            //Add tables to the project
            foreach (DataRow dr in dataTable.Rows) {
                string schemaName;
                string name;
                ViewEntity vm;

                ExtractTableInfo(dr, out schemaName, out name);
                vm = project.FindViewMapping(schemaName, name);

                if (vm == null) {
                    vm = new ViewEntity(schemaName, name, name, null, null, null, null);
                    vm.JoinToProject(project);
                    project.ViewMappings.Add(vm);
                }
                else if (!string.Equals(vm.SchemaName, schemaName))
                    vm.SchemaName = schemaName;
            }

            try {
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[QueryConstants.TableOrView.SchemaName], dataTable.Columns[QueryConstants.TableOrView.Name] };
            }
            catch (Exception ex) {
                if (!CheckDuplicates("views", dataTable, QueryConstants.TableOrView.SchemaName, QueryConstants.TableOrView.Name))
                    throw new ApplicationException("An error occurred while refreshing the views.", ex);
            }

            //Check for tables which are no longer in the database
            if (project.ViewMappings.Count != dataTable.Rows.Count) {
                List<ViewEntity> remove = new List<ViewEntity>();

                foreach (ViewEntity vm in project.ViewMappings) {
                    DataRow match = dataTable.Rows.Find(new[] { vm.SchemaName, vm.Name });

                    //Find() is not case sensitive so ensure the case matches otherwise we could end up with duplicate items.
                    if (match == null || (!match[QueryConstants.TableOrView.SchemaName].Equals(vm.SchemaName) && !match[QueryConstants.TableOrView.Name].Equals(vm.ViewName)))
                        remove.Add(vm);
                }

                foreach (ViewEntity vm in remove)
                    project.ViewMappings.Remove(vm);
            }
        }

        private void RefreshColumns(Project project) {
            DataTable dataTable = GetColumns(project);
            Entity currentTableOrViewMapping = null;

            foreach (DataRow dr in dataTable.Rows) {
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
                Property cm;
                bool nullableInDatabase;
                string dataType = null;

                ExtractColumnInfo(dr, out forParent, out name, out schemaName, out tableName, out sequence, out databaseDataType, out length, out defaultValue, out nullable, out primaryKey);
                dataTypeMapping = project.FindDataTypeMapping(databaseDataType);
                nullableInDatabase = nullable;

                if (currentTableOrViewMapping == null || !currentTableOrViewMapping.Name.Equals(tableName)) {
                    if (QueryConstants.Column.ForTable.Equals(forParent))
                        currentTableOrViewMapping = project.FindTableMapping(schemaName, tableName);
                    else if (QueryConstants.Column.ForView.Equals(forParent))
                        currentTableOrViewMapping = project.FindViewMapping(schemaName, tableName);
                    else
                        throw new ApplicationException("Unknown 'for' value: {0}".FormatString(forParent));
                }

                cm = currentTableOrViewMapping.FindColumnMapping(name);

                if (dataTypeMapping != null) {
                    dataType = dataTypeMapping.ApplicationDataType;
                    nullable = (nullable && (dataTypeMapping.Nullable || (cm != null && cm.EnumerationMapping != null)));
                }

                if (cm == null) {
                    cm = new Property(currentTableOrViewMapping, name, sequence, dataType, databaseDataType, length, defaultValue, nullable, nullableInDatabase, primaryKey, null, null);
                    currentTableOrViewMapping.Properties.Add(cm);
                }
                else {
                    cm.Sequence = sequence;
                    cm.DataType = dataType;
                    cm.DatabaseDataType = databaseDataType;
                    cm.Length = length;
                    cm.DefaultValue = defaultValue;
                    cm.Nullable = nullable;
                    cm.NullableInDatabase = nullableInDatabase;
                    cm.IsKey = primaryKey;
                }
            }

            try {
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[QueryConstants.TableOrView.SchemaName], dataTable.Columns[QueryConstants.TableOrView.Name], dataTable.Columns[QueryConstants.Column.Name] };
            }
            catch (Exception ex) {
                if (!CheckDuplicates("columns", dataTable, QueryConstants.TableOrView.SchemaName, QueryConstants.TableOrView.Name, QueryConstants.Column.Name))
                    throw new ApplicationException("An error occurred while refreshing the columns.", ex);
            }

            //Check for columns which are no longer in the table
            foreach (Entity tm in project.Entities) {
                if (tm.Properties.Count != dataTable.Rows.Count) {
                    List<Property> remove = new List<Property>();

                    foreach (Property cm in tm.Properties) {
                        DataRow match = dataTable.Rows.Find(new string[] { tm.SchemaName, tm.Name, cm.Name });

                        //Find() is not case sensitive so ensure the case matches otherwise we could end up with duplicate items.
                        if (match == null || (!match[QueryConstants.TableOrView.SchemaName].Equals(tm.SchemaName) && !match[QueryConstants.TableOrView.Name].Equals(tm.Name) && !match[QueryConstants.Column.Name].Equals(cm.Name)))
                            remove.Add(cm);
                    }

                    foreach (Property cm in remove)
                        tm.Properties.Remove(cm);
                }
            }
        }

        private void RefreshForeignKeys(Project project) {
            DataTable dataTable = GetForeignKeys(project);

            foreach (DataRow dr in dataTable.Rows) {
                string name;
                string parentTableSchemaName;
                string parentTableName;
                string parentColumnName;
                string referencedTableSchemaName;
                string referencedTableName;
                string referencedColumnName;
                EntityRelationship fkm;
                Property parentColumnMapping;
                Property referencedColumnMapping;

                ExtractForeignKeyInfo(dr, out name, out parentTableSchemaName, out parentTableName, out parentColumnName, out referencedTableSchemaName, out referencedTableName, out referencedColumnName);
                fkm = project.FindForeignKeyMapping(name);
                parentColumnMapping = project.FindTableMapping(parentTableSchemaName, parentTableName).FindColumnMapping(parentColumnName);
                referencedColumnMapping = project.FindTableMapping(referencedTableSchemaName, referencedTableName).FindColumnMapping(referencedColumnName);

                if (fkm == null) {
                    fkm = new EntityRelationship(project, name, parentColumnMapping, referencedColumnMapping, null, null);
                    project.EntityRelationships.Add(fkm);
                }
                else {
                    fkm.ParentColumnMapping = parentColumnMapping;
                    fkm.ReferencedColumnMapping = referencedColumnMapping;
                }
            }

            try {
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[QueryConstants.ForeignKey.Name] };
            }
            catch (Exception ex) {
                if (!CheckDuplicates("foreign keys", dataTable, QueryConstants.ForeignKey.Name))
                    throw new ApplicationException("An error occurred while refreshing the foreign keys.", ex);
            }

            //Check for foreign keys which are no longer in the table
            if (project.EntityRelationships.Count != dataTable.Rows.Count) {
                List<EntityRelationship> remove = new List<EntityRelationship>();

                foreach (EntityRelationship fk in project.EntityRelationships) {
                    DataRow match = dataTable.Rows.Find(fk.Name);

                    //Find() is not case sensitive so ensure the case matches otherwise we could end up with duplicate items.
                    if (match == null || !match[QueryConstants.ForeignKey.Name].Equals(fk.Name))
                        remove.Add(fk);
                }

                foreach (EntityRelationship fk in remove)
                    project.EntityRelationships.Remove(fk);
            }
        }

        private void RefreshUniqueIndices(Project project) {
            DataTable dataTable = GetUniqueIndices(project);
            ProjectSchema.UniqueConstraint currentUniqueIndexMapping = null;

            foreach (DataRow dr in dataTable.Rows) {
                string name;
                string schemaName;
                string tableName;
                string columnName;
                Property cm = null;

                ExtractUniqueIndexInfo(dr, out name, out schemaName, out tableName, out columnName);
                cm = project.FindTableMapping(schemaName, tableName).FindColumnMapping(columnName);

                if (currentUniqueIndexMapping == null || !currentUniqueIndexMapping.UniqueIndexName.Equals(name)) {
                    currentUniqueIndexMapping = cm.Entity.FindUniqueIndexMapping(name);

                    if (currentUniqueIndexMapping == null) {
                        currentUniqueIndexMapping = new ProjectSchema.UniqueConstraint(name, null, null);
                        cm.Entity.UniqueConstraints.Add(currentUniqueIndexMapping);
                    }
                }

                if (!currentUniqueIndexMapping.Properties.Contains(cm))
                    currentUniqueIndexMapping.Properties.Add(cm);
            }

            try {
                dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[QueryConstants.Index.Name], dataTable.Columns[QueryConstants.TableOrView.Name], dataTable.Columns[QueryConstants.Column.Name] };
            }
            catch (Exception ex) {
                if (!CheckDuplicates("unique indices", dataTable, QueryConstants.Index.Name, QueryConstants.TableOrView.Name, QueryConstants.Column.Name))
                    throw new ApplicationException("An error occurred while refreshing the unique indices.", ex);
            }

            //Check for unique indices which are no longer in the table
            foreach (Entity tm in project.Entities) {
                if (tm.UniqueConstraints.Count != dataTable.Rows.Count) {
                    List<ProjectSchema.UniqueConstraint> removeUniqueIndexMappings = new List<ProjectSchema.UniqueConstraint>();

                    foreach (ProjectSchema.UniqueConstraint uim in tm.UniqueConstraints) {
                        List<Property> removeColumnMappings = new List<Property>();

                        foreach (Property cm in uim.Properties)
                            if (dataTable.Rows.Find(new string[] { uim.UniqueIndexName, tm.Name, cm.Name }) == null)
                                removeColumnMappings.Add(cm);

                        //If all columns are being removed then the unique index no longer exists.
                        if (removeColumnMappings.Count == uim.Properties.Count)
                            removeUniqueIndexMappings.Add(uim);
                        else {
                            foreach (Property cm in removeColumnMappings)
                                uim.Properties.Remove(cm);
                        }
                    }

                    foreach (ProjectSchema.UniqueConstraint uim in removeUniqueIndexMappings)
                        tm.UniqueConstraints.Remove(uim);
                }
            }

            //Exlude duplicate unique indices.
            foreach (Entity tm in project.Entities) {
                foreach (ProjectSchema.UniqueConstraint uim in tm.UniqueConstraints.Where(o => !o.Exclude)) {
                    foreach (ProjectSchema.UniqueConstraint uim2 in tm.UniqueConstraints.Where(o => !o.Exclude && !o.UniqueIndexName.Equals(uim.UniqueIndexName))) {
                        if (uim.Properties.Count == uim2.Properties.Count) {
                            bool duplicate = true;

                            foreach (Property cm in uim.Properties) {
                                if (!uim2.Properties.Contains(cm)) {
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

        private bool CheckDuplicates(string pluralItemName, DataTable dataTable, params string[] columns) {
            Dictionary<string, int> duplicates = FindDuplicates(dataTable, columns);

            if (duplicates != null && duplicates.Count > 0) {
                StringBuilder message = new StringBuilder();

                foreach (string key in duplicates.Keys)
                    message.AppendFormat("\n\t{0} ({1})", key, duplicates[key]);

                throw new ApplicationException("The following duplicate entries were detected while refreshing the {0}:\n{1}".FormatString(pluralItemName, message.ToString()));
            }

            return false;
        }

        private Dictionary<string, int> FindDuplicates(DataTable dataTable, params string[] columns) {
            Dictionary<string, int> duplicates = new Dictionary<string, int>();

            if (dataTable == null || dataTable.Rows.Count == 0)
                return null;

            foreach (DataRow row in dataTable.Rows) {
                StringBuilder item = new StringBuilder();
                bool isFirst = true;

                foreach (string column in columns) {
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

            return duplicates;
        }

        public static DatabaseWorker GetInstance(Project project) {
            string databaseType = project.UserSettings.Connection.DatabaseType;

            if (databaseType.IsNullOrEmpty())
                throw new EmptyDatabaseWorkerSpecifiedException();
            else {
                DatabaseWorker worker = DatabaseWorkerManager.Instance[project.UserSettings.Connection.DatabaseType];

                if (worker == null)
                    throw new NonExistentDatabaseWorkerSpecifiedException("Could not locate database worker named: {0}.".FormatString(databaseType));

                return worker;
            }
        }

        public override string ToString() {
            return this.Name;
        }
    }
}