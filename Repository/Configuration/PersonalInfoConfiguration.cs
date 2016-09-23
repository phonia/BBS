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
            Property(e =>e.Name).HasColumnName("Name").HasColumnType("nvarchar(50)").IsRequired();
            Property(e =>e.Sex).HasColumnName("Sex").HasColumnType("int").IsRequired();
            Property(e =>e.Avatar).HasColumnName("Avatar").HasColumnType("varbinary(Max)").IsRequired();
            Property(e =>e.NativePlace).HasColumnName("NativePlace").HasColumnType("nvarchar(50)").IsOptional();
            Property(e =>e.Address).HasColumnName("Address").HasColumnType("nvarchar(50)").IsOptional();
            Property(e =>e.PostCodes).HasColumnName("PostCodes").HasColumnType("nvarchar(50)").IsOptional();
            Property(e =>e.MailBox).HasColumnName("MailBox").HasColumnType("nvarchar(50)").IsOptional();
            Property(e =>e.Telephone).HasColumnName("Telephone").HasColumnType("nvarchar(50)").IsOptional();
            Property(e =>e.Mobliephone).HasColumnName("Mobliephone").HasColumnType("nvarchar(50)").IsOptional();
            Property(e =>e.Page).HasColumnName("Page").HasColumnType("nvarchar(50)").IsOptional();
            Property(e =>e.Signature).HasColumnName("Signature").HasColumnType("nvarchar(250)").IsOptional();
        }
    }
}
