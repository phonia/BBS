using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Infrastructure;

namespace BBS2._0.Repository
{
    public interface IEFUnitOfWork : IUnitOfWork
    {
        DbContext DbContext { get; }
    }
}
