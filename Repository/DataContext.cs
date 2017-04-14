/*==================================================
//============auto-generated code===================
//============not modified please===================
//================================================*/

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Model;

namespace Repository
{
    public class DataContext:DbContext,IDisposable
    {

        public DataContext() : base("DataContext") { 
			base.Configuration.LazyLoadingEnabled = false;
		}

        public DataContext(String connectionStrings) : base(connectionStrings) { }

        /// <summary>
        /// WebConfig 集合
        /// </summary>
        public DbSet<WebConfig> WebConfigs { get; set; }

        /// <summary>
        /// Log 集合
        /// </summary>
        public DbSet<Log> Logs { get; set; }

        /// <summary>
        /// Error 集合
        /// </summary>
        public DbSet<Error> Errors { get; set; }

        /// <summary>
        /// UserGroup 集合
        /// </summary>
        public DbSet<UserGroup> UserGroups { get; set; }

        /// <summary>
        /// Service 集合
        /// </summary>
        public DbSet<Service> Services { get; set; }

        /// <summary>
        /// ServiceMethod 集合
        /// </summary>
        public DbSet<ServiceMethod> ServiceMethods { get; set; }

        /// <summary>
        /// Module 集合
        /// </summary>
        public DbSet<Module> Modules { get; set; }

        /// <summary>
        /// ModuleOperate 集合
        /// </summary>
        public DbSet<ModuleOperate> ModuleOperates { get; set; }

        /// <summary>
        /// ModuleMenu 集合
        /// </summary>
        public DbSet<ModuleMenu> ModuleMenus { get; set; }

        /// <summary>
        /// ModuleService 集合
        /// </summary>
        public DbSet<ModuleService> ModuleServices { get; set; }

        /// <summary>
        /// Role 集合
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// RolePermission 集合
        /// </summary>
        public DbSet<RolePermission> RolePermissions { get; set; }

        /// <summary>
        /// User 集合
        /// </summary>
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new WebConfigConfiguration());
            modelBuilder.Configurations.Add(new LogConfiguration());
            modelBuilder.Configurations.Add(new ErrorConfiguration());
            modelBuilder.Configurations.Add(new UserGroupConfiguration());
            modelBuilder.Configurations.Add(new ServiceConfiguration());
            modelBuilder.Configurations.Add(new ServiceMethodConfiguration());
            modelBuilder.Configurations.Add(new ModuleConfiguration());
            modelBuilder.Configurations.Add(new ModuleOperateConfiguration());
            modelBuilder.Configurations.Add(new ModuleMenuConfiguration());
            modelBuilder.Configurations.Add(new ModuleServiceConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new RolePermissionConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            //将一堆多的级联删除全部设置成不可用
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
        }

        public static void InitDataBase()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
        }
    }
}
