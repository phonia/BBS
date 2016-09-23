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
    /// OnLineInfo 配置类
    /// </summary>
    class OnLineInfoConfiguration:ComplexTypeConfiguration<OnLineInfo>
    {
        public OnLineInfoConfiguration()
        {
            Property(e =>e.IsOnLine).HasColumnName("IsOnLine").HasColumnType("bit").IsRequired();
            Property(e =>e.CurrentPage).HasColumnName("CurrentPage").HasColumnType("nvarchar(50)").IsOptional();
            Property(e =>e.CurrentPageTitle).HasColumnName("CurrentPageTitle").HasColumnType("nvarchar(50)").IsOptional();
            Property(e =>e.SessionId).HasColumnName("SessionId").HasColumnType("nvarchar(50)").IsOptional();
            Property(e =>e.UserAgent).HasColumnName("UserAgent").HasColumnType("nvarchar(50)").IsOptional();
            Property(e =>e.OperatingSystem).HasColumnName("OperatingSystem").HasColumnType("nvarchar(50)").IsOptional();
            Property(e =>e.TerminalType).HasColumnName("TerminalType").HasColumnType("nvarchar(50)").IsOptional();
            Property(e =>e.BrowserName).HasColumnName("BrowserName").HasColumnType("nvarchar(50)").IsOptional();
            Property(e =>e.BrowserVersion).HasColumnName("BrowserVersion").HasColumnType("nvarchar(50)").IsOptional();
        }
    }
}
