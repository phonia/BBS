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
    /// Attachment 配置类
    /// </summary>
    class AttachmentConfiguration:EntityTypeConfiguration<Attachment>
    {
        public AttachmentConfiguration()
        {
            ToTable("Attachment");
            HasKey(e=>e.Id);
            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            Property(e =>e.AttachmentType).HasColumnName("AttachmentType").HasColumnType("int").IsRequired();
            Property(e =>e.Content).HasColumnName("Content").HasColumnType("nvarchar(250)").IsRequired();
            Property(e =>e.Reward).HasColumnName("Reward").HasColumnType("int").IsRequired();
            Property(e =>e.DownloadAmount).HasColumnName("DownloadAmount").HasColumnType("int").IsRequired();
            HasRequired(e=>e.Post).WithMany().Map(e=>e.MapKey("PostId"));
            HasRequired(e=>e.Reply).WithMany().Map(e=>e.MapKey("ReplyId"));
        }
    }
}
