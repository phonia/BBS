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
    public partial class IRepositoryQFrm : Form
    {
        public List<String> IRepositroyQuoteNamespace { get; set; }

        public IRepositoryQFrm()
        {
            InitializeComponent();
        }

        public void Init(List<String> irepositoryQuoteNamespace)
        {
            if (irepositoryQuoteNamespace != null && irepositoryQuoteNamespace.Count > 0)
            {
                this.IRepositroyQuoteNamespace = irepositoryQuoteNamespace;

                this.listBox1.DataSource = this.IRepositroyQuoteNamespace;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (this.IRepositroyQuoteNamespace == null) this.IRepositroyQuoteNamespace = new List<string>();
            if (this.IRepositroyQuoteNamespace.Where(it => it.Equals(this.textBox1.Text.Trim())).FirstOrDefault() == null)
            {
                this.IRepositroyQuoteNamespace.Add(this.textBox1.Text.Trim());
                this.listBox1.DataSource = null;
                this.listBox1.DataSource = this.IRepositroyQuoteNamespace;
            }
            else
            {
                MessageBox.Show("不能引用重复的名称空间");
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex < 0) return;
            this.IRepositroyQuoteNamespace.RemoveAt(this.listBox1.SelectedIndex);
            this.listBox1.DataSource = null;
            this.listBox1.DataSource = this.IRepositroyQuoteNamespace;
        }
    }
}
