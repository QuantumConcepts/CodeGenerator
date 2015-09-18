namespace QuantumConcepts.CodeGenerator.Core.Data {

    public static class QueryConstants {

        public static class TableOrView {
            public const string SchemaName = "SchemaName";
            public const string Name = "TableOrViewName";
        }

        public static class Column {
            public const string For = "For";
            public const string ForTable = "Table";
            public const string ForView = "View";
            public const string Name = "ColumnName";
            public const string Sequence = "ColumnSequence";
            public const string DataType = "ColumnDataType";
            public const string Length = "ColumnLength";
            public const string DefaultValue = "ColumngDefaultValue";
            public const string Nullable = "ColumnNullable";
            public const string PrimaryKey = "ColumnPrimaryKey";
        }

        public static class ForeignKey {
            public const string Name = "ForeignKeyName";
            public const string ParentTableSchemaName = "ParentTableSchemaName";
            public const string ParentTableName = "ParentTableName";
            public const string ParentColumnName = "ParentColumnName";
            public const string ReferencedTableSchemaName = "ReferencedTableSchemaName";
            public const string ReferencedTableName = "ReferencedTableName";
            public const string ReferencedColumnName = "ReferencedColumnName";
        }

        public static class Index {
            public const string Name = "IndexName";
        }
    }
}