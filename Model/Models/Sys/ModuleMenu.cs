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
    /// 模块目录 实体类
    /// </summary>
    public partial class ModuleMenu:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// 自增
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 目录名
        /// </summary>
        public String MenuName { get; set; }
        /// <summary>
        /// 目录编码
        /// </summary>
        public String MenuCode { get; set; }
        /// <summary>
        /// 目录是否可见
        /// </summary>
        public bool IsVisible { get; set; }
        /// <summary>
        /// 是否是页面
        /// </summary>
        public bool IsPage { get; set; }
        /// <summary>
        /// url
        /// </summary>
        public String URL { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        /// 导航属性所属模型
        /// </summary>
        public Module Module { get; set; }
        /// <summary>
        /// 所属模型
        /// </summary>
        public Int32 ModuleId { get; set; }

        public Int32? CreateUserId { get; set; }

        public Int32? UpdateUserId { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public byte[] RowVersion { get; set; }

        public bool IsDeleted { get; set; }
    }
}
