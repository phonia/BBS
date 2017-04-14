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
    /// 角色权限 实体类
    /// </summary>
    public partial class RolePermission:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// 自增
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 权限编码
        /// </summary>
        public String PermissionCode { get; set; }

        /// <summary>
        /// 导航属性所属角色
        /// </summary>
        public Role Role { get; set; }
        /// <summary>
        /// 所属角色
        /// </summary>
        public Int32 RoleId { get; set; }

        public Int32? CreateUserId { get; set; }

        public Int32? UpdateUserId { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public byte[] RowVersion { get; set; }

        public bool IsDeleted { get; set; }
    }
}
