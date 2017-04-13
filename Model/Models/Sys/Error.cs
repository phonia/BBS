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
    /// 异常 实体类
    /// </summary>
    public partial class Error:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// 自增
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 异常类型
        /// </summary>
        public ErrorType ErrType { get; set; }
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

        public Int32? CreateUserId { get; set; }

        public Int32? UpdateUserId { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public byte[] RowVersion { get; set; }

        public bool IsDeleted { get; set; }
    }
}
