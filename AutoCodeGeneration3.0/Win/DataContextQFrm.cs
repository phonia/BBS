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
    public partial class DataContextQFrm : Form
    {
        public List<String> DataContextQuoteNamespace { get; set; }

        public DataContextQFrm()
        {
            InitializeComponent();
        }

        public void Init(List<String> dataContextQuoteNamespace)
        {
            if (dataContextQuoteNamespace != null && dataContextQuoteNamespace.Count > 0)
            {
                this.DataContextQuoteNamespace = dataContextQuoteNamespace;
                this.listBox1.DataSource = this.DataContextQuoteNamespace;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (this.DataContextQuoteNamespace == null) this.DataContextQuoteNamespace = new List<string>();
            if (this.DataContextQuoteNamespace.Where(it => it.Equals(this.textBox1.Text.Trim())).FirstOrDefault() == null)
            {
                this.DataContextQuoteNamespace.Add(this.textBox1.Text.Trim());
                this.listBox1.DataSource = null;
                this.listBox1.DataSource = this.DataContextQuoteNamespace;
            }
            else
            {
                MessageBox.Show("不能引用的重复的名称空间");
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex < 0) return;
            this.DataContextQuoteNamespace.RemoveAt(this.listBox1.SelectedIndex);
            this.listBox1.DataSource = null;
            this.listBox1.DataSource = this.DataContextQuoteNamespace;
        }
    }
}
