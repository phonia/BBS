using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoCodeGeneration3._0.UControl;
using AutoCodeGeneration3._0.Win;

namespace AutoCodeGeneration3._0
{
    public partial class MainWin : Form
    {
        public List<DataRecord> DataRecords { get; set; }

        public MainWin()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        public void Init()
        {
            try
            {
                this.textBox1.Text = @"E:\Code\BBS\数据字典III.xls";
                this.textBox2.Text = Directory.GetCurrentDirectory().ToString();
                this.textBox2.ReadOnly = true;
                this.DataRecords = DataDictionary.GetDataDictionary(this.textBox1.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 返回待设定的TabPageOrNULL
        /// </summary>
        /// <param name="tabPageName"></param>
        /// <returns>返回待设定的TabPageOrNULL</returns>
        TabPage GetTabPage(String tabPageName)
        {
            TabPage tp = null;
            foreach (var item in this.tabControl1.Controls)
            {
                if ((item as TabPage).Name.Equals(tabPageName))
                    tp = item as TabPage;
            }
            if (tp == null)
            {
                tp = new TabPage();
                tp.Text = tabPageName;
                tp.Name = tabPageName;
                this.tabControl1.Controls.Add(tp);
                this.tabControl1.SelectedTab = tp;
                return tp;
            }
            else
            {
                tabControl1.SelectedTab = tp;
                return null;
            }
        }

        #region BtnEvent

        private void filebtn_Click(object sender, EventArgs e)
        {
            TabPage tp = GetTabPage("数据字典");
            if (tp != null)
            {
                DataDictionaryUControl dduc = new DataDictionaryUControl();
                tp.Controls.Add(dduc);
                dduc.Init(tp.Height, tp.Width, DataRecords);
            }
        }

        private void EntityBtn_Click(object sender, EventArgs e)
        {
            TabPage tp = GetTabPage("实体模型");
            if (tp != null)
            {
                EntityUControl euc = new EntityUControl();
                tp.Controls.Add(euc);
            }
        }

        private void DataBaseBtn_Click(object sender, EventArgs e)
        {

        }

        private void RepositoryBtn_Click(object sender, EventArgs e)
        {

        }

        private void ViewModelBtn_Click(object sender, EventArgs e)
        {

        }

        private void BusinessBtn_Click(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
