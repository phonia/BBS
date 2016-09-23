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
    /// 投票选项 实体类
    /// </summary>
    public partial class VoteItem:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// 主键
        /// 自增
        /// </summary>
        public Int32 Id { get; set; }

        /// <summary>
        /// 选项内容
        /// </summary>
        public String Content { get; set; }

        /// <summary>
        /// 选项顺位
        /// </summary>
        public Int32 Sort { get; set; }

        /// <summary>
        /// 所属帖子
        /// </summary>
        public Post Post { get; set; }

        public Int32? CreateUserId { get; set; }

        public Int32? UpdateUserId { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

    }
}
