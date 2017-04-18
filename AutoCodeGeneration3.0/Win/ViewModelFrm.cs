using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoCodeGeneration3._0.Code;

namespace AutoCodeGeneration3._0.Win
{
    public partial class ViewModelFrm : Form
    {
        public ViewModel ViewModel { get; set; }

        public ViewModelFrm()
        {
            InitializeComponent();
            this.buttonSave.DialogResult = DialogResult.OK;
            this.buttonCancel.DialogResult = DialogResult.Cancel;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.ViewModel = new ViewModel()
            {
                DomainName = this.textBox1.Text.Trim(),
                ClassName=this.textBox2.Text.Trim(),
                MappingEntityName=string.IsNullOrWhiteSpace(this.textBox3.Text.Trim())?string.Empty:this.textBox3.Text.Trim(),
            };
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
