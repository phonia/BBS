using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBS2._0.Repository
{
    public class DataContextFactory
    {
        internal static System.Data.Entity.DbContext GetInstance()
        {
            return new DataContext();
        }
    }
}