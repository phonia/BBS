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
    /// ActionPermission 配置类
    /// </summary>
    class ActionPermissionConfiguration:EntityTypeConfiguration<ActionPermission>
    {
        public ActionPermissionConfiguration()
        {
            ToTable("ActionPermission");
            HasKey(e=>e.Id);
            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            Property(e =>e.Name).HasColumnName("Name").HasColumnType("nvarchar(50)").IsRequired();
            Property(e =>e.Content).HasColumnName("Content").HasColumnType("nvarchar(250)").IsRequired();
            Property(e =>e.UserGroupType).HasColumnName("UserGroupType").HasColumnType("int").IsRequired();
            HasRequired(e=>e.ActionSign).WithMany().Map(e=>e.MapKey("ActionSignId"));
        }
    }
}
