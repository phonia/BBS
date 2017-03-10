using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BBS2._0.Models;

namespace BBS2._0.Repository
{
    public class SysModuleConfiguration : EntityTypeConfiguration<SysModule>
    {
        public SysModuleConfiguration()
        {
            ToTable("Sys_Module");
            HasKey(e => e.Id);
            Property(e => e.Description).HasColumnName("Description").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(e => e.Id).HasColumnName("Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.IsLeaf).HasColumnName("IsLeaf").HasColumnType("bit").IsRequired();
            Property(e => e.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(e => e.RowVersion).IsRowVersion();
            Property(e => e.Url).HasColumnName("Url").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            HasMany(e => e.Children).WithOptional(e => e.Parent).HasForeignKey(e => e.ParentId);
        }
    }
}