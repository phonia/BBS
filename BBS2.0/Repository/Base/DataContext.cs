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


                //模块、模块操作
                SysModule m1 = new SysModule()
                {
                    Description = "功能权限",
                    IsLeaf = true,
                    ModuleCode = "ControlPermisson",
                    Name = "功能权限",
                    ModuleOperates = new List<SysModuleOperate>() { 
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00010001",
                            OperateCode=ModuleOperateCode.Add1
                        },
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00010002",
                            OperateCode=ModuleOperateCode.Delete1
                        },
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00010003",
                            OperateCode=ModuleOperateCode.Detail1
                        },
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00010004",
                            OperateCode=ModuleOperateCode.Eidt1
                        },
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00010005",
                            OperateCode=ModuleOperateCode.Search1
                        },
                    }
                };

                SysModule m2 = new SysModule()
                {
                    Description = "用户管理",
                    IsLeaf = true,
                    ModuleCode = "UserManagement",
                    Name = "用户管理",
                    ModuleOperates = new List<SysModuleOperate>() { 
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00020001",
                            OperateCode=ModuleOperateCode.Add1
                        },
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00020002",
                            OperateCode=ModuleOperateCode.Delete1
                        },
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00020003",
                            OperateCode=ModuleOperateCode.Detail1
                        },
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00020004",
                            OperateCode=ModuleOperateCode.Eidt1
                        },
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00020005",
                            OperateCode=ModuleOperateCode.Search1
                        },
                    }
                };
                SysModule m3 = new SysModule()
                {
                    Description = "系统管理",
                    IsLeaf = true,
                    ModuleCode = "SysManagement",
                    Name = "系统管理",
                    ModuleOperates = new List<SysModuleOperate>() { 
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00030001",
                            OperateCode=ModuleOperateCode.Add1
                        },
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00030002",
                            OperateCode=ModuleOperateCode.Delete1
                        },
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00030003",
                            OperateCode=ModuleOperateCode.Detail1
                        },
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00030004",
                            OperateCode=ModuleOperateCode.Eidt1
                        },
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00030005",
                            OperateCode=ModuleOperateCode.Search1
                        },
                    }
                };
                SysModule m4 = new SysModule()
                {
                    Description = "论坛管理",
                    IsLeaf = true,
                    ModuleCode = "BBSManagement",
                    Name = "论坛管理",
                    ModuleOperates = new List<SysModuleOperate>() { 
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00040001",
                            OperateCode=ModuleOperateCode.Add1
                        },
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00040002",
                            OperateCode=ModuleOperateCode.Delete1
                        },
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00040003",
                            OperateCode=ModuleOperateCode.Detail1
                        },
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00040004",
                            OperateCode=ModuleOperateCode.Eidt1
                        },
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00040005",
                            OperateCode=ModuleOperateCode.Search1
                        },
                    }
                };
                data.Set<SysModule>().Add(m1);
                data.Set<SysModule>().Add(m2);
                data.Set<SysModule>().Add(m3);
                data.Set<SysModule>().Add(m4);

                data.SaveChanges();
            }
        }
    }
}