using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBS2._0.ViewModel
{
    public class ModuleDTO
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        //public String Url { get; set; }
        public String ModuleCode { get; set; }
        public String Description { get; set; }
        public bool IsLeaf { get; set; }
        public Int32 ParentId { get; set; }
    }
}