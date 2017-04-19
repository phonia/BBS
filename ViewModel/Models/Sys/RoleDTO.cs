/*=============================================================
 * ===============auto-generated code           ===============
 * ===============Should Be Marked if modified=================
 * ==========================================================*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ViewModel
{
    /// <summary>
    /// 角色 视图模型
    /// </summary>
    public partial class RoleDTO
    {

        /// <summary>
        /// 主键Id
        /// </summary>
        public Int32 Id { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 角色类型
        /// </summary>
        public RoleTypeDTO RoleType { get; set; }
    }
}
