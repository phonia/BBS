using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoCodeGeneration
{
    public class EFConfigurationGeneration
    {
        public void GenerateCode(List<DataRecord> list, String destination)
        {
            if (list != null && list.Count >= 0)
            {
                foreach (var item in list)
                {
                    if (!item.IsClassRecord(list)) continue;
                    if (item.IsEnum()) continue;

                    FileStream fs = new FileStream(destination + "\\" + item.DataTable + "Configuration.cs", FileMode.Create);
                    using (var sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("/*==================================================");
                        sw.WriteLine("//============auto-generated code===================");
                        sw.WriteLine("//============not modified please===================");
                        sw.WriteLine("//================================================*/");
                        sw.WriteLine("");
                        sw.WriteLine("using System;");
                        sw.WriteLine("using System.Collections.Generic;");
                        sw.WriteLine("using System.ComponentModel.DataAnnotations.Schema;");
                        sw.WriteLine("using System.Data.Entity.ModelConfiguration;");
                        sw.WriteLine("using System.Linq;");
                        sw.WriteLine("using System.Text;");
                        sw.WriteLine("using Model;");
                        sw.WriteLine("");
                        sw.WriteLine("namespace Repository");
                        sw.WriteLine("{");
                        sw.WriteLine("    /// <summary>");
                        sw.WriteLine("    /// "+item.DataTable+" 配置类");
                        sw.WriteLine("    /// </summary>");
                        if(item.isEntityType())
                            sw.WriteLine("    class " + item.DataTable + "Configuration:EntityTypeConfiguration<" + item.DataTable + ">");
                        if(item.IsComplexyType())
                            sw.WriteLine("    class " + item.DataTable + "Configuration:ComplexTypeConfiguration<" + item.DataTable + ">");
                        sw.WriteLine("    {");
                        sw.WriteLine("        public "+item.DataTable+"Configuration()");
                        sw.WriteLine("        {");
                        if(item.isEntityType())
                            sw.WriteLine("            ToTable(\""+item.DataTable+"\");");

                        foreach (var node in list)
                        {
                            if (!node.IsClassProperty(item.DataTable)) continue;
                            if (String.IsNullOrWhiteSpace(node.FieldType)) continue;

                            if (node.Key == Key.FK)
                            {
                                //            HasRequired(e=>e.MenuInfo).WithMany(e=>e.ActionPermissions).Map(e=>e.MapKey("MenuInfoId"));
                                sw.Write("            HasRequired(e=>e." + node.FieldName.Substring(0,node.FieldName.Length-2) + ")");
                                if (!String.IsNullOrWhiteSpace(node.referenceProperty))
                                    sw.Write(".WithMany(e=>e." + node.referenceProperty + ")");
                                else
                                    sw.Write(".WithMany()");
                                sw.WriteLine(".Map(e=>e.MapKey(\""+node.FieldName+"\"));");
                                continue;
                            }

                            if(node.Key==Key.PK)
                                sw.WriteLine("            HasKey(e=>e."+node.FieldName+");");
                            sw.Write("            Property(e =>e." + node.FieldName + ")");
                            sw.Write(".HasColumnName(\""+node.FieldName+"\")");
                            if (node.IsIdentity)
                                sw.Write(".HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)");
                            sw.Write(".HasColumnType(\""+node.FieldType+"\")");
                            if (node.IsNUll)
                                sw.WriteLine(".IsOptional();");
                            else
                                sw.WriteLine(".IsRequired();");
                            //            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
                        }

                        sw.WriteLine("        }");
                        sw.WriteLine("    }");
                        sw.WriteLine("}");
                    }
                    fs.Close();
                    fs.Dispose();
                }
            }
        }
    }
}
