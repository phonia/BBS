﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS2._0.Models;

namespace BBS2._0.Repository
{
    public class AccountRepository:EFRepository<Account,Int32>,IAccountRepository
    {
    }
}