SELECT DISTINCT
    i.constraint_name, 
    t.table_schema, 
    t.table_name, 
    ic.column_name
FROM
    information_schema.table_constraints i
    JOIN information_schema.tables t ON t.table_schema = i.table_schema AND t.table_name = i.table_name
    JOIN information_schema.key_column_usage ic ON ic.constraint_name = i.constraint_name AND ic.table_schema = t.table_schema AND ic.table_name = t.table_name
WHERE
    i.constraint_type = "UNIQUE"