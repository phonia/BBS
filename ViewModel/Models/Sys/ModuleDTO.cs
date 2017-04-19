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
    /// 模块 视图模型
    /// </summary>
    public partial class ModuleDTO
    {

        /// <summary>
        /// 主键Id
        /// </summary>
        public Int32 Id { get; set; }

        /// <summary>
        /// 名称（中）
        /// </summary>
        public String NameCH { get; set; }

        /// <summary>
        /// 模块编码
        /// </summary>
        public String ModuleCode { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        public Int32 ParentId { get; set; }
    }
}
