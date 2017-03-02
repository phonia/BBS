using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BBS2._0.Models;

namespace BBS2._0.Repository
{
    public class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            ToTable("Sys_post");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Keyword).HasColumnName("Keyword").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(e => e.PublicTime).HasColumnName("PublicTime").HasColumnType("DateTime").IsRequired();
            Property(e => e.RowVersion).IsRowVersion();
            Property(e => e.Title).HasColumnName("Title").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(e => e.ScanAccount).HasColumnName("ScanAccount").HasColumnType("int").IsRequired();
            HasRequired(e => e.Poster).WithMany().HasForeignKey(e => e.PosterId);//.Map(e => e.MapKey("PosterId"));
            HasRequired(e => e.Section).WithMany(e => e.Posts).HasForeignKey(e => e.SectionId);//.Map(e => e.MapKey("SectionId"));
        }
    }
}