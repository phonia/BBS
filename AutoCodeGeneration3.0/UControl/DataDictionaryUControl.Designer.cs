namespace AutoCodeGeneration3._0.Win
{
    partial class DataDictionaryUControl
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SelectBtn = new System.Windows.Forms.Button();
            this.DomainName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PropertyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PropertyType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsIdentity = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsNULL = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DefaultValues = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReferenceTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DomainName,
            this.TableName,
            this.ClassName,
            this.FieldName,
            this.PropertyName,
            this.FieldType,
            this.PropertyType,
            this.Key,
            this.IsIdentity,
            this.IsNULL,
            this.DefaultValues,
            this.FieldDescription,
            this.ReferenceTable,
            this.MaxLength});
            this.dataGridView1.Location = new System.Drawing.Point(3, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(639, 333);
            this.dataGridView1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(26, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(163, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 2;
            // 
            // SelectBtn
            // 
            this.SelectBtn.Location = new System.Drawing.Point(289, 17);
            this.SelectBtn.Name = "SelectBtn";
            this.SelectBtn.Size = new System.Drawing.Size(75, 23);
            this.SelectBtn.TabIndex = 3;
            this.SelectBtn.Text = "筛选";
            this.SelectBtn.UseVisualStyleBackColor = true;
            this.SelectBtn.Click += new System.EventHandler(this.SelectBtn_Click);
            // 
            // DomainName
            // 
            this.DomainName.DataPropertyName = "DomainName";
            this.DomainName.HeaderText = "所属模块";
            this.DomainName.Name = "DomainName";
            this.DomainName.ReadOnly = true;
            // 
            // TableName
            // 
            this.TableName.DataPropertyName = "TableName";
            this.TableName.HeaderText = "数据表名";
            this.TableName.Name = "TableName";
            this.TableName.ReadOnly = true;
            // 
            // ClassName
            // 
            this.ClassName.DataPropertyName = "ClassName";
            this.ClassName.HeaderText = "类名";
            this.ClassName.Name = "ClassName";
            this.ClassName.ReadOnly = true;
            // 
            // FieldName
            // 
            this.FieldName.DataPropertyName = "FieldName";
            this.FieldName.HeaderText = "字段名称";
            this.FieldName.Name = "FieldName";
            this.FieldName.ReadOnly = true;
            // 
            // PropertyName
            // 
            this.PropertyName.DataPropertyName = "PropertyName";
            this.PropertyName.HeaderText = "属性名称";
            this.PropertyName.Name = "PropertyName";
            this.PropertyName.ReadOnly = true;
            // 
            // FieldType
            // 
            this.FieldType.DataPropertyName = "FieldType";
            this.FieldType.HeaderText = "字段类型";
            this.FieldType.Name = "FieldType";
            this.FieldType.ReadOnly = true;
            // 
            // PropertyType
            // 
            this.PropertyType.DataPropertyName = "PropertyType";
            this.PropertyType.HeaderText = "属性类型";
            this.PropertyType.Name = "PropertyType";
            this.PropertyType.ReadOnly = true;
            // 
            // Key
            // 
            this.Key.DataPropertyName = "Key";
            this.Key.HeaderText = "主键";
            this.Key.Name = "Key";
            this.Key.ReadOnly = true;
            this.Key.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // IsIdentity
            // 
            this.IsIdentity.DataPropertyName = "IsIdentity";
            this.IsIdentity.HeaderText = "自增";
            this.IsIdentity.Name = "IsIdentity";
            this.IsIdentity.ReadOnly = true;
            this.IsIdentity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsIdentity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IsNULL
            // 
            this.IsNULL.DataPropertyName = "IsNULL";
            this.IsNULL.HeaderText = "空值";
            this.IsNULL.Name = "IsNULL";
            this.IsNULL.ReadOnly = true;
            this.IsNULL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsNULL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DefaultValues
            // 
            this.DefaultValues.DataPropertyName = "DefaultValues";
            this.DefaultValues.HeaderText = "默认值";
            this.DefaultValues.Name = "DefaultValues";
            this.DefaultValues.ReadOnly = true;
            // 
            // FieldDescription
            // 
            this.FieldDescription.DataPropertyName = "FieldDescription";
            this.FieldDescription.HeaderText = "字段说明";
            this.FieldDescription.Name = "FieldDescription";
            this.FieldDescription.ReadOnly = true;
            // 
            // ReferenceTable
            // 
            this.ReferenceTable.DataPropertyName = "ReferenceTable";
            this.ReferenceTable.HeaderText = "参考表";
            this.ReferenceTable.Name = "ReferenceTable";
            this.ReferenceTable.ReadOnly = true;
            // 
            // MaxLength
            // 
            this.MaxLength.DataPropertyName = "MaxLength";
            this.MaxLength.HeaderText = "最大长度";
            this.MaxLength.Name = "MaxLength";
            this.MaxLength.ReadOnly = true;
            // 
            // DataDictionaryUControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SelectBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DataDictionaryUControl";
            this.Size = new System.Drawing.Size(645, 379);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button SelectBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DomainName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldType;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsIdentity;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsNULL;
        private System.Windows.Forms.DataGridViewTextBoxColumn DefaultValues;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReferenceTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxLength;

    }
}
