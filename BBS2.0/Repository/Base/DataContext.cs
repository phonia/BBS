using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using BBS2._0.Common;
using BBS2._0.Models;

namespace BBS2._0.Repository
{
    public class DataContext : DbContext, IDisposable
    {

        public DataContext()
            : base("DataContext")
        {
            base.Configuration.LazyLoadingEnabled = false;
        }

        public DataContext(String connectionStrings) : base(connectionStrings) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<SysRole> Roles { get; set; }
        public DbSet<SysModule> Modules { get; set; }
        public DbSet<SysModuleOperate> ModuleOperates { get; set; }
        public DbSet<SysFunctionRight> FunctionRights { get; set; }
        public DbSet<SysLog> Logs { get; set; }
        public DbSet<SysException> Exceptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            try
            {
                modelBuilder.Configurations.Add(new AccountConfiguration());
                modelBuilder.Configurations.Add(new SectionConfiguration());
                modelBuilder.Configurations.Add(new PostConfiguration());
                modelBuilder.Configurations.Add(new ReplyConfiguration());
                modelBuilder.Configurations.Add(new SysRoleConfiguration());
                modelBuilder.Configurations.Add(new SysFunctionRightConfiguration());
                modelBuilder.Configurations.Add(new SysModuleConfiguration());
                modelBuilder.Configurations.Add(new SysModuleOperateConfiguration());
                modelBuilder.Configurations.Add(new SysLogConfiguration());
                modelBuilder.Configurations.Add(new SysExceptionConfiguration());

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
                if (data.Set<Account>().Where(it => it.Name.Equals("Admin")).FirstOrDefault() != null) return;

                SysRole superRole = new SysRole()
                {
                    Description = "超级管理员",
                    Name = "SuperRole"
                };

                SysRole anonymousRole = new SysRole()
                {
                    Description = "匿名账户",
                    Name = "AnonymousRole"
                };

                Account account = new Account()
                {
                    Name = "Admin",
                    AccountType = AccountType.Manager,
                    Age = 28,
                    Email = "baichuan@hotmail.com",
                    Password = "Admin",
                    Sex = Sex.Male,
                    Tel = "15975455335",
                    Role=superRole
                };

                Account anonymous = new Account()
                {
                    Name = "anonymous",
                    AccountType = AccountType.Manager,
                    Age = 28,
                    Email = "baichuan@hotmail.com",
                    Password = "anonymous",
                    Sex = Sex.Male,
                    Tel = "15975455335",
                    Role=anonymousRole
                };

                Section animation = new Section()
                {
                    Title = "Animation",
                    Description = "Animation",
                    Posts = new List<Post>() 
                    { 
                        new Post()
                        {
                            Keyword = "测试一",
                            Poster=account,
                            PublicTime=DateTime.Now,
                            ScanAccount=2,
                            Title="测试一",
                            Replies=new List<Reply>()
                            {
                                new Reply()
                                {
                                    Content="回复一",
                                    Level=0,
                                    Replyer=account,
                                    ReplyTime=DateTime.Now
                                },
                                new Reply()
                                {
                                    Content="回复二",
                                    Level=1,
                                    Replyer=anonymous,
                                    ReplyTime=DateTime.Now
                                }
                            }
                        },
                        new Post()
                        {
                            Keyword = "测试二",
                            Poster=account,
                            PublicTime=DateTime.Now,
                            ScanAccount=2,
                            Title="测试二",
                            Replies=new List<Reply>()
                            {
                                new Reply()
                                {
                                    Content="回复三",
                                    Level=0,
                                    Replyer=account,
                                    ReplyTime=DateTime.Now
                                },
                                new Reply()
                                {
                                    Content="回复四",
                                    Level=1,
                                    Replyer=anonymous,
                                    ReplyTime=DateTime.Now
                                }
                            }
                        }
                    }
                };

                Section comic = new Section()
                {
                    Title = "Comic",
                    Description = "Comic"
                };

                Section game = new Section()
                {
                    Title = "Game",
                    Description = "Game"
                };

                data.Set<Section>().Add(animation);
                data.Set<Section>().Add(comic);
                data.Set<Section>().Add(game);

                data.SaveChanges();
            }
        }
    }
}