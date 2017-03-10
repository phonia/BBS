using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BBS2._0.Models;

namespace BBS2._0.Repository
{
    public class SysExceptionConfiguration:EntityTypeConfiguration<SysException>
    {
        public SysExceptionConfiguration()
        {
            ToTable("Sys_Exception");
            HasKey(e => e.Id);
            Property(e => e.CreateTime).HasColumnName("CreateTime").HasColumnType("DateTime").IsRequired();
            Property(e => e.Data).HasColumnName("Data").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(e => e.HelpLink).HasColumnName("HelpLink").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(e => e.Message).HasColumnName("Message").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(e => e.Source).HasColumnName("Source").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(e => e.StackTrace).HasColumnName("StackTrace").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(e => e.TargetSite).HasColumnName("TargetSite").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
        }
    }
}