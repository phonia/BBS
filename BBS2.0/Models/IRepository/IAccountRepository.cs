﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure;

namespace BBS2._0.Models
{
    public interface IAccountRepository:IRepository<Account,Int32>
    {
    }
}
