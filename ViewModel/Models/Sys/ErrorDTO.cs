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
    /// 异常 视图模型
    /// </summary>
    public partial class ErrorDTO
    {

        /// <summary>
        /// 主键Id
        /// </summary>
        public Int32 Id { get; set; }

        /// <summary>
        /// 异常类型
        /// </summary>
        public ErrorTypeDTO ErrType { get; set; }

        /// <summary>
        /// 异常时间
        /// </summary>
        public DateTime ErrTime { get; set; }

        /// <summary>
        /// 浏览器版本
        /// </summary>
        public String BrowersVersion { get; set; }

        /// <summary>
        /// 浏览器类型
        /// </summary>
        public String BrowserType { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public String IP { get; set; }

        /// <summary>
        /// 请求路径URL
        /// </summary>
        public String Router { get; set; }

        /// <summary>
        /// 异常消息
        /// </summary>
        public String ErrMessage { get; set; }

        /// <summary>
        /// 异常源
        /// </summary>
        public String ErrSource { get; set; }

        /// <summary>
        /// 异常轨迹
        /// </summary>
        public String StackTrace { get; set; }

        /// <summary>
        /// 帮助链接
        /// </summary>
        public String Helplink { get; set; }
    }
}
