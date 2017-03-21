using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure;

namespace BBS2._0.Models
{
    public class SysModule : EntityBase, IAggregateRoot
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String ModuleCode { get; set; }
        public String Description { get; set; }
        public bool IsLeaf { get; set; }
        public byte[] RowVersion { get; set; }
        public Int32? ParentId { get; set; }

        public SysModule Parent { get; set; }
        public List<SysModule> Children { get; set; }
        public List<SysModuleOperate> ModuleOperates { get; set; }
    }
}