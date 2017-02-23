using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using BBS2._0.Models;

namespace BBS2._0.Repository
{
    public class AccountConfiguration:EntityTypeConfiguration<Account>
    {
        public AccountConfiguration()
        {
            ToTable("Sys_Account");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.AccountType).HasColumnName("AccountType").HasColumnType("int").IsRequired();
            Property(e => e.Age).HasColumnName("Age").HasColumnType("int").IsRequired();
            Property(e => e.Email).HasColumnName("Email").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(e => e.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(20).IsRequired();
            Property(e => e.Password).HasColumnName("Password").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(e => e.Sex).HasColumnName("Sex").HasColumnType("int").IsRequired();
            Property(e => e.Tel).HasColumnName("Tel").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
        }
    }
}