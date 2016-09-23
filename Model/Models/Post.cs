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
    /// 帖子 实体类
    /// </summary>
    public partial class Post:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// 主键
        /// 自增
        /// </summary>
        public Int32 Id { get; set; }

        /// <summary>
        /// 版块
        /// </summary>
        public Section Section { get; set; }

        /// <summary>
        /// 发帖人
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// 帖子类型
        /// </summary>
        public PostType PostType { get; set; }

        /// <summary>
        /// 帖子状态
        /// </summary>
        public PostState PostState { get; set; }

        /// <summary>
        /// 标签--用"|"相隔
        /// </summary>
        public String PostLable { get; set; }

        /// <summary>
        /// 帖子标题
        /// </summary>
        public String PostTitle { get; set; }

        /// <summary>
        /// 赏金
        /// </summary>
        public Int32 ScoreReward { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public String Content { get; set; }

        /// <summary>
        /// 回复总数
        /// </summary>
        public Int32 ReplyAmount { get; set; }

        /// <summary>
        /// 浏览总数
        /// </summary>
        public Int32 ScanAmount { get; set; }

        /// <summary>
        /// 推荐
        /// </summary>
        public bool IsRecommand { get; set; }

        /// <summary>
        /// 置顶
        /// </summary>
        public bool isTop { get; set; }

        /// <summary>
        /// 精华帖
        /// </summary>
        public bool isEssence { get; set; }

        /// <summary>
        /// 阅读权限
        /// </summary>
        public Int32 ReadPemission { get; set; }

        /// <summary>
        /// 最后回复
        /// </summary>
        public Reply FinalReply { get; set; }

        public Int32? CreateUserId { get; set; }

        public Int32? UpdateUserId { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<Reply> Replies { get; set; }
    }
}
