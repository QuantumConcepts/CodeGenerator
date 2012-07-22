SELECT
    t.table_schema AS SchemaName,
    t.table_name AS Name
FROM information_schema.tables t
WHERE t.table_type = "BASE TABLE";