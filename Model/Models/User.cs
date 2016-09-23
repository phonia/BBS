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
        /// 主键Id
        /// 主键
        /// 自增
        /// </summary>
        public Int32 Id { get; set; }

        /// <summary>
        /// 账户
        /// </summary>
        public String Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public String Password { get; set; }

        /// <summary>
        /// 个人信息
        /// </summary>
        public PersonalInfo PersonalInfo { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        public Int32 Score { get; set; }

        /// <summary>
        /// 在线信息
        /// </summary>
        public OnLineInfo OnLineInfo { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>
        public Int32 LoginTimes { get; set; }

        /// <summary>
        /// 注册IP
        /// </summary>
        public String RegisterIP { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegisterTime { get; set; }

        /// <summary>
        /// 最后登录IP
        /// </summary>
        public String LastIP { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastTime { get; set; }

        /// <summary>
        /// 所属用户组
        /// </summary>
        public UserGroup UserGroup { get; set; }

        public Int32? CreateUserId { get; set; }

        public Int32? UpdateUserId { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<Post> Posts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<Reply> Replies { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<DailySignature> DaliySignatures { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<UserLog> UserLogs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<SMS> SMSS { get; set; }
    }
}
