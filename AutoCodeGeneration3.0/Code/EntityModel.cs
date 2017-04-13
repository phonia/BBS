using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCodeGeneration3._0.Code
{
    [Serializable]
    public class EntityModel
    {
        public String DomainName { get; set; }
        public String ClassName { get; set; }
        public bool IsEntityType { get; set; }
        public bool IsEnum { get; set; }
        public bool IsComplexyType { get; set; }
        public String Description { get; set; }

        public String TableName { get; set; }
        public String PKName { get; set; }
        public String PKType { get; set; }

        public List<String> EntityAssemblies { get; set; }
        public List<String> IRepositoryAssemblies { get; set; }
        public List<String> RepositoryAssemblies { get; set; }
        public List<String> ConfigurationAssemblies { get; set; }

        public String EntityNamespace { get; set; }
        public String IRepositoryNamespace { get; set; }
        public String RepositoryNamespace { get; set; }
        public String ConfigurationNamespace { get; set; }
        public String DataContextNamespace { get; set; }

        public String EntityPath { get; set; }
        public String IRepositoryPath { get; set; }
        public String RepositoryPath { get; set; }
        public String ConfigurationPath { get; set; }
        public String DataContextPath { get; set; }

        public List<EntityProperty> EntityProperties { get; set; }

        public static List<EntityModel>  ConvertToEntityModel(List<DataRecord> dataRecords)
        {
            List<EntityModel> entityModel = null;
            if(entityModel==null)entityModel = new List<EntityModel>();
            dataRecords.ForEach(it =>
            {
                if (it.IsClassRecord(dataRecords))
                {
                    DataRecord pk = dataRecords.Where(dr =>dr.Key == Key.PK && dr.ClassName == it.ClassName).FirstOrDefault();
                    entityModel.Add(new EntityModel()
                    {
                        ClassName = it.ClassName,
                        Description = it.FieldDescription,
                        DomainName = it.DomainName,
                        PKName = pk != null ? pk.FieldName : String.Empty,
                        PKType = pk != null ? pk.FieldType : String.Empty,
                        TableName = it.TableName,
                        IsComplexyType = it.IsComplexyType(),
                        IsEntityType = it.isEntityType(),
                        IsEnum = it.IsEnum()
                    });
                }
            });

            //加载普通属性
            entityModel.ForEach(it => {
                dataRecords.ForEach(dr => {
                    if (dr.ClassName.Equals(it.ClassName) && dr.IsClassProperty(it.ClassName))
                    {
                        if (it.EntityProperties == null) it.EntityProperties = new List<EntityProperty>();
                        if (it.IsEnum)
                        {
                            it.EntityProperties.Add(new EntityProperty()
                            {
                                IsEnumItem = true,
                                Description=dr.FieldDescription,
                                ItemName=dr.FieldName
                            });
                        }
                        else
                        {
                            if (dr.Key == Key.FK) {
                                it.EntityProperties.Add(new EntityProperty()
                                {
                                    IsNavigationProperty = true,
                                    IsGeneric=false,
                                    Description=dr.FieldDescription,
                                    NavigationName=dr.FieldName.Substring(0,dr.FieldName.Length-2),
                                    NavigationType=dr.ReferenceTable
                                });
                            }
                            it.EntityProperties.Add(new EntityProperty()
                            {
                                IsCustomProperty = true,
                                DefaultValue=dr.DefaultValues,
                                Description=dr.FieldDescription,
                                FieldName=dr.FieldName,
                                FieldType=dr.FieldType,
                                IsComplexyType=String.IsNullOrWhiteSpace(dr.FieldType)?true:false,
                                IsForeignKey=dr.Key==Key.FK?true:false,
                                IsIdentity=dr.IsIdentity,
                                IsNull=dr.IsNUll,
                                IsPrimaryKey=dr.Key==Key.PK?true:false,
                                IsString=dr.PropertyType.Equals("String")?true:false,
                                MaxLength=dr.MaxLength,
                                PropertyName=dr.PropertyName,
                                PropertyType=dr.PropertyType,
                                ReferenceTable=dr.ReferenceTable,
                                ReferenceField=dr.ReferenceField
                            });
                        }
                    }

                    if (dr.ReferenceTable.Equals(it.TableName))
                    {
                        if (it.EntityProperties == null) it.EntityProperties = new List<EntityProperty>();
                        it.EntityProperties.Add(new EntityProperty()
                        {
                            IsGeneric = true,
                            IsNavigationProperty=true,
                            Description=it.Description,
                            NavigationName = String.IsNullOrWhiteSpace(dr.ReferenceField) ? dr.ClassName+"s" : dr.ReferenceField,
                            NavigationType=dr.ClassName
                        });
                    }
                });
            });
            return entityModel;
        }
    }

    [Serializable]
    public class EntityProperty
    {
        //实体普通类属性
        public bool IsCustomProperty { get; set; }
        public String PropertyName { get; set; }
        public String PropertyType { get; set; }
        public String FieldName { get; set; }
        public String FieldType { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsForeignKey { get; set; }
        public String ReferenceTable { get; set; }
        public String ReferenceField { get; set; }
        public Int32 MaxLength { get; set; }
        public bool IsString { get; set; }
        public bool IsIdentity { get; set; }
        public bool IsNull { get; set; }
        public String DefaultValue { get; set; }

        //实体类导航属性
        public bool IsNavigationProperty { get; set; }
        public bool IsGeneric { get; set; }
        public String NavigationName { get; set; }
        public String NavigationType { get; set; }

        //枚举类属性
        public bool IsEnumItem { get; set; }
        public String ItemName { get; set; }

        //公共熟属性
        public String Description { get; set; }

        //复杂属性
        public bool IsComplexyType { get; set; }
    }
}
