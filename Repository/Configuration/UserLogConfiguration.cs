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
    /// UserLog 配置类
    /// </summary>
    class UserLogConfiguration:EntityTypeConfiguration<UserLog>
    {
        public UserLogConfiguration()
        {
            ToTable("UserLog");
            HasKey(e=>e.Id);
            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            HasRequired(e=>e.User).WithMany(e=>e.UserLogs).Map(e=>e.MapKey("UserId"));
            Property(e =>e.OperationName).HasColumnName("OperationName").HasColumnType("nvarchar(50)").IsRequired();
            Property(e =>e.OperationResources).HasColumnName("OperationResources").HasColumnType("nvarchar(50)").IsRequired();
            Property(e =>e.IsSucess).HasColumnName("IsSucess").HasColumnType("bit").IsRequired();
            Property(e =>e.OperationMessage).HasColumnName("OperationMessage").HasColumnType("nvarchar(250)").IsRequired();
        }
    }
}
