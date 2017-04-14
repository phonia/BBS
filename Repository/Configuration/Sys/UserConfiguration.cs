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
    public class UserConfiguration:EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Sys_User");
            HasKey(e=>e.Id);
            Property(e => e.RowVersion).IsRowVersion();
            Property(e =>e.Id).HasColumnName("Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(e =>e.AccountName).HasColumnName("AccountName").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(e =>e.AccountPassword).HasColumnName("AccountPassword").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            HasRequired(e=>e.Role).WithMany(e=>e.Users).HasForeignKey(e=>e.RoleId);
            HasRequired(e=>e.UserGroup).WithMany(e=>e.Users).HasForeignKey(e=>e.UserGroupId);
        }
    }
}
