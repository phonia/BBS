using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure;

namespace BBS2._0.Models
{
    public class SysFunctionRight : EntityBase, IAggregateRoot
    {
        public Int32 Id { get; set; }
        public String KeyCode { get; set; }
//        public bool IsValid { get; set; }
        public byte[] RowVersion { get; set; }
        public Int32 RoleId { get; set; }

        public SysRole Role { get; set; }
    }
}