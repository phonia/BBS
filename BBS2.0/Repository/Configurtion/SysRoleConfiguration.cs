using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BBS2._0.Models;

namespace BBS2._0.Repository
{
    public class SysRoleConfiguration:EntityTypeConfiguration<SysRole>
    {
        public SysRoleConfiguration()
        {
            ToTable("Sys_Role");
            HasKey(e => e.Id);
            Property(e => e.Description).HasColumnName("Description").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(e => e.Id).HasColumnName("Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Name).HasColumnName("Name").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(e => e.RowVersion).IsRowVersion();
        }
    }
}