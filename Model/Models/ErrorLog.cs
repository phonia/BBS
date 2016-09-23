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
    /// 错误日志 实体类
    /// </summary>
    public partial class ErrorLog:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// 主键
        /// 自增
        /// </summary>
        public Int32 Id { get; set; }

        /// <summary>
        /// 出错时间
        /// </summary>
        public DateTime ErrTime { get; set; }

        /// <summary>
        /// 浏览器版本
        /// </summary>
        public String BrowerVersion { get; set; }

        /// <summary>
        /// 浏览器
        /// </summary>
        public String BrowserType { get; set; }

        /// <summary>
        /// IP
        /// </summary>
        public String Ip { get; set; }

        /// <summary>
        /// 异常页面
        /// </summary>
        public String PageUrl { get; set; }

        /// <summary>
        /// 异常消息
        /// </summary>
        public String ErrMessage { get; set; }

        /// <summary>
        /// 异常源
        /// </summary>
        public String ErrSource { get; set; }

        /// <summary>
        /// 堆栈轨迹
        /// </summary>
        public String StackTrace { get; set; }

        /// <summary>
        /// 帮助连接
        /// </summary>
        public String HelpLink { get; set; }

        /// <summary>
        /// 错误类型
        /// </summary>
        public ErrorLogType ErrorLogType { get; set; }

        public Int32? CreateUserId { get; set; }

        public Int32? UpdateUserId { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

    }
}
