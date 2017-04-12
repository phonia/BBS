using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCodeGeneration3._0.Code
{
    public class EntityModel
    {
        public String ClassName { get; set; }
        public String TableName { get; set; }
        public String Domain { get; set; }
        public String EntityType { get; set; }
        public String Description { get; set; }
        public String PrimaryKey { get; set; }
        public String PrimaryKeyPropertyType { get; set; }

        public List<EntityProperty> EntityProperties { get; set; }
    }

    public class EntityProperty
    {
        public String PropertyName { get; set; }
        public String FieldName { get; set; }
        public String PropertyType { get; set; }
        public String FieldType { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsForeignKey { get; set; }
        public bool IsIdentity { get; set; }
        public bool IsString { get; set; }
        public Int32 Maxlength { get; set; }
        public String DefautlValue { get; set; }
        public bool IsNull { get; set; }
        public String Description { get; set; }
        public bool IsNavigation { get; set; }
        public bool IsGeneric { get; set; }
    }
}
