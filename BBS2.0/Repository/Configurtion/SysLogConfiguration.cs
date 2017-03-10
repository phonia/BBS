using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BBS2._0.Models;

namespace BBS2._0.Repository
{
    public class SysLogConfiguration:EntityTypeConfiguration<SysLog>
    {
        public SysLogConfiguration()
        {
            ToTable("Sys_Log");
            HasKey(e => e.Id);
            Property(e => e.CreateDate).HasColumnName("CreateDate").HasColumnType("DateTime").IsRequired();
            Property(e => e.Id).HasColumnName("Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Message).HasColumnName("Message").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(e => e.Module).HasColumnName("Module").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(e => e.Operator).HasColumnName("Operator").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(e => e.Result).HasColumnName("Result").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(e => e.Type).HasColumnName("Type").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
        }
    }
}