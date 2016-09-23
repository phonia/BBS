/*==================================================
//============auto-generated code===================
//============not modified please===================
//================================================*/

using System;
using System.Collections.Generic;
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
        /// Block 集合
        /// </summary>
        public DbSet<Block> Blocks { get; set; }

        /// <summary>
        /// Section 集合
        /// </summary>
        public DbSet<Section> Sections { get; set; }

        /// <summary>
        /// Post 集合
        /// </summary>
        public DbSet<Post> Posts { get; set; }

        /// <summary>
        /// Reply 集合
        /// </summary>
        public DbSet<Reply> Replys { get; set; }

        /// <summary>
        /// Attachment 集合
        /// </summary>
        public DbSet<Attachment> Attachments { get; set; }

        /// <summary>
        /// VoteItem 集合
        /// </summary>
        public DbSet<VoteItem> VoteItems { get; set; }

        /// <summary>
        /// VoteRecord 集合
        /// </summary>
        public DbSet<VoteRecord> VoteRecords { get; set; }

        /// <summary>
        /// WebConfig 集合
        /// </summary>
        public DbSet<WebConfig> WebConfigs { get; set; }

        /// <summary>
        /// Navagation 集合
        /// </summary>
        public DbSet<Navagation> Navagations { get; set; }

        /// <summary>
        /// ActionSign 集合
        /// </summary>
        public DbSet<ActionSign> ActionSigns { get; set; }

        /// <summary>
        /// ActionPermission 集合
        /// </summary>
        public DbSet<ActionPermission> ActionPermissions { get; set; }

        /// <summary>
        /// UserGroup 集合
        /// </summary>
        public DbSet<UserGroup> UserGroups { get; set; }

        /// <summary>
        /// User 集合
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// DailySignature 集合
        /// </summary>
        public DbSet<DailySignature> DailySignatures { get; set; }

        /// <summary>
        /// UserLog 集合
        /// </summary>
        public DbSet<UserLog> UserLogs { get; set; }

        /// <summary>
        /// SMS 集合
        /// </summary>
        public DbSet<SMS> SMSs { get; set; }

        /// <summary>
        /// ErrorLog 集合
        /// </summary>
        public DbSet<ErrorLog> ErrorLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BlockConfiguration());
            modelBuilder.Configurations.Add(new SectionConfiguration());
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new ReplyConfiguration());
            modelBuilder.Configurations.Add(new AttachmentConfiguration());
            modelBuilder.Configurations.Add(new VoteItemConfiguration());
            modelBuilder.Configurations.Add(new VoteRecordConfiguration());
            modelBuilder.Configurations.Add(new WebConfigConfiguration());
            modelBuilder.Configurations.Add(new NavagationConfiguration());
            modelBuilder.Configurations.Add(new ActionSignConfiguration());
            modelBuilder.Configurations.Add(new ActionPermissionConfiguration());
            modelBuilder.Configurations.Add(new UserGroupConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new DailySignatureConfiguration());
            modelBuilder.Configurations.Add(new UserLogConfiguration());
            modelBuilder.Configurations.Add(new SMSConfiguration());
            modelBuilder.Configurations.Add(new ErrorLogConfiguration());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
        }

        public static void InitDataBase()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
        }
    }
}
