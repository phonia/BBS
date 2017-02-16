using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure;

namespace Simple.Models
{
    //帖子
    public class Post:EntityBase,IAggregateRoot
    {
        public Int32 Id { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }//只能保存文字内容
        public DateTime CastTime { get; set; }
        public byte[] RowVersion { get; set; }//并行标识

        public User Poster { get; set; }//发布者
        public List<Reply> Replies { get; set; }//回复
        public Section Section { get; set; }//所属板块
    }
}