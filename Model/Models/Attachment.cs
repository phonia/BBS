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
    /// 附件 实体类
    /// </summary>
    public partial class Attachment:EntityBase,IAggregateRoot
    {
        /// <summary>
        /// 主键Id
        /// 主键
        /// 自增
        /// </summary>
        public Int32 Id { get; set; }

        /// <summary>
        /// 附件类型--文件格式
        /// </summary>
        public AttachmentType AttachmentType { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public String Content { get; set; }

        /// <summary>
        /// 赏金
        /// </summary>
        public Int32 Reward { get; set; }

        /// <summary>
        /// 下载次数
        /// </summary>
        public Int32 DownloadAmount { get; set; }

        /// <summary>
        /// 所属帖子
        /// </summary>
        public Post Post { get; set; }

        /// <summary>
        /// 所属回复
        /// </summary>
        public Reply Reply { get; set; }

        public Int32? CreateUserId { get; set; }

        public Int32? UpdateUserId { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

    }
}
