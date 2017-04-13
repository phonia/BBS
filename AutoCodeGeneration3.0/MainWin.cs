using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using AutoCodeGeneration3._0.Code;
using AutoCodeGeneration3._0.UControl;
using AutoCodeGeneration3._0.Win;

namespace AutoCodeGeneration3._0
{
    public partial class MainWin : Form
    {
        public List<DataRecord> DataRecords { get; set; }

        public List<EntityModel> EntityModels { get; set; }

        public MainWin()
        {
            InitializeComponent();
            this.textBox1.Text = @"E:\Code\BBS\数据字典III.xls";
            this.textBox2.Text = Directory.GetCurrentDirectory().ToString();
            this.textBox2.ReadOnly = true;
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        public void Init()
        {
            try
            {
                this.DataRecords = DataDictionary.GetDataDictionary(this.textBox1.Text);
                var fromExcel = EntityModel.ConvertToEntityModel(this.DataRecords);
                if (File.Exists(this.textBox2.Text + "\\Sav.txt"))
                {
                    var fs = new FileStream(this.textBox2.Text + "\\Sav.txt", FileMode.Open);
                    BinaryFormatter bf = new BinaryFormatter();
                    //People p = bf.Deserialize(fs) as People;
                    var fromBck = bf.Deserialize(fs) as List<EntityModel>;
                    Reset(fromExcel, fromBck);
                }
                else
                {
                    Reset(fromExcel, null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void Reset(List<EntityModel> excel, List<EntityModel> bck)
        {
            if (bck != null && bck.Count > 0)
            {
                excel.ForEach(it => {
                    var temp = bck.Where(b => b.ClassName == it.ClassName && b.DomainName == it.DomainName).FirstOrDefault();
                    if (temp != null)
                    {
                        it.ConfigurationAssemblies = temp.ConfigurationAssemblies;
                        it.EntityAssemblies = temp.EntityAssemblies;
                        it.IRepositoryAssemblies = temp.IRepositoryAssemblies;
                        it.RepositoryAssemblies = temp.RepositoryAssemblies;
                        it.EntityPath = temp.EntityPath;
                        it.EntityNamespace = temp.EntityNamespace;
                        it.IRepositoryNamespace = temp.IRepositoryNamespace;
                        it.IRepositoryPath = temp.IRepositoryPath;
                        it.RepositoryNamespace = temp.RepositoryNamespace;
                        it.RepositoryPath = temp.RepositoryPath;
                        it.ConfigurationNamespace = temp.ConfigurationNamespace;
                        it.ConfigurationPath = temp.ConfigurationPath;
                        it.DataContextNamespace = temp.DataContextNamespace;
                        it.DataContextPath = temp.DataContextPath;
                    }
                });
            }
            this.EntityModels = excel;
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
            if (DataRecords == null) Init();
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
            if (DataRecords == null) Init();
            TabPage tp = GetTabPage("实体模型");
            if (tp != null)
            {
                EntityUControl euc = new EntityUControl();
                euc.Init(EntityModels, tp.Height, tp.Width);
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
            var fs = new FileStream(this.textBox2.Text + "\\Sav.txt", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(fs, EntityModels);
            fs.Close();
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            Init();
        }

        #endregion
    }
}
