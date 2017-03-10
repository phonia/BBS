using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBS2._0.Models;
using Infrastructure;

namespace BBS2._0.Repository
{
    public class SysExceptionRepository:EFRepository<SysException,Int32>,ISysExceptionRepository
    {
    }
}
