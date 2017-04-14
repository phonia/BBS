using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoCodeGeneration3._0.Code;
using System.IO;
using AutoCodeGeneration3._0.Win;

namespace AutoCodeGeneration3._0.UControl
{
    public partial class EntityUControl : UserControl
    {
        public List<EntityModel> EntityModels { get; set; }

        public EntityUControl()
        {
            InitializeComponent();
            this.dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            this.textBoxConfigruationSpace.LostFocus += textBoxConfigruationSpace_LostFocus;
            this.textBoxConfigurationPath.LostFocus += textBoxConfigurationPath_LostFocus;
            this.textBoxDataContextPath.LostFocus += textBoxDataContextPath_LostFocus;
            this.textBoxDataContextSapce.LostFocus += textBoxDataContextSapce_LostFocus;
            this.textboxEntityPath.LostFocus += textboxEntityPath_LostFocus;
            this.textBoxEntitySapce.LostFocus += textBoxEntitySapce_LostFocus;
            this.textBoxIRepositoryPath.LostFocus += textBoxIRepositoryPath_LostFocus;
            this.textBoxIRepositorySpace.LostFocus += textBoxIRepositorySpace_LostFocus;
            this.textBoxRepositoryPath.LostFocus += textBoxRepositoryPath_LostFocus;
            this.textBoxRepositorySpace.LostFocus += textBoxRepositorySpace_LostFocus;
        }

        void textBoxRepositorySpace_LostFocus(object sender, EventArgs e)
        {
            EntityModels.ForEach(it => {
                it.RepositoryNamespace = this.textBoxRepositorySpace.Text.Trim();
            });
        }

        void textBoxRepositoryPath_LostFocus(object sender, EventArgs e)
        {
            EntityModels.ForEach(it =>
            {
                it.RepositoryPath = this.textBoxRepositoryPath.Text.Trim();
            });
        }

        void textBoxIRepositorySpace_LostFocus(object sender, EventArgs e)
        {
            EntityModels.ForEach(it =>
            {
                it.IRepositoryNamespace = this.textBoxIRepositorySpace.Text.Trim();
            });
        }

        void textBoxIRepositoryPath_LostFocus(object sender, EventArgs e)
        {
            EntityModels.ForEach(it =>
            {
                it.IRepositoryPath = this.textBoxIRepositoryPath.Text.Trim();
            });
        }

        void textBoxEntitySapce_LostFocus(object sender, EventArgs e)
        {
            EntityModels.ForEach(it =>
            {
                it.EntityNamespace = this.textBoxEntitySapce.Text.Trim();
            });
        }

        void textboxEntityPath_LostFocus(object sender, EventArgs e)
        {
            EntityModels.ForEach(it =>
            {
                it.EntityPath = this.textboxEntityPath.Text.Trim();
            });
        }

        void textBoxDataContextSapce_LostFocus(object sender, EventArgs e)
        {
            EntityModels.ForEach(it =>
            {
                it.DataContextNamespace = this.textBoxDataContextSapce.Text.Trim();
            });
        }

        void textBoxDataContextPath_LostFocus(object sender, EventArgs e)
        {
            EntityModels.ForEach(it =>
            {
                it.DataContextPath = this.textBoxDataContextPath.Text.Trim();
            });
        }

        void textBoxConfigurationPath_LostFocus(object sender, EventArgs e)
        {
            EntityModels.ForEach(it =>
            {
                it.ConfigurationPath = this.textBoxConfigurationPath.Text.Trim();
            });
        }

        void textBoxConfigruationSpace_LostFocus(object sender, EventArgs e)
        {
            EntityModels.ForEach(it =>
            {
                it.ConfigurationNamespace = this.textBoxConfigruationSpace.Text.Trim();
            });
        }

        void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        public void Init(List<EntityModel> entityModels,int heigth,int width)
        {
            //this.EntityModels = EntityModel.ConvertToEntityModel(dataRecords);
            this.Height = heigth;
            this.Width = width;
            this.dataGridView1.Width = width;
            this.dataGridView1.Height = heigth - 140;
            this.EntityModels = entityModels;
            DataBind();
        }

        void DataBind()
        {
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.DataSource = EntityModels;
            if (EntityModels != null && EntityModels.Count > 0)
            {

                this.textBoxConfigruationSpace.Text = EntityModels.First().ConfigurationNamespace;
                this.textBoxConfigurationPath.Text = EntityModels.First().ConfigurationPath;
                this.textBoxDataContextPath.Text = EntityModels.First().DataContextPath;
                this.textBoxDataContextSapce.Text = EntityModels.First().DataContextNamespace;
                this.textboxEntityPath.Text = EntityModels.First().EntityPath;
                this.textBoxEntitySapce.Text = EntityModels.First().EntityNamespace;
                this.textBoxIRepositoryPath.Text = EntityModels.First().IRepositoryPath;
                this.textBoxIRepositorySpace.Text = EntityModels.First().IRepositoryNamespace;
                this.textBoxRepositoryPath.Text = EntityModels.First().RepositoryPath;
                this.textBoxRepositorySpace.Text = EntityModels.First().RepositoryNamespace;
            }
        }

        private void buttonEntityC_Click(object sender, EventArgs e)
        {
            if (EntityModels != null && EntityModels.Count > 0)
            {
                EntityModels.ForEach(it =>
                {
                    if (!Directory.Exists(it.EntityPath + "\\" + it.DomainName))
                    {
                        Directory.CreateDirectory(it.EntityPath + "\\" + it.DomainName);
                    }

                    if (this.checkBoxEnitiy.Checked == false && File.Exists(it.EntityPath + "\\" + it.DomainName + "\\" + it.ClassName + ".cs")) return;

                    FileStream fs = new FileStream(it.EntityPath + "\\" + it.DomainName + "\\" + it.ClassName + ".cs", FileMode.Create);
                    using (var sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("/*==================================================");
                        sw.WriteLine("//============auto-generated code===================");
                        sw.WriteLine("//============not modified please===================");
                        sw.WriteLine("//================================================*/");
                        sw.WriteLine("");
                        sw.WriteLine("using System;");
                        sw.WriteLine("using System.Collections.Generic;");
                        sw.WriteLine("using System.ComponentModel;");
                        sw.WriteLine("using System.Linq;");
                        sw.WriteLine("using System.Text;");
                        //sw.WriteLine("using Infrastructure;");//测试后请注释
                        if (it.EntityQuoteNamespaces != null && it.EntityQuoteNamespaces.Count > 0)
                        {
                            it.EntityQuoteNamespaces.ForEach(ea => sw.WriteLine(ea));
                        }
                        sw.WriteLine("");
                        sw.WriteLine("namespace " + it.EntityNamespace);
                        sw.WriteLine("{");
                        if (it.IsEntityType || it.IsComplexyType)
                        {
                            if (it.IsEntityType)
                            {
                                sw.WriteLine("    /// <summary>");
                                sw.WriteLine("    /// " + it.Description + " 实体类");
                                sw.WriteLine("    /// </summary>");
                                sw.WriteLine("    public partial class " + it.ClassName + ":EntityBase,IAggregateRoot");
                            }
                            else
                            {
                                sw.WriteLine("    /// <summary>");
                                sw.WriteLine("    /// " + it.Description + " 复合属性");
                                sw.WriteLine("    /// </summary>");
                                sw.WriteLine("    public partial class " + it.ClassName);
                            }
                            sw.WriteLine("    {");
                            if (it.EntityProperties != null && it.EntityProperties.Count > 0)
                            {
                                it.EntityProperties.ForEach(ep =>
                                {
                                    if (ep.IsCustomProperty)
                                    {
                                        sw.WriteLine("        /// <summary>");
                                        sw.WriteLine("        /// " + ep.Description);
                                        if (ep.IsIdentity)
                                            sw.WriteLine("        /// " + "自增");
                                        sw.WriteLine("        /// </summary>");
                                        //sw.WriteLine("        public " + (ep.IsNull ? node.ConvertToNullable() : node.PropertyType) + " " + node.PropertyName + " { get; set; }");
                                        sw.Write("        public ");
                                        if (!ep.IsNull)
                                        {
                                            sw.Write(ep.PropertyType + " " + ep.PropertyName + " { get; set; }");
                                        }
                                        else
                                        {
                                            if (ep.PropertyType.Equals("Int32") || ep.PropertyType.Equals("DateTime"))
                                            {
                                                sw.Write(ep.PropertyType + "? " + ep.PropertyName + " { get; set; }");
                                            }
                                            else
                                            {
                                                sw.Write(ep.PropertyType + " " + ep.PropertyName + " { get; set; }");
                                            }
                                        }
                                        sw.WriteLine("");
                                    }

                                    if (ep.IsNavigationProperty)
                                    {
                                        sw.WriteLine("");
                                        sw.WriteLine("        /// <summary>");
                                        sw.WriteLine("        /// " + "导航属性" + ep.Description);
                                        sw.WriteLine("        /// </summary>");
                                        if (ep.IsGeneric)
                                        {
                                            sw.WriteLine("        public IList<" + ep.NavigationType + "> " + ep.NavigationName + " { get; set; }");
                                        }
                                        else
                                        {
                                            sw.WriteLine("        public " + ep.NavigationType + " " + ep.NavigationName + " { get; set; }");
                                        }
                                    }
                                });

                                if (it.IsEntityType)
                                {
                                    sw.WriteLine("");
                                    sw.WriteLine("        public Int32? CreateUserId { get; set; }");
                                    sw.WriteLine("");
                                    sw.WriteLine("        public Int32? UpdateUserId { get; set; }");
                                    sw.WriteLine("");
                                    sw.WriteLine("        public DateTime? CreateDateTime { get; set; }");
                                    sw.WriteLine("");
                                    sw.WriteLine("        public DateTime? UpdateDateTime { get; set; }");
                                    sw.WriteLine("");
                                    sw.WriteLine("        public byte[] RowVersion { get; set; }");
                                    sw.WriteLine("");
                                    sw.WriteLine("        public bool IsDeleted { get; set; }");
                                }
                            }
                            sw.WriteLine("    }");
                        }

                        if (it.IsEnum)
                        {
                            sw.WriteLine("    /// <summary>");
                            sw.WriteLine("    /// " + it.Description + " 枚举类");
                            sw.WriteLine("    /// </summary>");
                            sw.WriteLine("    public enum " + it.ClassName);
                            sw.WriteLine("    {");
                            if (it.EntityProperties != null && it.EntityProperties.Count > 0)
                            {
                                int count = 0;
                                it.EntityProperties.ForEach(ep =>
                                {
                                    if (ep.IsEnumItem)
                                    {
                                        if (count != 0)
                                        {
                                            sw.WriteLine(",");
                                        }
                                        sw.WriteLine("");
                                        sw.WriteLine("        /// <summary>");
                                        sw.WriteLine("        /// " + ep.Description);
                                        sw.WriteLine("        /// </summary>");
                                        sw.WriteLine("        [Description(\"" + ep.Description + "\")]");
                                        sw.Write("        " + ep.ItemName);
                                        count++;
                                    }
                                });
                            }
                            sw.WriteLine("");
                            sw.WriteLine("    }");
                        }

                        sw.WriteLine("}");

                    }
                    fs.Close();
                    fs.Dispose();
                });
            }
        }

        private void buttonIRepositoryC_Click(object sender, EventArgs e)
        {
            if (EntityModels != null && EntityModels.Count > 0)
            {
                EntityModels.ForEach(it => {
                    if (it.IsEntityType)
                    {
                        if (!Directory.Exists(it.IRepositoryPath + "\\" + it.DomainName))
                        {
                            Directory.CreateDirectory(it.IRepositoryPath + "\\" + it.DomainName);
                        }
                        if (this.checkBoxIRepository.Checked == false && File.Exists(it.IRepositoryPath + "\\" + it.DomainName + "\\I" + it.ClassName+"Repository.cs")) return;
                        FileStream fs = new FileStream(it.IRepositoryPath + "\\" + it.DomainName +"\\I"+it.ClassName+ "Repository.cs", FileMode.Create);
                        using (var sw = new StreamWriter(fs))
                        {
                            sw.WriteLine("/*=============================================================");
                            sw.WriteLine(" * ===============auto-generated code           ===============");
                            sw.WriteLine(" * ===============Should Be Marked if modified=================");
                            sw.WriteLine(" * ==========================================================*/");
                            sw.WriteLine("");
                            sw.WriteLine("using System;");
                            sw.WriteLine("using System.Collections.Generic;");
                            sw.WriteLine("using System.Linq;");
                            sw.WriteLine("using System.Text;");
                            if (it.IRepositoryQuoteNamespaces != null && it.IRepositoryQuoteNamespaces.Count > 0)
                            {
                                it.IRepositoryQuoteNamespaces.ForEach(n => sw.WriteLine(n));
                            }
                            sw.WriteLine("");
                            sw.WriteLine("namespace "+it.IRepositoryNamespace);
                            sw.WriteLine("{");
                            sw.WriteLine("    /// <summary>");
                            sw.WriteLine("    /// " + it.ClassName + " 仓储接口");
                            sw.WriteLine("    /// </summary>");
                            sw.WriteLine("    public interface I" + it.ClassName + "Repository : IRepository<" + it.ClassName + ","+it.PKPropertyType+">");//默认的主键Id是类型是Int32型
                            sw.WriteLine("    {");
                            sw.WriteLine("    }");
                            sw.WriteLine("}");
                        }
                        fs.Close();
                        fs.Dispose();
                    }
                });
            }
            else
            {
                MessageBox.Show("模型数据");
            }
        }

        private void buttonRepositoryC_Click(object sender, EventArgs e)
        {
            if (EntityModels != null && EntityModels.Count > 0)
            {
                EntityModels.ForEach(it => {
                    if (it.IsEntityType)
                    {
                        if (!Directory.Exists(it.RepositoryPath + "\\" + it.DomainName))
                        {
                            Directory.CreateDirectory(it.RepositoryPath + "\\" + it.DomainName);
                        }
                        if (this.checkBoxRepository.Checked == false && File.Exists(it.RepositoryPath + "\\" + it.DomainName + "\\" + it.ClassName + "Repository.cs")) return;

                        FileStream fs = new FileStream(it.RepositoryPath + "\\" + it.DomainName + "\\" + it.ClassName + "Repository.cs", FileMode.Create);
                        using (var sw = new StreamWriter(fs))
                        {
                            sw.WriteLine("/*=============================================================");
                            sw.WriteLine(" * ===============auto-generated code           ===============");
                            sw.WriteLine(" * ===============Should Be Marked if modified=================");
                            sw.WriteLine(" * ==========================================================*/");
                            sw.WriteLine("");
                            sw.WriteLine("using System;");
                            sw.WriteLine("using System.Collections.Generic;");
                            sw.WriteLine("using System.Linq;");
                            sw.WriteLine("using System.Text;");
                            //sw.WriteLine("using Infrastructure;");
                            //sw.WriteLine("using Model;");
                            if (it.RepositoryQuoteNamespaces != null && it.RepositoryQuoteNamespaces.Count > 0)
                            {
                                it.RepositoryQuoteNamespaces.ForEach(en => sw.WriteLine(en));
                            }
                            sw.WriteLine("");
                            sw.WriteLine("namespace "+it.RepositoryNamespace);
                            sw.WriteLine("{");
                            sw.WriteLine("    /// <summary>");
                            sw.WriteLine("    /// " + it.ClassName + " 仓储实现");
                            sw.WriteLine("    /// </summary>");
                            sw.WriteLine("    public class " + it.ClassName + "Repository : EFRepository<" + it.ClassName + ","+it.PKPropertyType+">,I" + it.ClassName + "Repository");//默认的主键Id是类型是Int32型
                            sw.WriteLine("    {");
                            sw.WriteLine("    }");
                            sw.WriteLine("}");
                        }
                        fs.Close();
                        fs.Dispose();
                    }
                });
            }
        }

        private void buttonConfigurationC_Click(object sender, EventArgs e)
        {
            if (EntityModels != null && EntityModels.Count > 0)
            {
                EntityModels.ForEach(it => {
                    if (it.IsEntityType||it.IsComplexyType)
                    {
                        if (!Directory.Exists(it.ConfigurationPath + "\\" + it.DomainName))
                        {
                            Directory.CreateDirectory(it.ConfigurationPath + "\\" + it.DomainName);
                        }
                        if (this.checkBoxConfiguration.Checked == false && File.Exists(it.ConfigurationPath + "\\" + it.DomainName + "\\" + it.ClassName + "Configuration.cs")) return;
                        FileStream fs = new FileStream(it.ConfigurationPath + "\\" + it.DomainName + "\\" + it.ClassName + "Configuration.cs", FileMode.Create);
                        using (var sw = new StreamWriter(fs))
                        {
                            sw.WriteLine("/*==================================================");
                            sw.WriteLine("//============auto-generated code===================");
                            sw.WriteLine("//============not modified please===================");
                            sw.WriteLine("//================================================*/");
                            sw.WriteLine("");
                            sw.WriteLine("using System;");
                            sw.WriteLine("using System.Collections.Generic;");
                            sw.WriteLine("using System.ComponentModel.DataAnnotations.Schema;");
                            sw.WriteLine("using System.Data.Entity.ModelConfiguration;");
                            sw.WriteLine("using System.Linq;");
                            sw.WriteLine("using System.Text;");
                            if (it.ConfigurationQuoteNamespaces != null && it.ConfigurationQuoteNamespaces.Count > 0)
                            {
                                it.ConfigurationQuoteNamespaces.ForEach(en => sw.WriteLine(en));
                            }
                            sw.WriteLine("");
                            sw.WriteLine("namespace "+it.ConfigurationNamespace);
                            sw.WriteLine("{");
                            sw.WriteLine("    /// <summary>");
                            sw.WriteLine("    /// " + it.ClassName + " 配置类");
                            sw.WriteLine("    /// </summary>");
                            if (it.IsEntityType)
                            {
                                sw.WriteLine("    public class " + it.ClassName + "Configuration:EntityTypeConfiguration<" + it.ClassName + ">");
                            }
                            if (it.IsComplexyType)
                            {
                                sw.WriteLine("    public class " + it.ClassName + "Configuration:ComplexTypeConfiguration<" + it.ClassName + ">");
                            }
                            sw.WriteLine("    {");
                            sw.WriteLine("        public " + it.ClassName + "Configuration()");
                            sw.WriteLine("        {");
                            if (it.IsEntityType)
                            {
                                sw.WriteLine("            ToTable(\"" + it.DomainName + "_" + it.TableName + "\");");
                                sw.WriteLine("            HasKey(e=>e." + it.PKPropertyName + ");");
                                sw.WriteLine("            Property(e => e.RowVersion).IsRowVersion();");
                            }
                            if (it.EntityProperties != null && it.EntityProperties.Count > 0)
                            {
                                //sw.Write("            Property(e =>e." + node.PropertyName + ")");
                                it.EntityProperties.ForEach(ep => {
                                    if (ep.IsCustomProperty&&ep.IsForeignKey==false) {
                                        sw.Write("            Property(e =>e." + ep.PropertyName + ")");
                                        sw.Write(".HasColumnName(\"" +ep.FieldName + "\")");
                                        sw.Write(".HasColumnType(\"" + ep.FieldType + "\")");
                                        if(ep.IsIdentity)
                                            sw.Write(".HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)");
                                        if(ep.MaxLength>0)
                                            sw.Write(".HasMaxLength(" + ep.MaxLength + ")");
                                        if(ep.IsNull)
                                            sw.WriteLine(".IsOptional();");
                                        else
                                            sw.WriteLine(".IsRequired();");
                                    }
                                    if (ep.IsComplexyType) { }
                                    if (ep.IsNavigationProperty&&ep.IsGeneric==false) {
                                        if (ep.IsNull)
                                        {
                                            sw.Write("            HasOptional(e=>e." + ep.NavigationName + ")");
                                        }
                                        else
                                        {
                                            sw.Write("            HasRequired(e=>e." + ep.NavigationName + ")");
                                        }
                                        if (!String.IsNullOrWhiteSpace(ep.ReferenceField))
                                        {
                                            sw.Write(".WithMany(e=>e." + ep.ReferenceField + ")");
                                        }
                                        else
                                        {
                                            sw.Write(".WithMany()");
                                        }
                                        //sw.WriteLine(".Map(e=>e.MapKey(\"" + ep.PropertyName + "\"));");
                                        sw.WriteLine(".HasForeignKey(e=>e."+ep.PropertyName+");");
                                    }
                                });
                            }
                            sw.WriteLine("        }");
                            sw.WriteLine("    }");
                            sw.WriteLine("}");
                        }
                        fs.Close();
                        fs.Dispose();
                    }
                });
            }
        }

        private void buttonDataContextC_Click(object sender, EventArgs e)
        {
            if (EntityModels != null && EntityModels.Count > 0)
            {
                if (this.checkBoxDataContext.Checked == false && File.Exists(EntityModels.First().DataContextPath + "\\DataContext.cs")) return;
                FileStream fs = new FileStream(EntityModels.First().DataContextPath + "\\DataContext.cs", FileMode.Create);
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine("/*==================================================");
                    sw.WriteLine("//============auto-generated code===================");
                    sw.WriteLine("//============not modified please===================");
                    sw.WriteLine("//================================================*/");
                    sw.WriteLine("");
                    sw.WriteLine("using System;");
                    sw.WriteLine("using System.Collections.Generic;");
                    sw.WriteLine("using System.Data.Entity.ModelConfiguration.Conventions;");
                    sw.WriteLine("using System.Data.Entity;");
                    sw.WriteLine("using System.Linq;");
                    sw.WriteLine("using System.Text;");
                    if (EntityModels.First().DataContextQuoteNamespaces != null && EntityModels.First().DataContextQuoteNamespaces.Count > 0)
                    {
                        EntityModels.First().DataContextQuoteNamespaces.ForEach(ep => sw.WriteLine(ep));
                    }
                    sw.WriteLine("");
                    sw.WriteLine("namespace " + EntityModels.First().DataContextNamespace);
                    sw.WriteLine("{");
                    sw.WriteLine("    public class DataContext:DbContext,IDisposable");
                    sw.WriteLine("    {");
                    sw.WriteLine("");
                    sw.WriteLine("        public DataContext() : base(\"DataContext\") { ");
                    sw.WriteLine("			base.Configuration.LazyLoadingEnabled = false;");
                    sw.WriteLine("		}");
                    sw.WriteLine("");
                    sw.WriteLine("        public DataContext(String connectionStrings) : base(connectionStrings) { }");
                    sw.WriteLine("");
                    EntityModels.ForEach(it => {
                        if (it.IsEntityType)
                        {
                            sw.WriteLine("        /// <summary>");
                            sw.WriteLine("        /// " + it.ClassName + " 集合");
                            sw.WriteLine("        /// </summary>");
                            sw.WriteLine("        public DbSet<" + it.ClassName + "> " + it.ClassName + "s { get; set; }");
                            sw.WriteLine("");
                        }
                    });

                    sw.WriteLine("        protected override void OnModelCreating(DbModelBuilder modelBuilder)");
                    sw.WriteLine("        {");
                    EntityModels.ForEach(it => {
                        if (it.IsEntityType)
                        {
                            sw.WriteLine("            modelBuilder.Configurations.Add(new " + it.ClassName + "Configuration());");
                        }
                    });
                    sw.WriteLine("            //将一堆多的级联删除全部设置成不可用");
                    sw.WriteLine("            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();");
                    sw.WriteLine("");
                    sw.WriteLine("            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());");
                    sw.WriteLine("        }");
                    sw.WriteLine("");
                    sw.WriteLine("        public static void InitDataBase()");
                    sw.WriteLine("        {");
                    sw.WriteLine("            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());");
                    sw.WriteLine("        }");
                    sw.WriteLine("    }");
                    sw.WriteLine("}");
                }
                fs.Close();
                fs.Dispose();
            }
        }

        private void buttonEntity_Click(object sender, EventArgs e)
        {
            EntityQFrm eqf = new EntityQFrm();
            eqf.Init(EntityModels != null && EntityModels.Count > 0 ? EntityModels.First().EntityQuoteNamespaces : null);
            if (eqf.ShowDialog() == DialogResult.Cancel)
            {
                if(EntityModels!=null)
                    EntityModels.ForEach(it => it.EntityQuoteNamespaces = eqf.EntityQuoteNamespace);
            }
        }

        private void buttonIRepository_Click(object sender, EventArgs e)
        {
            IRepositoryQFrm irqf = new IRepositoryQFrm();
            irqf.Init(EntityModels != null && EntityModels.Count > 0 ? EntityModels.First().IRepositoryQuoteNamespaces : null);
            if (irqf.ShowDialog() == DialogResult.Cancel)
            {
                if (EntityModels != null)
                    EntityModels.ForEach(it => it.IRepositoryQuoteNamespaces = irqf.IRepositroyQuoteNamespace);
            }
        }

        private void buttonRepository_Click(object sender, EventArgs e)
        {
            RepositoryQFrm rqf = new RepositoryQFrm();
            rqf.Init(EntityModels != null && EntityModels.Count > 0 ? EntityModels.First().RepositoryQuoteNamespaces : null);
            if (rqf.ShowDialog() == DialogResult.Cancel)
            {
                if (EntityModels != null)
                    EntityModels.ForEach(it => it.RepositoryQuoteNamespaces = rqf.ReposiotryQuoteNamespace);
            }
        }

        private void buttonConfiguration_Click(object sender, EventArgs e)
        {
            ConfigurationQFrm cqf = new ConfigurationQFrm();
            cqf.Init(EntityModels != null && EntityModels.Count > 0 ? EntityModels.First().ConfigurationQuoteNamespaces : null);
            if (cqf.ShowDialog() == DialogResult.Cancel)
            {
                if (EntityModels != null)
                    EntityModels.ForEach(it => it.ConfigurationQuoteNamespaces = cqf.ConfigurationQuoteNamesapce);
            }
        }

        private void buttonDataContext_Click(object sender, EventArgs e)
        {
            DataContextQFrm dqf = new DataContextQFrm();
            dqf.Init(EntityModels != null && EntityModels.Count > 0 ? EntityModels.First().DataContextQuoteNamespaces : null);
            if (dqf.ShowDialog() == DialogResult.Cancel)
            {
                if (EntityModels != null)
                {
                    EntityModels.ForEach(it => it.DataContextQuoteNamespaces = dqf.DataContextQuoteNamespace);
                }
            }
        }
    }
}
