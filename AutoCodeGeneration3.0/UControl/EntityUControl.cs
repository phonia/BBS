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

                this.textBoxConfigruationSpace.Text = EntityModels.First().DataContextNamespace;
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
                        sw.WriteLine("using Infrastructure;");//测试后请注释
                        if (it.EntityAssemblies != null && it.EntityAssemblies.Count > 0)
                        {
                            it.EntityAssemblies.ForEach(ea => sw.WriteLine(ea));
                        }
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

        }

        private void buttonRepositoryC_Click(object sender, EventArgs e)
        {

        }

        private void buttonConfigurationC_Click(object sender, EventArgs e)
        {

        }

        private void buttonDataContextC_Click(object sender, EventArgs e)
        {

        }
    }
}
