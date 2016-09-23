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
    /// User 配置类
    /// </summary>
    class UserConfiguration:EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("User");
            HasKey(e=>e.Id);
            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            Property(e =>e.Account).HasColumnName("Account").HasColumnType("nvarchar(50)").IsRequired();
            Property(e =>e.Password).HasColumnName("Password").HasColumnType("nvarchar(50)").IsRequired();
            Property(e =>e.Score).HasColumnName("Score").HasColumnType("int").IsRequired();
            Property(e =>e.LoginTimes).HasColumnName("LoginTimes").HasColumnType("int").IsRequired();
            Property(e =>e.RegisterIP).HasColumnName("RegisterIP").HasColumnType("nvarchar(50)").IsOptional();
            Property(e =>e.RegisterTime).HasColumnName("RegisterTime").HasColumnType("DateTime").IsRequired();
            Property(e =>e.LastIP).HasColumnName("LastIP").HasColumnType("nvarchar(50)").IsOptional();
            Property(e =>e.LastTime).HasColumnName("LastTime").HasColumnType("DateTime").IsRequired();
            HasRequired(e=>e.UserGroup).WithMany(e=>e.Users).Map(e=>e.MapKey("UserGroupId"));
        }
    }
}
