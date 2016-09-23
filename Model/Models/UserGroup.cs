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
    /// 用户组 实体类
    /// </summary>
    public partial class UserGroup:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// 主键
        /// 自增
        /// </summary>
        public Int32 Id { get; set; }

        /// <summary>
        /// 用户组名
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 用户组类型
        /// </summary>
        public UserGroupType UserGroupType { get; set; }

        /// <summary>
        /// 阅读权限
        /// </summary>
        public Int32 ReadPermission { get; set; }

        /// <summary>
        /// 用户组等级
        /// </summary>
        public Int32 UserGroupDegree { get; set; }

        /// <summary>
        /// 用户权限--格式如1|2|3|4
        /// </summary>
        public String UserPemission { get; set; }

        public Int32? CreateUserId { get; set; }

        public Int32? UpdateUserId { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<User> Users { get; set; }
    }
}
