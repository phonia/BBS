namespace AutoCodeGeneration3._0.UControl
{
    partial class ViewModelUControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonQNamspace = new System.Windows.Forms.Button();
            this.buttonC = new System.Windows.Forms.Button();
            this.buttonVMG = new System.Windows.Forms.Button();
            this.textBoxVMNamespace = new System.Windows.Forms.TextBox();
            this.textBoxVMPath = new System.Windows.Forms.TextBox();
            this.checkBoxVM = new System.Windows.Forms.CheckBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonAddP = new System.Windows.Forms.Button();
            this.buttonDelP = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "视图模型路径：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(254, 135);
            this.dataGridView1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "命名空间：";
            // 
            // buttonQNamspace
            // 
            this.buttonQNamspace.Location = new System.Drawing.Point(669, 30);
            this.buttonQNamspace.Name = "buttonQNamspace";
            this.buttonQNamspace.Size = new System.Drawing.Size(75, 23);
            this.buttonQNamspace.TabIndex = 3;
            this.buttonQNamspace.Text = "引用空间";
            this.buttonQNamspace.UseVisualStyleBackColor = true;
            this.buttonQNamspace.Click += new System.EventHandler(this.buttonQNamspace_Click);
            // 
            // buttonC
            // 
            this.buttonC.Location = new System.Drawing.Point(750, 30);
            this.buttonC.Name = "buttonC";
            this.buttonC.Size = new System.Drawing.Size(75, 23);
            this.buttonC.TabIndex = 3;
            this.buttonC.Text = "生成代码文件";
            this.buttonC.UseVisualStyleBackColor = true;
            this.buttonC.Click += new System.EventHandler(this.buttonC_Click);
            // 
            // buttonVMG
            // 
            this.buttonVMG.Location = new System.Drawing.Point(5, 30);
            this.buttonVMG.Name = "buttonVMG";
            this.buttonVMG.Size = new System.Drawing.Size(103, 23);
            this.buttonVMG.TabIndex = 3;
            this.buttonVMG.Text = "初始化视图模型";
            this.buttonVMG.UseVisualStyleBackColor = true;
            this.buttonVMG.Click += new System.EventHandler(this.buttonVMG_Click);
            // 
            // textBoxVMNamespace
            // 
            this.textBoxVMNamespace.Location = new System.Drawing.Point(495, 3);
            this.textBoxVMNamespace.Name = "textBoxVMNamespace";
            this.textBoxVMNamespace.Size = new System.Drawing.Size(280, 21);
            this.textBoxVMNamespace.TabIndex = 4;
            // 
            // textBoxVMPath
            // 
            this.textBoxVMPath.Location = new System.Drawing.Point(98, 3);
            this.textBoxVMPath.Name = "textBoxVMPath";
            this.textBoxVMPath.Size = new System.Drawing.Size(320, 21);
            this.textBoxVMPath.TabIndex = 4;
            // 
            // checkBoxVM
            // 
            this.checkBoxVM.AutoSize = true;
            this.checkBoxVM.Checked = true;
            this.checkBoxVM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxVM.Location = new System.Drawing.Point(781, 5);
            this.checkBoxVM.Name = "checkBoxVM";
            this.checkBoxVM.Size = new System.Drawing.Size(72, 16);
            this.checkBoxVM.TabIndex = 5;
            this.checkBoxVM.Text = "是否覆盖";
            this.checkBoxVM.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(114, 30);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(94, 23);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "添加视图模型";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(214, 30);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(96, 23);
            this.buttonDel.TabIndex = 6;
            this.buttonDel.Text = "删除视图模型";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonAddP
            // 
            this.buttonAddP.Location = new System.Drawing.Point(317, 31);
            this.buttonAddP.Name = "buttonAddP";
            this.buttonAddP.Size = new System.Drawing.Size(101, 23);
            this.buttonAddP.TabIndex = 7;
            this.buttonAddP.Text = "添加视图属性";
            this.buttonAddP.UseVisualStyleBackColor = true;
            this.buttonAddP.Click += new System.EventHandler(this.buttonAddP_Click);
            // 
            // buttonDelP
            // 
            this.buttonDelP.Location = new System.Drawing.Point(426, 31);
            this.buttonDelP.Name = "buttonDelP";
            this.buttonDelP.Size = new System.Drawing.Size(96, 23);
            this.buttonDelP.TabIndex = 7;
            this.buttonDelP.Text = "删除视图属性";
            this.buttonDelP.UseVisualStyleBackColor = true;
            this.buttonDelP.Click += new System.EventHandler(this.buttonDelP_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(260, 60);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(590, 150);
            this.dataGridView2.TabIndex = 8;
            // 
            // ViewModelUControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.buttonDelP);
            this.Controls.Add(this.buttonAddP);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.checkBoxVM);
            this.Controls.Add(this.textBoxVMPath);
            this.Controls.Add(this.textBoxVMNamespace);
            this.Controls.Add(this.buttonVMG);
            this.Controls.Add(this.buttonC);
            this.Controls.Add(this.buttonQNamspace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "ViewModelUControl";
            this.Size = new System.Drawing.Size(858, 410);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonQNamspace;
        private System.Windows.Forms.Button buttonC;
        private System.Windows.Forms.Button buttonVMG;
        private System.Windows.Forms.TextBox textBoxVMNamespace;
        private System.Windows.Forms.TextBox textBoxVMPath;
        private System.Windows.Forms.CheckBox checkBoxVM;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonAddP;
        private System.Windows.Forms.Button buttonDelP;
        private System.Windows.Forms.DataGridView dataGridView2;


    }
}
