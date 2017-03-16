using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBS2._0.ViewModel
{
    public class ModuleOperateDTO
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Url { get; set; }
        public String KeyCode { get; set; }
        public bool IsValid { get; set; }
        public Int32 ModuleId { get; set; }
        public String ModuleName { get; set; }
    }
}