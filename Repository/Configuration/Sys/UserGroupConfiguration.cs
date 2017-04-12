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
    /// UserGroup 配置类
    /// </summary>
    class UserGroupConfiguration:EntityTypeConfiguration<UserGroup>
    {
        public UserGroupConfiguration()
        {
            ToTable("Sys_UserGroup");
            HasKey(e=>e.Id);
            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            Property(e =>e.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
        }
    }
}
