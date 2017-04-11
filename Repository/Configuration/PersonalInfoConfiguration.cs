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
    /// PersonalInfo 配置类
    /// </summary>
    class PersonalInfoConfiguration:ComplexTypeConfiguration<PersonalInfo>
    {
        public PersonalInfoConfiguration()
        {
            Property(e =>e.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(e =>e.Sex).HasColumnName("Sex").HasColumnType("int").IsRequired();
            Property(e =>e.Age).HasColumnName("Age").HasColumnType("int").IsRequired();
            Property(e =>e.Email).HasColumnName("Email").HasColumnType("nvarchar").HasMaxLength(50).IsOptional();
            Property(e =>e.Tel).HasColumnName("Tel").HasColumnType("nvarchar").HasMaxLength(50).IsOptional();
            Property(e =>e.Phone).HasColumnName("Phone").HasColumnType("nvarchar").HasMaxLength(50).IsOptional();
            Property(e =>e.Fax).HasColumnName("Fax").HasColumnType("nvarchar").HasMaxLength(50).IsOptional();
        }
    }
}
