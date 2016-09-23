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
    /// 用户日志 实体类
    /// </summary>
    public partial class UserLog:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// 主键
        /// 自增
        /// </summary>
        public Int32 Id { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// 操作名称
        /// </summary>
        public String OperationName { get; set; }

        /// <summary>
        /// 操作资源
        /// </summary>
        public String OperationResources { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSucess { get; set; }

        /// <summary>
        /// 注释
        /// </summary>
        public String OperationMessage { get; set; }

        public Int32? CreateUserId { get; set; }

        public Int32? UpdateUserId { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

    }
}
