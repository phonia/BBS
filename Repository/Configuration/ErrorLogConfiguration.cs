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
    /// ErrorLog 配置类
    /// </summary>
    class ErrorLogConfiguration:EntityTypeConfiguration<ErrorLog>
    {
        public ErrorLogConfiguration()
        {
            ToTable("ErrorLog");
            HasKey(e=>e.Id);
            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            Property(e =>e.ErrTime).HasColumnName("ErrTime").HasColumnType("datetime").IsRequired();
            Property(e =>e.BrowerVersion).HasColumnName("BrowerVersion").HasColumnType("nvarchar(50)").IsRequired();
            Property(e =>e.BrowserType).HasColumnName("BrowserType").HasColumnType("nvarchar(50)").IsRequired();
            Property(e =>e.Ip).HasColumnName("Ip").HasColumnType("nvarchar(50)").IsRequired();
            Property(e =>e.PageUrl).HasColumnName("PageUrl").HasColumnType("nvarchar(250)").IsRequired();
            Property(e =>e.ErrMessage).HasColumnName("ErrMessage").HasColumnType("nvarchar(250)").IsRequired();
            Property(e =>e.ErrSource).HasColumnName("ErrSource").HasColumnType("ntext").IsRequired();
            Property(e =>e.StackTrace).HasColumnName("StackTrace").HasColumnType("ntext").IsRequired();
            Property(e =>e.HelpLink).HasColumnName("HelpLink").HasColumnType("nvarchar(250)").IsRequired();
            Property(e =>e.ErrorLogType).HasColumnName("ErrorLogType").HasColumnType("int").IsRequired();
        }
    }
}
