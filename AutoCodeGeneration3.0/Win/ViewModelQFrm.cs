using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoCodeGeneration3._0.Win
{
    public partial class ViewModelQFrm : Form
    {
        public List<String> ViewModelQuoteNamespace { get; set; }

        public ViewModelQFrm()
        {
            InitializeComponent();
        }

        public void Init(List<String> viewModelQN)
        {
            if (viewModelQN != null && viewModelQN.Count > 0)
            {
                this.ViewModelQuoteNamespace = viewModelQN;
                this.listBox1.DataSource = this.ViewModelQuoteNamespace;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (this.ViewModelQuoteNamespace == null) this.ViewModelQuoteNamespace = new List<string>();
            if (this.ViewModelQuoteNamespace.Where(it => it.Equals(this.textBox1.Text.Trim())).FirstOrDefault() == null)
            {
                this.ViewModelQuoteNamespace.Add(this.textBox1.Text.Trim());
                this.listBox1.DataSource = null;
                this.listBox1.DataSource = this.ViewModelQuoteNamespace;
            }
            else
            { }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex < 0) return;
            this.ViewModelQuoteNamespace.RemoveAt(this.listBox1.SelectedIndex);
            this.listBox1.DataSource = null;
            this.listBox1.DataSource = this.ViewModelQuoteNamespace;
        }
    }
}
