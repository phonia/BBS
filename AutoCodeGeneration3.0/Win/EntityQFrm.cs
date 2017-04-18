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
    public partial class EntityQFrm : Form
    {
        public List<String> EntityQuoteNamespace { get; set; }

        public EntityQFrm()
        {
            InitializeComponent();
        }

        public void Init(List<String> entityQuoteNamespace)
        {
            if (entityQuoteNamespace != null && entityQuoteNamespace.Count > 0)
            {
                this.EntityQuoteNamespace = entityQuoteNamespace;
                this.listBox1.DataSource = EntityQuoteNamespace;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (EntityQuoteNamespace == null) EntityQuoteNamespace = new List<string>();
            if (EntityQuoteNamespace.Where(it => it.Equals(this.textBox1.Text.Trim())).FirstOrDefault() != null)
            {
                MessageBox.Show("不能添加同样的名称空间");
            }
            else
            {
                EntityQuoteNamespace.Add(this.textBox1.Text.Trim());
                this.listBox1.DataSource = null;
                this.listBox1.DataSource = EntityQuoteNamespace;
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex < 0) return;
            EntityQuoteNamespace.RemoveAt(this.listBox1.SelectedIndex);
            this.listBox1.DataSource = null;
            this.listBox1.DataSource = EntityQuoteNamespace;
        }
    }
}
