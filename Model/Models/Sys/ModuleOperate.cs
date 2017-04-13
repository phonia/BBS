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
    /// 模块操作 实体类
    /// </summary>
    public partial class ModuleOperate:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// 自增
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 操作名称(中)
        /// </summary>
        public String OperateName { get; set; }
        /// <summary>
        /// 操作编码
        /// </summary>
        public String OperateCode { get; set; }
        /// <summary>
        /// 权限编码
        /// </summary>
        public String PermissionCode { get; set; }

        /// <summary>
        /// 导航属性所属模块
        /// </summary>
        public Module Module { get; set; }
        /// <summary>
        /// 所属模块
        /// </summary>
        public Int32 ModuleId { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; }

        public Int32? CreateUserId { get; set; }

        public Int32? UpdateUserId { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public byte[] RowVersion { get; set; }

        public bool IsDeleted { get; set; }
    }
}
