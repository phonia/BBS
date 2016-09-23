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
            ToTable("UserGroup");
            HasKey(e=>e.Id);
            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            Property(e =>e.Name).HasColumnName("Name").HasColumnType("nvarchar(50)").IsRequired();
            Property(e =>e.UserGroupType).HasColumnName("UserGroupType").HasColumnType("int").IsRequired();
            Property(e =>e.ReadPermission).HasColumnName("ReadPermission").HasColumnType("int").IsRequired();
            Property(e =>e.UserGroupDegree).HasColumnName("UserGroupDegree").HasColumnType("int").IsRequired();
            Property(e =>e.UserPemission).HasColumnName("UserPemission").HasColumnType("nvarchar(250)").IsOptional();
        }
    }
}
