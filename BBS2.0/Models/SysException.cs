using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure;

namespace BBS2._0.Models
{
    public class SysException:EntityBase,IAggregateRoot
    {
        public string Id { get; set; }
        /// <summary>
        /// 帮助连接
        /// </summary>
        public string HelpLink { get; set; }
        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// 堆栈
        /// </summary>
        public string StackTrace { get; set; }
        /// <summary>
        /// 目标页
        /// </summary>
        public string TargetSite { get; set; }
        /// <summary>
        /// 程序集
        /// </summary>
        public string Data { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}