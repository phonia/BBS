using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure;

namespace BBS2._0.Models
{
    public class SysRole:EntityBase,IAggregateRoot
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public byte[] RowVersion { get; set; }

        public List<Account> Accounts { get; set; }
        public List<SysFunctionRight> FunctionRights { get; set; }
    }
}