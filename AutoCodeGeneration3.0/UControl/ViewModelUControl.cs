using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoCodeGeneration3._0.Code;
using AutoCodeGeneration3._0.Win;
using System.IO;

namespace AutoCodeGeneration3._0.UControl
{
    public partial class ViewModelUControl : UserControl
    {
        public SaveBack SaveBack { get; set; }

        public ViewModelUControl()
        {
            InitializeComponent();
            this.textBoxVMNamespace.LostFocus += textBoxVMNamespace_LostFocus;
            this.textBoxVMPath.LostFocus += textBoxVMPath_LostFocus;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView2.MultiSelect = false;
            this.dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                if ((this.dataGridView1.SelectedRows[0].DataBoundItem as ViewModel) != null && (this.dataGridView1.SelectedRows[0].DataBoundItem as ViewModel).ViewProperties!=null)
                {
                    this.dataGridView2.DataSource = (this.dataGridView1.SelectedRows[0].DataBoundItem as ViewModel).ViewProperties;
                }
            }
            
        }

        void textBoxVMPath_LostFocus(object sender, EventArgs e)
        {
            if (SaveBack != null && SaveBack.ViewModels != null)
            {
                SaveBack.ViewModels.ForEach(it => it.Path = this.textBoxVMPath.Text.Trim());
            }
        }

        void textBoxVMNamespace_LostFocus(object sender, EventArgs e)
        {
            if (SaveBack != null && SaveBack.ViewModels != null)
            {
                SaveBack.ViewModels.ForEach(it => it.Namespace =this.textBoxVMNamespace.Text.Trim());
            }
        }

        private void buttonQNamspace_Click(object sender, EventArgs e)
        {
            ViewModelQFrm vmqf = new ViewModelQFrm();
            vmqf.Init(SaveBack != null && SaveBack.ViewModels != null && SaveBack.ViewModels.Count > 0 ? SaveBack.ViewModels.First().QuoteNamespace : null);
            if (vmqf.ShowDialog() == DialogResult.Cancel)
            {
                if (SaveBack != null && SaveBack.ViewModels != null)
                {
                    SaveBack.ViewModels.ForEach(it => it.QuoteNamespace = vmqf.ViewModelQuoteNamespace);
                }
            }
        }

        private void buttonVMG_Click(object sender, EventArgs e)
        {
            if (SaveBack != null) SaveBack.ViewModels = ViewModel.ConvertEntityToViewModel(SaveBack.EntityModels);
            this.dataGridView1.DataSource = SaveBack.ViewModels;
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            if (SaveBack != null && SaveBack.ViewModels != null && SaveBack.ViewModels.Count > 0)
            {
                SaveBack.ViewModels.ForEach(it => {
                    if (!Directory.Exists(it.Path + "\\" + it.DomainName))
                    {
                        Directory.CreateDirectory(it.Path + "\\" + it.DomainName);
                    }
                    if (this.checkBoxVM.Checked == false && File.Exists(it.Path + "\\" + it.DomainName +"\\"+ it.ClassName + ".cs")) return;

                    FileStream fs = new FileStream(it.Path + "\\" + it.DomainName + "\\" + it.ClassName + ".cs", FileMode.Create);
                    using (var sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("/*=============================================================");
                        sw.WriteLine(" * ===============auto-generated code           ===============");
                        sw.WriteLine(" * ===============Should Be Marked if modified=================");
                        sw.WriteLine(" * ==========================================================*/");
                        sw.WriteLine("");
                        sw.WriteLine("using System;");
                        sw.WriteLine("using System.Collections.Generic;");
                        sw.WriteLine("using System.ComponentModel;");
                        sw.WriteLine("using System.Linq;");
                        sw.WriteLine("using System.Text;");
                        if (it.QuoteNamespace != null && it.QuoteNamespace.Count > 0)
                        {
                            it.QuoteNamespace.ForEach(ep => sw.WriteLine(ep));
                        }
                        sw.WriteLine("");
                        sw.WriteLine("namespace " + it.Namespace);
                        sw.WriteLine("{");
                        if (it.IsClass)
                        {
                            sw.WriteLine("    /// <summary>");
                            sw.WriteLine("    /// " + it.Description + " 视图模型");
                            sw.WriteLine("    /// </summary>");
                            sw.WriteLine("    public partial class " + it.ClassName);
                            sw.WriteLine("    {");
                            if (it.ViewProperties != null && it.ViewProperties.Count > 0)
                            {
                                it.ViewProperties.ForEach(ep => {
                                    sw.WriteLine("");
                                    sw.WriteLine("        /// <summary>");
                                    sw.WriteLine("        /// " + ep.Description);
                                    sw.WriteLine("        /// </summary>");
                                    sw.Write("        public ");
                                    if (ep.IsGeneric)
                                    {
                                        sw.Write("List<" + ep.PropertyType + "> " + ep.PropertyName + " { get; set; }");
                                    }
                                    else
                                    {
                                        sw.Write("" + ep.PropertyType + " " + ep.PropertyName + " { get; set; }");
                                    }
                                    sw.WriteLine("");
                                });
                            }
                            sw.WriteLine("    }");
                        }
                        else if (it.IsEnum)
                        {
                            sw.WriteLine("    /// <summary>");
                            sw.WriteLine("    /// " + it.Description + " 枚举类");
                            sw.WriteLine("    /// </summary>");
                            sw.WriteLine("    public enum " + it.ClassName);
                            sw.WriteLine("    {");
                            if (it.ViewProperties != null && it.ViewProperties.Count > 0)
                            {
                                int count = 0;
                                it.ViewProperties.ForEach(ep => {
                                    if (count != 0)
                                    {
                                        sw.WriteLine(",");
                                    }
                                    sw.WriteLine("");
                                    sw.WriteLine("        /// <summary>");
                                    sw.WriteLine("        /// " + ep.Description);
                                    sw.WriteLine("        /// </summary>");
                                    sw.WriteLine("        [Description(\"" + ep.Description + "\")]");
                                    sw.Write("        " + ep.PropertyName);
                                    count++;
                                });
                            }
                            sw.WriteLine("    }");
                        }
                        sw.WriteLine("}");
                    }
                });
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ViewModelFrm vmf = new ViewModelFrm();
            if (vmf.ShowDialog()==DialogResult.OK)
            {
                var temp = vmf.ViewModel;
                if (SaveBack != null && SaveBack.ViewModels != null && SaveBack.ViewModels.Count > 0)
                {
                    temp.Namespace = SaveBack.ViewModels.First().Namespace;
                    temp.Path = SaveBack.ViewModels.First().Path;
                    temp.QuoteNamespace = SaveBack.ViewModels.First().QuoteNamespace;
                }
                else if (SaveBack != null)
                {
                    SaveBack.ViewModels = new List<ViewModel>();
                }
                SaveBack.ViewModels.Add(temp);
            }
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = SaveBack.ViewModels;
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                SaveBack.ViewModels.Remove((this.dataGridView1.SelectedRows[0].DataBoundItem as ViewModel));
            }
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = SaveBack.ViewModels;
        }

        private void buttonAddP_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0 && this.dataGridView2.RowCount >= 0)
            {
                ViewPropertyFrm vpf = new ViewPropertyFrm();
                if (vpf.ShowDialog() == DialogResult.OK)
                {
                    var temp = this.dataGridView1.SelectedRows[0].DataBoundItem as ViewModel;
                    if (temp.ViewProperties == null) temp.ViewProperties = new List<ViewProperty>();
                    temp.ViewProperties.Add(vpf.ViewProperty);
                    this.dataGridView2.DataSource = null;
                    this.dataGridView2.DataSource = temp.ViewProperties;
                }
            }
        }

        private void buttonDelP_Click(object sender, EventArgs e)
        {

        }

        public void Init(int heigth, int width)
        {
            this.Height = heigth;
            this.Width = width;
            //this.dataGridView1.Width = width;
            this.dataGridView1.Height = heigth - 60;
            this.dataGridView2.Height = heigth - 60;
            //this.SaveBack = saveBack;
            this.dataGridView1.DataSource = SaveBack.ViewModels;
            if (SaveBack != null && SaveBack.ViewModels != null && SaveBack.ViewModels.Count > 0)
            {
                this.textBoxVMPath.Text = SaveBack.ViewModels.First().Path;
                this.textBoxVMNamespace.Text = SaveBack.ViewModels.First().Namespace;
            }
        }
   }
}
