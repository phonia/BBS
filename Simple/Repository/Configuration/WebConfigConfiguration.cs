using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Simple.Models;

namespace Simple.Repository.Configuration
{
    public class WebConfigConfiguration : EntityTypeConfiguration<WebConfig>
    {
        public WebConfigConfiguration()
        {
            ToTable("Sys_webconfig");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("Id").HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
        }
    }
}