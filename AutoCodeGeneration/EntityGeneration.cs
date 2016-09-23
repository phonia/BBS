﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoCodeGeneration
{
    public class EntityGeneration
    {
        public void GenerateCode(List<DataRecord> list, String destination)
        {
            if (list != null)
            {
                foreach (var item in list)
                {
                    if(item.IsClassRecord(list))
                    {
                        FileStream fs = new FileStream(destination+"\\"+item.DataTable+".cs", FileMode.Create);
                        using (var sw = new StreamWriter(fs))
                        {
                            sw.WriteLine("/*==================================================");
                            sw.WriteLine("//============auto-generated code===================");
                            sw.WriteLine("//============not modified please===================");
                            sw.WriteLine("//================================================*/");
                            sw.WriteLine("");
                            sw.WriteLine("using System;");
                            sw.WriteLine("using System.Collections.Generic;");
                            sw.WriteLine("using System.ComponentModel;");
                            sw.WriteLine("using System.Linq;");
                            sw.WriteLine("using System.Text;");
                            sw.WriteLine("using Infrastructure;");
                            sw.WriteLine("");
                            sw.WriteLine("namespace Model");
                            sw.WriteLine("{");
                            if (item.isEntityType())//实体类型
                            {
                                sw.WriteLine("    /// <summary>");
                                sw.WriteLine("    /// "+item.FieldDescription+" 实体类");
                                sw.WriteLine("    /// </summary>");
                                sw.WriteLine("    public partial class "+item.DataTable+":EntityBase,IAggregateRoot");
                                sw.WriteLine("    {");

                                int count = 0;
                                foreach (var node in list)
                                {
                                    //普通属性 以及外键属性
                                    if (node.IsClassProperty(item.DataTable))
                                    {
                                        if (count != 0)
                                            sw.WriteLine("");
                                        sw.WriteLine("        /// <summary>");
                                        sw.WriteLine("        /// "+node.FieldDescription);
                                        if(!String.IsNullOrWhiteSpace(node.DefaultValues))
                                            sw.WriteLine("        /// "+"默认值"+" "+node.DefaultValues);
                                        if (node.Key == Key.PK)
                                            sw.WriteLine("        /// "+"主键");
                                        if (node.IsIdentity)
                                            sw.WriteLine("        /// "+"自增");
                                        sw.WriteLine("        /// </summary>");

                                        if (node.Key == Key.FK)
                                        {
                                            sw.WriteLine("        public " + node.ReferenceDataTable + " " + node.FieldName.Substring(0, node.FieldName.Length - 2) + " { get; set; }");
                                        }
                                        else
                                        {
                                            sw.WriteLine("        public " + (node.IsNUll?node.ConvertToNullable():node.PropertyType) + " " + node.FieldName + " { get; set; }");
                                        }
                                        
                                        count++;
                                    }
                                }

                                //附加属性
                                sw.WriteLine("");
                                sw.WriteLine("        public Int32? CreateUserId { get; set; }");
                                sw.WriteLine("");
                                sw.WriteLine("        public Int32? UpdateUserId { get; set; }");
                                sw.WriteLine("");
                                sw.WriteLine("        public DateTime? CreateDateTime { get; set; }");
                                sw.WriteLine("");
                                sw.WriteLine("        public DateTime? UpdateDateTime { get; set; }");
                                sw.WriteLine("");

                                //连接属性
                                foreach (var node in list)
                                {
                                    if (node.isReferenceRecord(item.DataTable))
                                    {
                                        sw.WriteLine("        /// <summary>");
                                        sw.WriteLine("        /// ");
                                        sw.WriteLine("        /// </summary>");
                                        sw.WriteLine("        public IList<"+node.DataTable+"> "+node.referenceProperty+" { get; set; }");
                                    }
                                }

                                sw.WriteLine("    }");
                            }
                            else if (item.IsEnum())//枚举类型
                            {
                                sw.WriteLine("    /// <summary>");
                                sw.WriteLine("    /// " + item.FieldDescription + " 枚举类");
                                sw.WriteLine("    /// </summary>");
                                sw.WriteLine("    public enum "+item.DataTable);
                                sw.WriteLine("    {");
                                int count = 0;
                                foreach (var node in list)
                                {
                                    if (node.IsClassProperty(item.DataTable))
                                    {
                                        if (count != 0)
                                        {
                                            sw.WriteLine(",");
                                        }
                                        sw.WriteLine("");
                                        sw.WriteLine("        /// <summary>");
                                        sw.WriteLine("        /// " + item.FieldDescription + " " + node.FieldDescription);
                                        sw.WriteLine("        /// </summary>");
                                        sw.WriteLine("        [Description(\"" + node.FieldDescription + "\")]");
                                        sw.Write("        " + node.FieldName);
                                        count++;
                                    }
                                }
                                sw.WriteLine("");
                                sw.WriteLine("    }");
                            }
                            else if (item.IsComplexyType())//复合类型
                            {
                                sw.WriteLine("    /// <summary>");
                                sw.WriteLine("    /// " + item.FieldDescription + " 复合属性");
                                sw.WriteLine("    /// </summary>");
                                sw.WriteLine("    public partial class " + item.DataTable);
                                sw.WriteLine("    {");

                                int count = 0;
                                foreach (var node in list)
                                {
                                    //普通属性 以及外键属性
                                    if (node.IsClassProperty(item.DataTable))
                                    {
                                        if (count != 0)
                                            sw.WriteLine("");
                                        sw.WriteLine("        /// <summary>");
                                        sw.WriteLine("        /// " + node.FieldDescription);
                                        if (!String.IsNullOrWhiteSpace(node.DefaultValues))
                                            sw.WriteLine("        /// " + "默认值" + " " + node.DefaultValues);
                                        sw.WriteLine("        /// </summary>");

                                        if (node.Key == Key.FK)
                                        {
                                            sw.WriteLine("        public " + node.ReferenceDataTable + " " + node.FieldName.Substring(0, node.FieldName.Length - 2) + " { get; set; }");
                                        }
                                        else
                                        {
                                            sw.WriteLine("        public " + (node.IsNUll ? node.ConvertToNullable() : node.PropertyType) + " " + node.FieldName + " { get; set; }");
                                        }

                                        count++;
                                    }
                                }

                                //连接属性
                                foreach (var node in list)
                                {
                                    if (node.isReferenceRecord(item.DataTable))
                                    {
                                        sw.WriteLine("        /// <summary>");
                                        sw.WriteLine("        /// ");
                                        sw.WriteLine("        /// </summary>");
                                        sw.WriteLine("        public IList<" + node.DataTable + "> " + node.referenceProperty + " { get; set; }");
                                    }
                                }

                                sw.WriteLine("    }");
                            }
                            else
                            { }
                            sw.WriteLine("}");
                        }
                        fs.Close();
                        fs.Dispose();
                    }
                }
            }
        }
    }
}
