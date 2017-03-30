using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBS2._0.ViewModel
{
    public class RolePermissonDTO
    {
        public Int32 Id { get; set; }
        public Int32? ModuleId { get; set; }
        public Int32? OperateId { get; set; }
        public String ModuleName { get; set; }
        public String OperateName { get; set; }
        public String KeyCode { get; set; }
        public bool IsOwned { get; set; }
        public bool IsModule { get; set; }
        public Int32? ParentId { get; set; }
        public List<RolePermissonDTO> children { get; set; }//children 首字母大写会不会受影响...
    }
}