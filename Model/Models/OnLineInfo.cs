/*==================================================
//============auto-generated code===================
//============not modified please===================
//================================================*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Infrastructure;

namespace Model
{
    /// <summary>
    /// 在线信息 复合属性
    /// </summary>
    public partial class OnLineInfo
    {
        /// <summary>
        /// 用户是否在线
        /// </summary>
        public bool IsOnLine { get; set; }

        /// <summary>
        /// 用户当前所在页面Url
        /// </summary>
        public String CurrentPage { get; set; }

        /// <summary>
        /// 用户当前所在页面名称
        /// </summary>
        public String CurrentPageTitle { get; set; }

        /// <summary>
        /// 用户SessionId
        /// </summary>
        public String SessionId { get; set; }

        /// <summary>
        /// 客户端UA
        /// </summary>
        public String UserAgent { get; set; }

        /// <summary>
        /// 操作系统
        /// </summary>
        public String OperatingSystem { get; set; }

        /// <summary>
        /// 终端类型（0=非移动设备，1=移动设备）
        /// </summary>
        public String TerminalType { get; set; }

        /// <summary>
        /// 浏览器名称
        /// </summary>
        public String BrowserName { get; set; }

        /// <summary>
        /// 浏览器的版本
        /// </summary>
        public String BrowserVersion { get; set; }
    }
}
