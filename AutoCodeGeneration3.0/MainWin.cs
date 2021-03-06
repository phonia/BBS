﻿using System;
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
        private static object _lockObject = new object();

        public List<DataRecord> DataRecords { get; set; }

        public SaveBack SaveBack { get; set; }

        public MainWin()
        {
            InitializeComponent();
            this.textBox1.Text = @"E:\Code\BBS\数据字典III.xls";
            this.textBox2.Text = @"E:\Code\BBS";
            this.textBox2.ReadOnly = true;
            this.FormClosing += MainWin_FormClosing;
            this.MaximizeBox = false;
            //SaveBack = new SaveBack();
        }

        void MainWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                lock (_lockObject)
                {
                    var fs = new FileStream(this.textBox2.Text + "\\Sav.txt", FileMode.OpenOrCreate);
                    BinaryFormatter bf = new BinaryFormatter();

                    //if (SaveBack == null) SaveBack = new SaveBack();
                    if (SaveBack.EntityModels == null) SaveBack.EntityModels = new List<EntityModel>();
                    if (SaveBack.ViewModels == null) SaveBack.ViewModels = new List<ViewModel>();

                    bf.Serialize(fs, SaveBack);
                    fs.Close();
                    fs.Dispose();
                }
            }
            catch (Exception ex)
            {
                lock (_lockObject)
                {
                    var fs = new FileStream(this.textBox2.Text + "\\Sav.txt", FileMode.OpenOrCreate);
                    BinaryFormatter bf = new BinaryFormatter();

                    //if (SaveBack == null) SaveBack = new SaveBack();
                    if (SaveBack.EntityModels == null) SaveBack.EntityModels = new List<EntityModel>();
                    if (SaveBack.ViewModels == null) SaveBack.ViewModels = new List<ViewModel>();

                    bf.Serialize(fs, SaveBack);
                    fs.Close();
                    fs.Dispose();
                }
            }
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
                    lock (_lockObject)
                    {
                        var fs = new FileStream(this.textBox2.Text + "\\Sav.txt", FileMode.Open);
                        BinaryFormatter bf = new BinaryFormatter();
                        //People p = bf.Deserialize(fs) as People;
                        this.SaveBack = bf.Deserialize(fs) as SaveBack;
                        Reset(fromExcel, SaveBack.EntityModels);
                        fs.Close();
                        fs.Dispose();
                    }
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
            if (this.tabControl1.Controls.Count > 0) this.tabControl1.Controls.Clear();
        }

        void Reset(List<EntityModel> excel, List<EntityModel> bck)
        {
            if (bck != null && bck.Count > 0)
            {
                excel.ForEach(it => {
                    var temp = bck.Where(b => b.ClassName == it.ClassName && b.DomainName == it.DomainName).FirstOrDefault();
                    if (temp != null)
                    {
                        it.ConfigurationQuoteNamespaces = temp.ConfigurationQuoteNamespaces;
                        it.EntityQuoteNamespaces = temp.EntityQuoteNamespaces;
                        it.IRepositoryQuoteNamespaces = temp.IRepositoryQuoteNamespaces;
                        it.RepositoryQuoteNamespaces = temp.RepositoryQuoteNamespaces;
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
                        it.DataContextQuoteNamespaces = temp.DataContextQuoteNamespaces;
                    }
                    else
                    {
                        var first = bck.FirstOrDefault();
                        if (first != null)
                        {
                            it.ConfigurationQuoteNamespaces = first.ConfigurationQuoteNamespaces;
                            it.EntityQuoteNamespaces = first.EntityQuoteNamespaces;
                            it.IRepositoryQuoteNamespaces = first.IRepositoryQuoteNamespaces;
                            it.RepositoryQuoteNamespaces = first.RepositoryQuoteNamespaces;
                            it.EntityPath = first.EntityPath;
                            it.EntityNamespace = first.EntityNamespace;
                            it.IRepositoryNamespace = first.IRepositoryNamespace;
                            it.IRepositoryPath = first.IRepositoryPath;
                            it.RepositoryNamespace = first.RepositoryNamespace;
                            it.RepositoryPath = first.RepositoryPath;
                            it.ConfigurationNamespace = first.ConfigurationNamespace;
                            it.ConfigurationPath = first.ConfigurationPath;
                            it.DataContextNamespace = first.DataContextNamespace;
                            it.DataContextPath = first.DataContextPath;
                            it.DataContextQuoteNamespaces = first.DataContextQuoteNamespaces;
                        }
                    }
                });
            }
            //this.EntityModels = excel;
            if (this.SaveBack == null) this.SaveBack = new SaveBack();
            this.SaveBack.EntityModels = excel;
        }

        void ReadBak()
        {
            lock (_lockObject)
            { }
        }

        void WriteBak()
        {
            lock (_lockObject)
            { }
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
                euc.SaveBack = this.SaveBack;
                euc.Init(tp.Height, tp.Width);
                tp.Controls.Add(euc);
            }
        }

        private void ViewModelBtn_Click(object sender, EventArgs e)
        {
            if (DataRecords == null) Init();
            TabPage tp = GetTabPage("视图模型");
            if (tp != null)
            {
                ViewModelUControl vmuc = new ViewModelUControl();
                vmuc.SaveBack = this.SaveBack;
                vmuc.Init(tp.Height,tp.Width);
                tp.Controls.Add(vmuc);
            }
        }

        private void BusinessBtn_Click(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            lock (_lockObject)
            {
                var fs = new FileStream(this.textBox2.Text + "\\Sav.txt", FileMode.OpenOrCreate);
                BinaryFormatter bf = new BinaryFormatter();

                //if (SaveBack == null) SaveBack = new SaveBack();
                if (SaveBack.EntityModels == null) SaveBack.EntityModels = new List<EntityModel>();
                if (SaveBack.ViewModels == null) SaveBack.ViewModels = new List<ViewModel>();

                bf.Serialize(fs, SaveBack);
                fs.Close();
                fs.Dispose();
            }
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            Init();
        }

        #endregion
    }
}
