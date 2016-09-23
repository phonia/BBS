using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCodeGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DataRecord> list = DataDictionary.GetDataDictionary(@"E:\Code\BBS\数据原典.xls");
            EntityGeneration entityGeneration = new EntityGeneration();
            entityGeneration.GenerateCode(list, @"E:\Code\BBS\Model\Models");

            IRepositoryGeneration interfaceOfRepository = new IRepositoryGeneration();
            interfaceOfRepository.GenerateCode(list, @"E:\Code\BBS\Model\IRepository");

            EFConfigurationGeneration efConfigurationGeneration = new EFConfigurationGeneration();
            efConfigurationGeneration.GenerateCode(list, @"E:\Code\BBS\Repository\Configuration");

            DataContextGeneration dataContextGeneration = new DataContextGeneration();
            dataContextGeneration.GenerateCode(list, @"E:\Code\BBS\Repository");
        }
    }
}
