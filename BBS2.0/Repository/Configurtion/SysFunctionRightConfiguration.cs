using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BBS2._0.Models;

namespace BBS2._0.Repository
{
    public class SysFunctionRightConfiguration:EntityTypeConfiguration<SysFunctionRight>
    {
        public SysFunctionRightConfiguration()
        {
            ToTable("Sys_FunctionRight");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.KeyCode).HasColumnName("KeyCode").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(e => e.RowVersion).IsRowVersion();
            HasRequired(e => e.Role).WithMany(e => e.FunctionRights).HasForeignKey(e => e.RoleId);
        }
    }
}