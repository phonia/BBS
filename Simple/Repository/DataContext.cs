/*==================================================
//============auto-generated code===================
//============not modified please===================
//================================================*/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using Simple.Common;
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
        public DbSet<Section> Sections { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reply> Repliers { get; set; }
        public DbSet<WebConfig> WebConfig { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            try
            {
                modelBuilder.Configurations.Add(new UserConfiguration());
                modelBuilder.Configurations.Add(new WebConfigConfiguration());
                modelBuilder.Configurations.Add(new SectionConfiguration());
                modelBuilder.Configurations.Add(new PostConfiguration());
                modelBuilder.Configurations.Add(new ReplyConfiguration());

                //将一堆多的级联删除全部设置成不可用
                modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
            }
            catch (Exception ex)
            { }
        }

        public static void InitDataBase()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
            //    //初始化数据库
            using (var data = new DataContext())
            {
                if (data.Users.Count() > 0) return;
                data.Entry<User>(new User()
                {
                    Account = "Admin",
                    AcountType = AccountType.Manager,
                    Age = 28,
                    Email = "642370175@qq.com",
                    Password = "129921",
                    Sex = Sex.Male,
                    Tel = "15975455335"
                }).State = EntityState.Added;

                data.Entry<Section>(new Section()
                {
                    Description = "Comic",
                    KeyWord = "Comic",
                    Title = "Comic"
                }).State = EntityState.Added;
                data.Entry<Section>(new Section()
                {
                    Description = "Animation",
                    KeyWord = "Animation",
                    Title = "Animation"
                }).State = EntityState.Added;
                data.SaveChanges();
            }
        }
    }
}
