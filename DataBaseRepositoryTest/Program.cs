using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository;

namespace DataBaseRepositoryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var data = new DataContext())
            //{
            //}
            WebConfigRepository wr = new WebConfigRepository();
            EFUnitOfWork ef = new EFUnitOfWork();
            wr.UnitOfWork = ef;
            wr.Add(new Model.WebConfig() { IsInitialed = true });
            ef.Commit();
        }
    }
}
