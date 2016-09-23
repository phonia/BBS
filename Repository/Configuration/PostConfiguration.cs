/*==================================================
//============auto-generated code===================
//============not modified please===================
//================================================*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using Model;

namespace Repository
{
    /// <summary>
    /// Post 配置类
    /// </summary>
    class PostConfiguration:EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            ToTable("Post");
            HasKey(e=>e.Id);
            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            HasRequired(e=>e.Section).WithMany(e=>e.Posts).Map(e=>e.MapKey("SectionId"));
            HasRequired(e=>e.User).WithMany(e=>e.Posts).Map(e=>e.MapKey("UserId"));
            Property(e =>e.PostType).HasColumnName("PostType").HasColumnType("int").IsRequired();
            Property(e =>e.PostState).HasColumnName("PostState").HasColumnType("int").IsRequired();
            Property(e =>e.PostLable).HasColumnName("PostLable").HasColumnType("nvarchar(250)").IsRequired();
            Property(e =>e.PostTitle).HasColumnName("PostTitle").HasColumnType("nvarchar(250)").IsRequired();
            Property(e =>e.ScoreReward).HasColumnName("ScoreReward").HasColumnType("int").IsRequired();
            Property(e =>e.Content).HasColumnName("Content").HasColumnType("ntext").IsRequired();
            Property(e =>e.ReplyAmount).HasColumnName("ReplyAmount").HasColumnType("int").IsRequired();
            Property(e =>e.ScanAmount).HasColumnName("ScanAmount").HasColumnType("int").IsRequired();
            Property(e =>e.IsRecommand).HasColumnName("IsRecommand").HasColumnType("bit").IsRequired();
            Property(e =>e.isTop).HasColumnName("isTop").HasColumnType("bit").IsRequired();
            Property(e =>e.isEssence).HasColumnName("isEssence").HasColumnType("bit").IsRequired();
            Property(e =>e.ReadPemission).HasColumnName("ReadPemission").HasColumnType("int").IsRequired();
            HasRequired(e=>e.FinalReply).WithMany().Map(e=>e.MapKey("FinalReplyId"));
        }
    }
}
