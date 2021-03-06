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
    /// 模块 实体类
    /// </summary>
    public partial class Module:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// 自增
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 名称（中）
        /// </summary>
        public String NameCH { get; set; }
        /// <summary>
        /// 模块编码
        /// </summary>
        public String ModuleCode { get; set; }

        /// <summary>
        /// 导航属性父级
        /// </summary>
        public Module Parent { get; set; }
        /// <summary>
        /// 父级
        /// </summary>
        public Int32? ParentId { get; set; }

        /// <summary>
        /// 导航属性模块
        /// </summary>
        public IList<Module> Children { get; set; }

        /// <summary>
        /// 导航属性模块
        /// </summary>
        public IList<ModuleOperate> Operates { get; set; }

        public Int32? CreateUserId { get; set; }

        public Int32? UpdateUserId { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public byte[] RowVersion { get; set; }

        public bool IsDeleted { get; set; }
    }
}
