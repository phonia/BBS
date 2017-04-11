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
    /// 模块-领域服务 实体类
    /// </summary>
    public partial class ModuleService:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// 主键
        /// 自增
        /// </summary>
        public Int32 Id { get; set; }

        /// <summary>
        /// 所属操作
        /// </summary>
        public Int32 ModuleOperateId { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public Module ModuleOperate { get; set; }

        /// <summary>
        /// 所属服务方法
        /// </summary>
        public Int32 ServiceMethodId { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public Service ServiceMethod { get; set; }

        public Int32? CreateUserId { get; set; }

        public Int32? UpdateUserId { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public byte[] RowVersion { get; set; }

        public bool IsDeleted { get; set; }
    }
}
