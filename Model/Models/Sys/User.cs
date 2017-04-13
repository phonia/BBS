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
    /// 用户 实体类
    /// </summary>
    public partial class User:EntityBase,IAggregateRoot
    {

        /// <summary>
        /// 导航属性用户
        /// </summary>
        public IList<Log> Logs { get; set; }
        /// <summary>
        /// 主键Id
        /// 自增
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 账户
        /// </summary>
        public String AccountName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public String AccountPassword { get; set; }
        /// <summary>
        /// 个人信息
        /// </summary>
        public PersonalInfo PersonalInfo { get; set; }
        /// <summary>
        /// 账户信息
        /// </summary>
        public AccountInfo AccountInfo { get; set; }

        /// <summary>
        /// 导航属性所属角色
        /// </summary>
        public Role Role { get; set; }
        /// <summary>
        /// 所属角色
        /// </summary>
        public Int32 RoleId { get; set; }

        /// <summary>
        /// 导航属性所属用户组
        /// </summary>
        public UserGroup UserGroup { get; set; }
        /// <summary>
        /// 所属用户组
        /// </summary>
        public Int32 UserGroupId { get; set; }

        public Int32? CreateUserId { get; set; }

        public Int32? UpdateUserId { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public byte[] RowVersion { get; set; }

        public bool IsDeleted { get; set; }
    }
}
