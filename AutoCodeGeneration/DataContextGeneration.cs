using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoCodeGeneration
{
    public class DataContextGeneration
    {
        public void GenerateCode(List<DataRecord> list, String destination)
        {
            if (list != null)
            {
                FileStream fs = new FileStream(destination + "\\DataContext.cs", FileMode.Create);
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine("/*==================================================");
                    sw.WriteLine("//============auto-generated code===================");
                    sw.WriteLine("//============not modified please===================");
                    sw.WriteLine("//================================================*/");
                    sw.WriteLine("");
                    sw.WriteLine("using System;");
                    sw.WriteLine("using System.Collections.Generic;");
                    sw.WriteLine("using System.Data.Entity;");
                    sw.WriteLine("using System.Linq;");
                    sw.WriteLine("using System.Text;");
                    sw.WriteLine("using Model;");
                    sw.WriteLine("");
                    sw.WriteLine("namespace Repository");
                    sw.WriteLine("{");
                    sw.WriteLine("    public class DataContext:DbContext,IDisposable");
                    sw.WriteLine("    {");
                    sw.WriteLine("");
                    sw.WriteLine("        public DataContext() : base(\"DataContext\") { ");
                    sw.WriteLine("			base.Configuration.LazyLoadingEnabled = false;");
                    sw.WriteLine("		}");
                    sw.WriteLine("");
                    sw.WriteLine("        public DataContext(String connectionStrings) : base(connectionStrings) { }");
                    sw.WriteLine("");
                    foreach (var item in list)
                    {
                        if (!item.IsClassRecord(list)) continue;
                        if (item.IsEnum()) continue;
                        if (item.IsComplexyType()) continue;

                        sw.WriteLine("        /// <summary>");
                        sw.WriteLine("        /// "+item.DataTable+" 集合");
                        sw.WriteLine("        /// </summary>");
                        sw.WriteLine("        public DbSet<"+item.DataTable+"> "+item.DataTable+"s { get; set; }");
                        sw.WriteLine("");
                    }
                    sw.WriteLine("        protected override void OnModelCreating(DbModelBuilder modelBuilder)");
                    sw.WriteLine("        {");
                    foreach (var item in list)
                    {
                        if (!item.IsClassRecord(list)) continue;
                        if (item.IsEnum()) continue;
                        if (item.IsComplexyType()) continue;

                        sw.WriteLine("            modelBuilder.Configurations.Add(new " + item.DataTable + "Configuration());");
                    }
                    sw.WriteLine("            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());");
                    sw.WriteLine("        }");
                    sw.WriteLine("");
                    sw.WriteLine("        public static void InitDataBase()");
                    sw.WriteLine("        {");
                    sw.WriteLine("            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());");
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
