SELECT
    CASE t.table_type
        WHEN "BASE TABLE" THEN "ForTable"
        WHEN "VIEW" THEN "ForView"
    END AS "For",
    c.table_schema AS TableOrViewSchemaName,
    c.table_name AS TableOrViewName,
    c.column_name AS ColumnName,
    CONVERT(c.ordinal_position, SIGNED) AS ColumnSequence,
    CONCAT(IF(INSTR(c.column_type, "unsigned") > 0, "u", ""), c.data_type) AS ColumnDataType,
    c.character_maximum_length AS ColumnLength,
    c.column_default AS ColumnDefaultValue,
    c.is_nullable AS ColumnNullable,
    IF(c.column_key = "PRI", "YES", "NO") AS ColumnPrimaryKey
FROM
    information_schema.columns c
    JOIN information_schema.tables t ON t.table_schema = c.table_schema AND t.table_name = c.table_name
WHERE t.table_schema = "CodeGeneratorTest"