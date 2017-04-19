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
    /// 角色权限 视图模型
    /// </summary>
    public partial class RolePermissionDTO
    {

        /// <summary>
        /// 主键Id
        /// </summary>
        public Int32 Id { get; set; }

        /// <summary>
        /// 权限编码
        /// </summary>
        public String PermissionCode { get; set; }

        /// <summary>
        /// 所属角色
        /// </summary>
        public Int32 RoleId { get; set; }
    }
}
