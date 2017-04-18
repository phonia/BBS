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

        }

        private void buttonDelP_Click(object sender, EventArgs e)
        {

        }

        public void Init(SaveBack saveBack, int heigth, int width)
        {
            this.Height = heigth;
            this.Width = width;
            //this.dataGridView1.Width = width;
            this.dataGridView1.Height = heigth - 60;
            this.dataGridView2.Height = heigth - 60;
            this.SaveBack = saveBack;
            this.dataGridView1.DataSource = SaveBack.ViewModels;
        }
   }
}
