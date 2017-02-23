using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BBS2._0.Models;

namespace BBS2._0.Repository
{
    public class ReplyConfiguration : EntityTypeConfiguration<Reply>
    {
        public ReplyConfiguration()
        {
            ToTable("Sys_reply");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Level).HasColumnName("Level").HasColumnType("int").IsRequired();
            Property(e => e.ReplyTime).HasColumnName("ReplyTime").HasColumnType("DateTime").IsRequired();
            Property(e => e.Content).HasColumnName("Content").HasColumnType("nvarchar").IsRequired().HasMaxLength(250);
            HasRequired(e => e.Post).WithMany(e => e.Replies).Map(e => e.MapKey("PostId"));
            HasRequired(e => e.Replyer).WithMany().Map(e => e.MapKey("ReplyerId"));
        }
    }
}