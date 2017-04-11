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
    /// AccountInfo 配置类
    /// </summary>
    class AccountInfoConfiguration:ComplexTypeConfiguration<AccountInfo>
    {
        public AccountInfoConfiguration()
        {
            Property(e =>e.RegisterDate).HasColumnName("RegisterDate").HasColumnType("datetime").IsRequired();
            Property(e =>e.RegisterIp).HasColumnName("RegisterIp").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(e =>e.LoginDate).HasColumnName("LoginDate").HasColumnType("datetime").IsRequired();
            Property(e =>e.LoginIP).HasColumnName("LoginIP").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(e =>e.LoginCount).HasColumnName("LoginCount").HasColumnType("int").IsRequired();
        }
    }
}
