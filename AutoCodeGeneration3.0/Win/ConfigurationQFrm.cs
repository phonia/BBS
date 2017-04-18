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
    public partial class ConfigurationQFrm : Form
    {
        public List<String> ConfigurationQuoteNamesapce { get; set; }

        public ConfigurationQFrm()
        {
            InitializeComponent();
        }

        public void Init(List<String> configurationQn)
        {
            if (configurationQn != null && configurationQn.Count > 0)
            {
                this.ConfigurationQuoteNamesapce = configurationQn;
                this.listBox1.DataSource = this.ConfigurationQuoteNamesapce;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (this.ConfigurationQuoteNamesapce == null) this.ConfigurationQuoteNamesapce = new List<string>();
            if (this.ConfigurationQuoteNamesapce.Where(it => it.Equals(this.textBox1.Text.Trim())).FirstOrDefault() == null)
            {
                this.ConfigurationQuoteNamesapce.Add(this.textBox1.Text.Trim());
                this.listBox1.DataSource = null;
                this.listBox1.DataSource = this.ConfigurationQuoteNamesapce;
            }
            else
            { }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex < 0) return;
            this.ConfigurationQuoteNamesapce.RemoveAt(this.listBox1.SelectedIndex);
            this.listBox1.DataSource = null;
            this.listBox1.DataSource = this.ConfigurationQuoteNamesapce;
        }
    }
}
