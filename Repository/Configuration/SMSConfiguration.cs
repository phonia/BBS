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
    /// SMS 配置类
    /// </summary>
    class SMSConfiguration:EntityTypeConfiguration<SMS>
    {
        public SMSConfiguration()
        {
            ToTable("SMS");
            HasKey(e=>e.Id);
            Property(e =>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            HasRequired(e=>e.User).WithMany(e=>e.SMSS).Map(e=>e.MapKey("UserId"));
            Property(e =>e.From).HasColumnName("From").HasColumnType("nvarchar(50)").IsRequired();
            Property(e =>e.Content).HasColumnName("Content").HasColumnType("nvarchar(250)").IsRequired();
            Property(e =>e.MessageType).HasColumnName("MessageType").HasColumnType("int").IsRequired();
        }
    }
}
