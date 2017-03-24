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
                    Description = "论坛管理",
                    IsLeaf = false,
                    ModuleCode = "BBSManagement",
                    Name = "论坛管理",
                    Children = new List<SysModule>() { 
                        new SysModule()
                        {
                            Description="版块管理",
                            IsLeaf=true,
                            ModuleCode="SectionManagement",
                            Name="版块管理",
                            ModuleOperates=new List<SysModuleOperate>(){
                                new SysModuleOperate(){
                                    IsValid=true,
                                    KeyCode="00010001",
                                    Name="版块注册",
                                    Url="",
                                    OperateCode=ModuleOperateCode.Register
                                },
                                new SysModuleOperate(){
                                    IsValid=true,
                                    KeyCode="00010002",
                                    Name="版块修改",
                                    Url="",
                                    OperateCode=ModuleOperateCode.Update
                                },
                                new SysModuleOperate(){
                                    IsValid=true,
                                    KeyCode="00010003",
                                    Name="版块删除",
                                    Url="",
                                    OperateCode=ModuleOperateCode.Del
                                },
                                new SysModuleOperate(){
                                    IsValid=true,
                                    KeyCode="00010004",
                                    Name="版块详情",
                                    Url="/Section/Index",
                                    OperateCode=ModuleOperateCode.Detail
                                },
                                new SysModuleOperate(){
                                    IsValid=true,
                                    KeyCode="00010005",
                                    Name="版块查询",
                                    Url="",
                                    OperateCode=ModuleOperateCode.Query
                                }
                            }
                        },
                        new SysModule()
                        {
                            Description="帖子管理",
                            IsLeaf=true,
                            ModuleCode="PostManagement",
                            Name="帖子管理",
                            ModuleOperates=new List<SysModuleOperate>(){
                                new SysModuleOperate(){
                                    IsValid=true,
                                    KeyCode="00020001",
                                    Name="帖子注册",
                                    Url="/Post/PostPost",
                                    OperateCode=ModuleOperateCode.Register
                                },
                                new SysModuleOperate(){
                                    IsValid=true,
                                    KeyCode="00020002",
                                    Name="帖子修改",
                                    Url="",
                                    OperateCode=ModuleOperateCode.Update
                                },
                                new SysModuleOperate(){
                                    IsValid=true,
                                    KeyCode="00020003",
                                    Name="帖子删除",
                                    Url="",
                                    OperateCode=ModuleOperateCode.Del
                                },
                                new SysModuleOperate(){
                                    IsValid=true,
                                    KeyCode="00020004",
                                    Name="帖子详情",
                                    Url="/Post/Index",
                                    OperateCode=ModuleOperateCode.Detail
                                },
                                new SysModuleOperate(){
                                    IsValid=true,
                                    KeyCode="00020005",
                                    Name="帖子查询",
                                    Url="",
                                    OperateCode=ModuleOperateCode.Query
                                }
                            }
                        },new SysModule()
                        {
                            Description="回复管理",
                            IsLeaf=true,
                            ModuleCode="ReplyManagement",
                            Name="回复管理",
                            ModuleOperates=new List<SysModuleOperate>(){
                                new SysModuleOperate(){
                                    IsValid=true,
                                    KeyCode="00030001",
                                    Name="回复帖子",
                                    Url="/Post/ReplyPost",
                                    OperateCode=ModuleOperateCode.Add
                                },
                                new SysModuleOperate(){
                                    IsValid=true,
                                    KeyCode="00030002",
                                    Name="删除回复",
                                    Url="",
                                    OperateCode=ModuleOperateCode.Del
                                }
                            }
                        }
                    }
                };

                SysModule m2 = new SysModule()
                {
                    Description = "用户管理",
                    IsLeaf = true,
                    ModuleCode = "AccountManagement",
                    Name = "用户管理",
                    ModuleOperates = new List<SysModuleOperate>() { 
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00040001",
                            Name="用户注册",
                            Url="/Account/Register",
                            OperateCode=ModuleOperateCode.Register
                        },
                        new SysModuleOperate(){
                            IsValid=false,
                            KeyCode="00040002",
                            Name="用户登录",
                            Url="/Account/Login",
                            OperateCode=ModuleOperateCode.Login
                        },
                        new SysModuleOperate(){
                            IsValid=false,
                            KeyCode="00040003",
                            Name="用户注销",
                            Url="",
                            OperateCode=ModuleOperateCode.Logout
                        },
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00040004",
                            Name="用户查询",
                            Url="",
                            OperateCode=ModuleOperateCode.Query
                        },
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00040005",
                            Name="用户详情",
                            Url="",
                            OperateCode=ModuleOperateCode.Detail
                        },
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00040006",
                            Name="用户角色设置",
                            Url="",
                            OperateCode=ModuleOperateCode.Setting
                        },
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00040007",
                            Name="用户修改",
                            Url="",
                            OperateCode=ModuleOperateCode.Update
                        }
                    }
                };

                SysModule m3 = new SysModule()
                {
                    Description = "权限管理",
                    IsLeaf = false,
                    ModuleCode = "PermissionManagement",
                    Name = "权限管理",
                    ModuleOperates = new List<SysModuleOperate>() {
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00050001",
                            Name="模块查询",
                            Url="",
                            OperateCode=ModuleOperateCode.Query
                        },
                        new SysModuleOperate(){
                            IsValid=true,
                            KeyCode="00050002",
                            Name="模块功能查询",
                            Url="",
                            OperateCode=ModuleOperateCode.Search
                        }
                    }
                };

                SysModule m4 = new SysModule()
                {
                    Description = "系统管理",
                    IsLeaf = false,
                    ModuleCode = "SystemManagement",
                    Name = "系统管理",
                    Children = new List<SysModule>() { 
                        new SysModule()
                        {
                            Description="日志管理",
                            IsLeaf=true,
                            ModuleCode="LogManagement",
                            Name="日志管理",
                            ModuleOperates=new List<SysModuleOperate>(){
                                new SysModuleOperate(){
                                    IsValid=true,
                                    KeyCode="00060001",
                                    Name="日志查询",
                                    Url="",
                                    OperateCode=ModuleOperateCode.Query
                                },
                                new SysModuleOperate(){
                                    IsValid=true,
                                    KeyCode="00060002",
                                    Name="日志详情",
                                    Url="",
                                    OperateCode=ModuleOperateCode.Detail
                                }
                            }
                        },
                        new SysModule()
                        {
                            Description="异常和错误",
                            IsLeaf=true,
                            ModuleCode="ExceptionManagement",
                            Name="异常和错误",
                            ModuleOperates=new List<SysModuleOperate>(){
                                new SysModuleOperate(){
                                    IsValid=true,
                                    KeyCode="00070001",
                                    Name="异常查询",
                                    Url="",
                                    OperateCode=ModuleOperateCode.Query
                                },
                                new SysModuleOperate(){
                                    IsValid=true,
                                    KeyCode="00070002",
                                    Name="异常详情",
                                    Url="",
                                    OperateCode=ModuleOperateCode.Detail
                                }
                            }
                        }
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