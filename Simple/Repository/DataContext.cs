/*==================================================
//============auto-generated code===================
//============not modified please===================
//================================================*/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Simple.Models;
using Simple.Repository.Configuration;

namespace Repository
{
    public class DataContext:DbContext,IDisposable
    {

        public DataContext() : base("DataContext") { 
			base.Configuration.LazyLoadingEnabled = false;
		}

        public DataContext(String connectionStrings) : base(connectionStrings) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
        }

        public static void InitDataBase()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
        }
    }
}
