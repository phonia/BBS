using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure;

namespace BBS2._0.Models
{
    public class SysLog:EntityBase,IAggregateRoot
    {
        public Int32 Id { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public String Operator { get; set; }
        /// <summary>
        /// 操作信息
        /// </summary>
        public String Message { get; set; }
        /// <summary>
        /// 操作结果
        /// </summary>
        public String Result { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>
        public String Type { get; set; }
        /// <summary>
        /// 操作模块
        /// </summary>
        public String Module { get; set; }
        public DateTime CreateDate { get; set; }
    }
}