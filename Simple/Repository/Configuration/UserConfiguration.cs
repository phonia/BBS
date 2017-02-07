using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Simple.Models;

namespace Simple.Repository.Configuration
{
    public class UserConfiguration:EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Sys_User");
            HasKey(e => e.Id);
            Property(e=>e.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnType("int").IsRequired();
            Property(e => e.Account).HasColumnName("Account").HasColumnType("nvarchar(50)").IsRequired();
            Property(e => e.AcountType).HasColumnName("AccountType").HasColumnType("nvarchar(50)").IsRequired();
            Property(e => e.Age).HasColumnName("Age").HasColumnType("int").IsRequired();
            Property(e => e.Email).HasColumnName("Email").HasColumnType("nvarchar(50)").IsRequired();
            Property(e => e.Password).HasColumnName("Password").HasColumnType("nvarchar(50)").IsRequired();
            Property(e => e.Sex).HasColumnName("Sex").HasColumnType("int").IsRequired();
            Property(e => e.Tel).HasColumnName("Tel").HasColumnType("nvarchar(50)").IsRequired();
        }
    }
}