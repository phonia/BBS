using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBS2._0.Common;
using Infrastructure;

namespace BBS2._0.Models
{
    public class SysModuleOperate : EntityBase, IAggregateRoot
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public ModuleOperateCode OperateCode { get; set; }
        public String KeyCode { get; set; }
        public String Url { get; set; }
        public bool IsValid { get; set; }
        public byte[] RowVersion { get; set; }
        public Int32 ModuleId { get; set; }

        public SysModule Module { get; set; }
    }
}