using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoCodeGeneration2._0
{
    public class IRepositoryGeneration
    {
        /// <summary>
        /// 自动化仓储接口代码 不采取直接覆盖的更新方式
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
                        if (File.Exists(destination + "\\" + item.DomainName + "\\I" + item.ClassName + "Repository.cs"))
                            continue;
                        FileStream fs = new FileStream(destination + "\\" + item.DomainName + "\\I" + item.ClassName + "Repository.cs", FileMode.CreateNew);
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
                            sw.WriteLine("");
                            sw.WriteLine("namespace Model");
                            sw.WriteLine("{");
                            sw.WriteLine("    /// <summary>");
                            sw.WriteLine("    /// " + item.ClassName + " 仓储接口");
                            sw.WriteLine("    /// </summary>");
                            sw.WriteLine("    public interface I" + item.ClassName + "Repository : IRepository<" + item.ClassName + ",Int32>");//默认的主键Id是类型是Int32型
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
