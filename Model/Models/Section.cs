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
    /// 版块 实体类
    /// </summary>
    public partial class Section:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// 主键
        /// 自增
        /// </summary>
        public Int32 Id { get; set; }

        /// <summary>
        /// 版块名称
        /// </summary>
        public String SectionName { get; set; }

        /// <summary>
        /// 版块签名
        /// </summary>
        public String SectionSign { get; set; }

        /// <summary>
        /// 阅读用户组
        /// </summary>
        public String UserGroupId { get; set; }

        /// <summary>
        /// 帖子总数
        /// </summary>
        public Int32 PostAmount { get; set; }

        /// <summary>
        /// 查看总数
        /// </summary>
        public Int32 ScanAmount { get; set; }

        /// <summary>
        /// 回复总数
        /// </summary>
        public Int32 ReplyAmount { get; set; }

        /// <summary>
        /// 最后回复帖子
        /// </summary>
        public Post FinalPost { get; set; }

        /// <summary>
        /// 最后回复
        /// </summary>
        public Reply FinalReply { get; set; }

        /// <summary>
        /// 版主--1|2|3|4
        /// </summary>
        public String PostMaster { get; set; }

        public Int32? CreateUserId { get; set; }

        public Int32? UpdateUserId { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<Post> Posts { get; set; }
    }
}
