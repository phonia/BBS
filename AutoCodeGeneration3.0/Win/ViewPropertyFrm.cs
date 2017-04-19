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
    public partial class ViewPropertyFrm : Form
    {
        public ViewProperty ViewProperty { get; set; }

        public ViewPropertyFrm()
        {
            InitializeComponent();
            this.button1.DialogResult = DialogResult.OK;
            this.button2.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewProperty = new ViewProperty() { 
                PropertyName=this.textBoxPName.Text.Trim(),
                PropertyType=this.textBoxPType.Text.Trim(),
                MappingPropertyName=this.textBoxEPName.Text.Trim(),
                MappingPropertyType=this.textBoxEPType.Text.Trim(),
                IsGeneric=this.checkBox1.Checked,
                IsMappingGeneric=this.checkBox1.Checked
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ViewProperty = null;
        }
    }
}
