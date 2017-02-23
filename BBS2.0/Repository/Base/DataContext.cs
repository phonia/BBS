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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            try
            {
                modelBuilder.Configurations.Add(new AccountConfiguration());
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
                if (data.Set<Account>().Where(it => it.Name.Equals("Admin")).FirstOrDefault() != null) return;

                Account account = new Account()
                {
                    Name = "Admin",
                    AccountType = AccountType.Manager,
                    Age = 28,
                    Email = "baichuan@hotmail.com",
                    Password = "Admin",
                    Sex = Sex.Male,
                    Tel = "15975455335"
                };

                Account anonymous = new Account()
                {
                    Name = "anonymous",
                    AccountType = AccountType.Manager,
                    Age = 28,
                    Email = "baichuan@hotmail.com",
                    Password = "anonymous",
                    Sex = Sex.Male,
                    Tel = "15975455335"
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