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
    /// 日志 实体类
    /// </summary>
    public partial class Log:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// 主键
        /// 自增
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

        /// <summary>
        /// 导航属性
        /// </summary>
        public User User { get; set; }

        public Int32? CreateUserId { get; set; }

        public Int32? UpdateUserId { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public byte[] RowVersion { get; set; }

        public bool IsDeleted { get; set; }
    }
}
