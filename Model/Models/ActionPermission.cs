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
    /// 功能权限 实体类
    /// </summary>
    public partial class ActionPermission:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// 主键
        /// 自增
        /// </summary>
        public Int32 Id { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 资源
        /// </summary>
        public String Content { get; set; }

        /// <summary>
        /// 用户组类型
        /// </summary>
        public UserGroupType UserGroupType { get; set; }

        /// <summary>
        /// 操作标识
        /// </summary>
        public ActionSign ActionSign { get; set; }

        public Int32? CreateUserId { get; set; }

        public Int32? UpdateUserId { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

    }
}
