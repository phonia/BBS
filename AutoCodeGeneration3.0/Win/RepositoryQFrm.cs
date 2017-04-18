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
    public partial class RepositoryQFrm : Form
    {
        public List<String> ReposiotryQuoteNamespace { get; set; }

        public RepositoryQFrm()
        {
            InitializeComponent();
        }

        public void Init(List<String> repositoryQuoteNamespace)
        {
            if (repositoryQuoteNamespace != null && repositoryQuoteNamespace.Count > 0)
            {
                this.ReposiotryQuoteNamespace = repositoryQuoteNamespace;
                this.listBox1.DataSource = this.ReposiotryQuoteNamespace;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (this.ReposiotryQuoteNamespace == null) this.ReposiotryQuoteNamespace = new List<string>();
            if (this.ReposiotryQuoteNamespace.Where(it => it.Equals(this.textBox1.Text.Trim())).FirstOrDefault()==null)
            {
                this.ReposiotryQuoteNamespace.Add(this.textBox1.Text.Trim());
                this.listBox1.DataSource = null;
                this.listBox1.DataSource = this.ReposiotryQuoteNamespace;
            }
            else
            {
                MessageBox.Show("不能引用重复的名称空间");
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex < 0) return;
            this.ReposiotryQuoteNamespace.RemoveAt(this.listBox1.SelectedIndex);
            this.listBox1.DataSource = null;
            this.listBox1.DataSource = this.ReposiotryQuoteNamespace;
        }
    }
}
