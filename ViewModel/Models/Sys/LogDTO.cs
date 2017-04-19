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
    /// 日志 视图模型
    /// </summary>
    public partial class LogDTO
    {

        /// <summary>
        /// 主键Id
        /// </summary>
        public Int32 Id { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public String ModuleName { get; set; }

        /// <summary>
        /// 操作名称
        /// </summary>
        public String OperateName { get; set; }

        /// <summary>
        /// 操作数据
        /// </summary>
        public String Content { get; set; }

        /// <summary>
        /// 操作结果
        /// </summary>
        public String Result { get; set; }

        /// <summary>
        /// 记录事件
        /// </summary>
        public DateTime RecordTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Note { get; set; }

        /// <summary>
        /// 操作员
        /// </summary>
        public Int32 UserId { get; set; }
    }
}
