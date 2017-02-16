using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Simple.Models;

namespace Simple.Repository.Configuration
{
    public class ReplyConfiguration : EntityTypeConfiguration<Reply>
    {
        public ReplyConfiguration()
        {
            ToTable("Sys_reply");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(e => e.Content).HasColumnName("Content").HasColumnType("nvarchar").IsRequired();
            Property(e => e.Level).HasColumnName("Level").HasColumnType("int").IsRequired();
            Property(e => e.ReplyTime).HasColumnName("ReplyTime").HasColumnType("DateTime").IsRequired();
            //HasRequired(e => e.Replyer).WithMany(e=>e.Replies).Map(e => e.MapKey("ReplayerId"));
            HasRequired(e => e.Replayer).WithMany().Map(e => e.MapKey("ReplayerId"));
            HasRequired(e => e.Belong).WithMany(e => e.Replies).Map(e => e.MapKey("PostId"));
        }
    }
}