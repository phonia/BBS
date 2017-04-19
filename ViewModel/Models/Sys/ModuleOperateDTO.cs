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
    /// 模块操作 视图模型
    /// </summary>
    public partial class ModuleOperateDTO
    {

        /// <summary>
        /// 主键Id
        /// </summary>
        public Int32 Id { get; set; }

        /// <summary>
        /// 操作名称(中)
        /// </summary>
        public String OperateName { get; set; }

        /// <summary>
        /// 操作编码
        /// </summary>
        public String OperateCode { get; set; }

        /// <summary>
        /// 权限编码
        /// </summary>
        public String PermissionCode { get; set; }

        /// <summary>
        /// 所属模块
        /// </summary>
        public Int32 ModuleId { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; }
    }
}
