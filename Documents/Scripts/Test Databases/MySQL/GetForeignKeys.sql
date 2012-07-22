SELECT DISTINCT
    fk.constraint_name,
    t.table_schema,
    t.table_name,
    ic.column_name,
    ic.referenced_table_schema,
    ic.referenced_table_name,
    ic.referenced_column_name
FROM
    information_schema.table_constraints fk
    JOIN information_schema.tables t ON t.table_schema = fk.table_schema AND t.table_name = fk.table_name
    JOIN information_schema.key_column_usage ic ON ic.constraint_name = fk.constraint_name AND ic.table_schema = t.table_schema AND ic.table_name = t.table_name
WHERE fk.constraint_type = "FOREIGN KEY"