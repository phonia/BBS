using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCodeGeneration3._0.Code
{
    [Serializable]
    public class SaveBack
    {
        public List<EntityModel> EntityModels { get; set; }
        public List<ViewModel> ViewModels{get;set;}
    }

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
        public String PKPropertyType { get; set; }
        public String PKPropertyName { get; set; }

        public List<String> EntityQuoteNamespaces { get; set; }
        public List<String> IRepositoryQuoteNamespaces { get; set; }
        public List<String> RepositoryQuoteNamespaces { get; set; }
        public List<String> ConfigurationQuoteNamespaces { get; set; }
        public List<String> DataContextQuoteNamespaces { get; set; }

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
                        PKPropertyName = pk != null ? pk.PropertyName : String.Empty,
                        PKType = pk != null ? pk.FieldType : String.Empty,
                        PKPropertyType = pk != null ? pk.PropertyType : String.Empty,
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
                                    IsGeneric = false,
                                    Description = dr.FieldDescription,
                                    NavigationName = dr.FieldName.Substring(0, dr.FieldName.Length - 2),
                                    NavigationType = dr.ReferenceTable,
                                    PropertyName = dr.FieldName,
                                    ReferenceTable = dr.ReferenceTable,
                                    ReferenceField = dr.ReferenceField,
                                    IsNull=dr.IsNUll
                                });
                            }
                            it.EntityProperties.Add(new EntityProperty()
                            {
                                IsCustomProperty = String.IsNullOrWhiteSpace(dr.FieldType)?false:true,
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

                    if (dr.ReferenceTable.Equals(it.TableName)&&!String.IsNullOrWhiteSpace(dr.ReferenceField))
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

    [Serializable]
    public class ViewModel
    {        
        public String ClassName { get; set; }
        public String MappingEntityName { get; set; }
        public String Description { get; set; }
        public String DomainName { get; set; }
        public bool IsClass { get; set; }
        public bool IsEnum { get; set; }
        public String Namespace { get; set; }
        public String Path { get; set; }
        public bool IsModified { get; set; }
        public List<ViewProperty> ViewProperties { get; set; }
        public List<String> QuoteNamespace { get; set; }

        public static List<ViewModel> ConvertEntityToViewModel(List<EntityModel> entitymodels,List<ViewModel> preViewModels)
        {
            List<ViewModel> viewModels = new List<ViewModel>();
            if (entitymodels != null && entitymodels.Count > 0)
            {
                entitymodels.ForEach(it => {
                    ViewModel temp = null;
                    if (preViewModels!=null&&preViewModels.Where(p => p.ClassName.Equals(it.ClassName + "DTO")).FirstOrDefault() != null) return;
                    if (it.IsEnum)
                    {
                        temp = new ViewModel();
                        temp.IsEnum = true;
                        temp.ClassName = it.ClassName+"DTO";
                        temp.MappingEntityName = it.ClassName;
                        temp.DomainName = it.DomainName;
                        temp.Description = it.Description;
                        temp.Namespace=preViewModels==null?"":preViewModels.First().Namespace;
                        temp.Path = preViewModels == null ? "" : preViewModels.First().Path;
                        temp.QuoteNamespace = preViewModels == null ? null : preViewModels.First().QuoteNamespace;
                        if (it.EntityProperties != null && it.EntityProperties.Count > 0)
                        {
                            it.EntityProperties.ForEach(ep => {
                                if (ep.IsEnumItem)
                                {
                                    if (temp.ViewProperties == null) temp.ViewProperties = new List<ViewProperty>();
                                    temp.ViewProperties.Add(new ViewProperty()
                                    {
                                        IsGeneric = false,
                                        IsMappingGeneric=false,
                                        PropertyName=ep.ItemName,
                                        PropertyType=string.Empty,
                                        MappingPropertyName=ep.ItemName,
                                        MappingPropertyType=string.Empty,
                                        Description=ep.Description
                                    });
                                }
                            });
                        }
                        viewModels.Add(temp);
                    }
                    ///
                    if (it.IsEntityType) {
                        temp = new ViewModel()
                        {
                            ClassName = it.ClassName+"DTO",
                            IsClass=true,
                            IsEnum=false,
                            MappingEntityName=it.ClassName,
                            DomainName=it.DomainName,
                            Description=it.Description
                        };
                        temp.Namespace = preViewModels == null ? "" : preViewModels.First().Namespace;
                        temp.Path = preViewModels == null ? "" : preViewModels.First().Path;
                        temp.QuoteNamespace = preViewModels == null ? null : preViewModels.First().QuoteNamespace;
                        if (it.EntityProperties != null && it.EntityProperties.Count > 0)
                        {
                            it.EntityProperties.ForEach(ep => {
                                if (temp.ViewProperties == null) temp.ViewProperties = new List<ViewProperty>();
                                if (ep.IsCustomProperty)
                                {
                                    temp.ViewProperties.Add(new ViewProperty()
                                    {
                                        IsGeneric = false,
                                        IsMappingGeneric = false,
                                        PropertyName = ep.PropertyName,
                                        PropertyType = ep.PropertyType,
                                        MappingPropertyName = ep.PropertyName,
                                        MappingPropertyType = ep.PropertyType,
                                        Description=ep.Description
                                    });
                                }

                                if (ep.IsNavigationProperty)
                                {
                                    if (ep.IsGeneric)
                                    { }
                                    else
                                    { }
                                }

                                if (ep.IsComplexyType)
                                { }
                            });
                        }
                        viewModels.Add(temp);
                    }

                    if (it.IsComplexyType) { }
                    //if (it.EntityProperties != null && it.EntityProperties.Count > 0)
                    //{
                    //    it.EntityProperties.ForEach(ep => { });
                    //}
                });
            }

            if (preViewModels != null)
            {
                preViewModels.ForEach(it => {
                    if (it.IsModified)
                        viewModels.Add(it);
                });
            }

            return viewModels;
        }
    }

    [Serializable]
    public class ViewProperty
    {
        public String Description { get; set; }
        public String PropertyName { get; set; }
        public String PropertyType { get; set; }
        public String MappingPropertyName { get; set; }
        public String MappingPropertyType { get; set; }
        public bool IsGeneric { get; set; }
        public bool IsMappingGeneric { get; set; }
    }

    public class ServiceModel
    {
        public String ServiceName { get; set; }
        public String Path { get; set; }
        public String Namespace { get; set; }
        public String IsOverride { get; set; }//文件是否覆盖 默认为不覆盖
        public List<String> QuoteNamspace { get; set; }
        public List<String> QuoteEntity { get; set; }
    }

    public class ServiceMethod
    { }
}
