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
    /// 投票记录 实体类
    /// </summary>
    public partial class VoteRecord:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// 主键
        /// 自增
        /// </summary>
        public Int32 Id { get; set; }

        /// <summary>
        /// 投票选项
        /// </summary>
        public VoteItem VoteItem { get; set; }

        /// <summary>
        /// 所属帖子
        /// </summary>
        public Post Post { get; set; }

        /// <summary>
        /// 投票人
        /// </summary>
        public User User { get; set; }

        public Int32? CreateUserId { get; set; }

        public Int32? UpdateUserId { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

    }
}