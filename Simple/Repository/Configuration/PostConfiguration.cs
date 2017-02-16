using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Simple.Models;

namespace Simple.Repository.Configuration
{
    public class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            ToTable("Sys_post");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(e => e.CastTime).HasColumnName("CastTime").HasColumnType("DateTime").IsRequired();
            Property(e => e.Content).HasColumnName("Content").HasColumnType("nvarchar").IsRequired();
            Property(e => e.RowVersion).IsRowVersion();
            Property(e => e.Title).HasColumnName("Title").HasColumnType("nvarchar").IsRequired();
            HasRequired(e => e.Poster).WithMany().Map(e => e.MapKey("AccountId"));
            HasRequired(e => e.Section).WithMany(e => e.Posts).Map(e => e.MapKey("SetionId"));
        }
    }
}