using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoCodeGeneration3._0.Win
{
    public partial class DataDictionaryUControl : UserControl
    {
        public List<DataRecord> DataRecords { get; private set; }

        public DataDictionaryUControl()
        {
            InitializeComponent();
        }

        public void Init(int height,int width,List<DataRecord> dataRecords)
        {
            this.DataRecords = dataRecords;
            this.dataGridView1.Width = (int)width;
            this.dataGridView1.Height = height-40;
            this.Width = width;
            this.Height = height;

            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = DataRecords;
            BindCombobox();
        }

        void BindCombobox()
        {
            this.comboBox1.Items.Add("模块");
            this.comboBox1.Items.Add("数据表");
            this.comboBox1.SelectedIndex = 0;
        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.textBox1.Text)) this.dataGridView1.DataSource = DataRecords;
            else
            {
                if (this.comboBox1.Text.Equals("模块"))
                {
                    //List<DataRecord> list = this.DataRecords.Where(it => it.DomainName.Equals(this.textBox1.Text)).ToList();
                    this.dataGridView1.DataSource = this.DataRecords.Where(it => it.DomainName.Equals(this.textBox1.Text)).ToList();
                }
                else if (this.comboBox1.Text.Equals("数据表"))
                {
                    this.dataGridView1.DataSource = this.DataRecords.Where(it => it.TableName.Equals(this.textBox1.Text)).ToList();
                }
                else
                { }
            }
        }
    }
}
