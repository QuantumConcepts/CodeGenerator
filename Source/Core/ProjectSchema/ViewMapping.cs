﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    [XmlRoot("ViewMapping")]
    public class ViewMapping : TableMapping
    {
        [XmlIgnore]
        public override string TableName { get { return base.TableName; } set { base.TableName = value; } }

        [XmlAttribute]
        public string ViewName { get { return base.TableName; } set { base.TableName = value; } }

        [XmlAttribute]
        public override bool ReadOnly { get { return true; } set { } }

        public ViewMapping() { }

        public ViewMapping(string connectionName, string schemaName, string tableName, string className, List<ColumnMapping> columnMappings, List<UniqueIndexMapping> uniqueIndexMappings, List<Annotation<TableMapping>> annotations, List<Attribute<TableMapping>> attributes)
            : base(connectionName, schemaName, tableName, className, columnMappings, uniqueIndexMappings, annotations, attributes)
        {
        }
    }
}
