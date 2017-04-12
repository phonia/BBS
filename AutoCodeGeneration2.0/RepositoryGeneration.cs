using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoCodeGeneration2._0
{
    public class RepositoryGeneration
    {
        /// <summary>
        /// 自动化仓储代码 不采取直接覆盖的更新方式
        /// </summary>
        /// <param name="list"></param>
        /// <param name="destination"></param>
        public void GenerateCode(List<DataRecord> list, String destination)
        {
            if (list != null)
            {
                foreach (var item in list)
                {
                    if (item.CanPersist())
                    {
                        if (!Directory.Exists(destination + "\\" + item.DomainName))//如果不存在就创建file文件夹
                        {
                            Directory.CreateDirectory(destination + "\\" + item.DomainName);
                        }
                        if (File.Exists(destination + "\\" + item.DomainName + "\\" + item.ClassName + "Repository.cs")) continue;
                        FileStream fs = new FileStream(destination + "\\" + item.DomainName + "\\" + item.ClassName + "Repository.cs", FileMode.CreateNew);
                        using (var sw = new StreamWriter(fs))
                        {
                            sw.WriteLine("/*=============================================================");
                            sw.WriteLine(" * ===============auto-generated code           ===============");
                            sw.WriteLine(" * ===============Should Be Marked if modified=================");
                            sw.WriteLine(" * ==========================================================*/");
                            sw.WriteLine("");
                            sw.WriteLine("using System;");
                            sw.WriteLine("using System.Collections.Generic;");
                            sw.WriteLine("using System.Linq;");
                            sw.WriteLine("using System.Text;");
                            sw.WriteLine("using Infrastructure;");
                            sw.WriteLine("using Model;");
                            sw.WriteLine("");
                            sw.WriteLine("namespace Repository");
                            sw.WriteLine("{");
                            sw.WriteLine("    /// <summary>");
                            sw.WriteLine("    /// " + item.ClassName + " 仓储实现");
                            sw.WriteLine("    /// </summary>");
                            sw.WriteLine("    public class " + item.ClassName + "Repository : EFRepository<" + item.ClassName + ",Int32>,I" + item.ClassName + "Repository");//默认的主键Id是类型是Int32型
                            sw.WriteLine("    {");
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
}
