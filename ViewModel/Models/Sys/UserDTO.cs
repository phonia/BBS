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
    /// 用户 视图模型
    /// </summary>
    public partial class UserDTO
    {

        /// <summary>
        /// 主键Id
        /// </summary>
        public Int32 Id { get; set; }

        /// <summary>
        /// 账户
        /// </summary>
        public String AccountName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public String AccountPassword { get; set; }

        /// <summary>
        /// 所属角色
        /// </summary>
        public Int32 RoleId { get; set; }

        /// <summary>
        /// 所属用户组
        /// </summary>
        public Int32 UserGroupId { get; set; }
    }
}
