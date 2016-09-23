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
    /// Reply 配置类
    /// </summary>
    class ReplyConfiguration:EntityTypeConfiguration<Reply>
    {
        public ReplyConfiguration()
        {
            ToTable("Reply");
            HasKey(e=>e.Id);
            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            HasRequired(e=>e.User).WithMany(e=>e.Replies).Map(e=>e.MapKey("UserId"));
            HasRequired(e=>e.Post).WithMany(e=>e.Replies).Map(e=>e.MapKey("PostId"));
            Property(e =>e.Content).HasColumnName("Content").HasColumnType("ntext").IsRequired();
            Property(e =>e.ReplyState).HasColumnName("ReplyState").HasColumnType("int").IsRequired();
        }
    }
}
