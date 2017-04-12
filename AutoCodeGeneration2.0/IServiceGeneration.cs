using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoCodeGeneration2._0
{
    public class IServiceGeneration
    {
        public void GenerateCode(List<DataRecord> list, String destination)
        {
            if (list != null)
            {
                foreach (var item in list)
                {
                    if (!item.CanPersist()) continue;
                    if (File.Exists(destination+"\\I"+item.ClassName+"Services.cs")) continue;

                    FileStream fs = new FileStream(destination + "\\I" + item.ClassName + "Services.cs", FileMode.CreateNew);
                    using (var sw = new StreamWriter(fs))
                    {
                        fs.Close();
                        fs.Dispose();
                    }
                }
            }
        }
    }
}
