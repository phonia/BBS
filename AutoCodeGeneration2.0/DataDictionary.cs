using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoCodeGeneration2._0
{
    /// <summary>
    /// 加载数据字典excel表 仅在32位的目标平台上可以运行
    /// </summary>
    internal class DataDictionary
    {
        /// <summary>  
        /// 获取Excel文件数据表列表  
        /// </summary>  
        public static ArrayList GetExcelTables(string ExcelFileName)
        {
            DataTable dt = new DataTable();
            ArrayList TablesList = new ArrayList();
            if (File.Exists(ExcelFileName))
            {
                using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=Excel 8.0;Data Source=" + ExcelFileName))
                {
                    try
                    {
                        conn.Open();
                        dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                    }
                    catch (Exception exp)
                    {
                        throw exp;
                    }

                    //获取数据表个数  
                    int tablecount = dt.Rows.Count;
                    for (int i = 0; i < tablecount; i++)
                    {
                        string tablename = dt.Rows[i][2].ToString().Trim().TrimEnd('$');
                        if (TablesList.IndexOf(tablename) < 0)
                        {
                            TablesList.Add(tablename);
                        }
                    }
                }
            }
            return TablesList;
        }

        /// <summary>  
        /// 将Excel文件导出至DataTable(第一行作为表头)  
        /// </summary>  
        /// <param name="ExcelFilePath">Excel文件路径</param>  
        /// <param name="TableName">数据表名，如果数据表名错误，默认为第一个数据表名</param>  
        public static DataTable InputFromExcel(string ExcelFilePath, string TableName)
        {
            if (!File.Exists(ExcelFilePath))
            {
                throw new Exception("Excel文件不存在！");
            }

            //如果数据表名不存在，则数据表名为Excel文件的第一个数据表  
            ArrayList TableList = new ArrayList();
            TableList = GetExcelTables(ExcelFilePath);

            if (TableList.IndexOf(TableName) < 0)
            {
                TableName = TableList[0].ToString().Trim();
            }

            DataTable table = new DataTable();
            OleDbConnection dbcon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ExcelFilePath + ";Extended Properties=Excel 8.0");
            OleDbCommand cmd = new OleDbCommand("select * from [" + TableName + "$]", dbcon);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

            try
            {
                if (dbcon.State == ConnectionState.Closed)
                {
                    dbcon.Open();
                }
                adapter.Fill(table);
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                if (dbcon.State == ConnectionState.Open)
                {
                    dbcon.Close();
                }
            }
            return table;
        }

        /// <summary>  
        /// 获取Excel文件指定数据表的数据列表  
        /// </summary>  
        /// <param name="ExcelFileName">Excel文件名</param>  
        /// <param name="TableName">数据表名</param>  
        public static ArrayList GetExcelTableColumns(string ExcelFileName, string TableName)
        {
            DataTable dt = new DataTable();
            ArrayList ColsList = new ArrayList();
            if (File.Exists(ExcelFileName))
            {
                using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=Excel 8.0;Data Source=" + ExcelFileName))
                {
                    conn.Open();
                    dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, TableName, null });

                    //获取列个数  
                    int colcount = dt.Rows.Count;
                    for (int i = 0; i < colcount; i++)
                    {
                        string colname = dt.Rows[i]["Column_Name"].ToString().Trim();
                        ColsList.Add(colname);
                    }
                }
            }
            return ColsList;
        }

        public static List<DataRecord> GetDataDictionary(String path)
        {
            ArrayList tabes = GetExcelTables(path);
            List<DataRecord> list = new List<DataRecord>();
            if (tabes != null)
            {
                foreach (var item in tabes)
                {
                    var records = InputFromExcel(path, item.ToString());
                    if (records != null)
                    {
                        for (int i = 0; i < records.Rows.Count; i++)
                        {
                            DataRecord dataRecord = new DataRecord();
                            dataRecord.ClassName = records.Rows[i]["数据表"] is DBNull ? String.Empty : records.Rows[i]["数据表"].ToString();
                            dataRecord.DataTableName = item.ToString()+"_"+(records.Rows[i]["数据表"] is DBNull ? String.Empty : records.Rows[i]["数据表"].ToString());
                            dataRecord.PropertyName = records.Rows[i]["字段名称(英文)"] is DBNull ? String.Empty : records.Rows[i]["字段名称(英文)"].ToString();
                            dataRecord.FieldName = records.Rows[i]["字段名称(英文)"] is DBNull ? String.Empty : records.Rows[i]["字段名称(英文)"].ToString();
                            dataRecord.FieldType = records.Rows[i]["字段类型/映射基类"] is DBNull ? String.Empty : records.Rows[i]["字段类型/映射基类"].ToString();
                            dataRecord.PropertyType = records.Rows[i]["属性类型"] is DBNull ? String.Empty : records.Rows[i]["属性类型"].ToString();
                            dataRecord.Key = records.Rows[i]["键"] is DBNull ? Key.NULL : records.Rows[i]["键"].ToString().ToLower().Equals("pk") ? Key.PK : Key.FK;
                            dataRecord.IsIdentity = records.Rows[i]["自增"] is DBNull ? false : true;
                            dataRecord.IsNUll = records.Rows[i]["允许空值"] is DBNull ? false : true;
                            dataRecord.DefaultValues = records.Rows[i]["默认值"] is DBNull ? String.Empty : records.Rows[i]["默认值"].ToString();
                            dataRecord.FieldDescription = records.Rows[i]["字段说明"] is DBNull ? String.Empty : records.Rows[i]["字段说明"].ToString();
                            dataRecord.ReferenceDataTable = records.Rows[i]["参考表"] is DBNull ? String.Empty : records.Rows[i]["参考表"].ToString();
                            dataRecord.referenceProperty = records.Rows[i]["参考字段"] is DBNull ? String.Empty : records.Rows[i]["参考字段"].ToString();
                            dataRecord.MaxLength = records.Rows[i]["长度"] is DBNull ? 0 : Convert.ToInt32(records.Rows[i]["长度"]);
                            list.Add(dataRecord);
                        }
                    }
                }
            }
            return list;
        }
    }

    public class DataRecord
    {
        /// <summary>
        /// 数据表明
        /// </summary>
        public String DataTableName { get; set; }
        /// <summary>
        /// 类名
        /// </summary>
        public String ClassName { get; set; }
        /// <summary>
        /// 字段名称
        /// </summary>
        public String FieldName { get; set; }
        /// <summary>
        /// 属性名称
        /// </summary>
        public String PropertyName { get; set; }
        /// <summary>
        /// 字段类型/映射属性
        /// </summary>
        public String FieldType { get; set; }
        /// <summary>
        /// 属性类型
        /// </summary>
        public String PropertyType { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        public Key Key { get; set; }
        /// <summary>
        /// 自增
        /// </summary>
        public bool IsIdentity { get; set; }
        /// <summary>
        /// 可为空
        /// </summary>
        public bool IsNUll { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        public String DefaultValues { get; set; }
        /// <summary>
        /// 字段说明
        /// </summary>
        public String FieldDescription { get; set; }
        /// <summary>
        /// 参考表
        /// </summary>
        public String ReferenceDataTable { get; set; }
        /// <summary>
        /// 参考字段
        /// </summary>
        public String referenceProperty { get; set; }
        /// <summary>
        /// 最大长度
        /// </summary>
        public Int32 MaxLength { get; set; }

        internal bool CanPersist()
        {
            if (String.IsNullOrWhiteSpace(ClassName)) return false;
            if (FieldType.Equals("EntityType")) return true;
            return false;
        }

        internal bool IsClassRecord(List<DataRecord> list)
        {
            if (String.IsNullOrWhiteSpace(ClassName)
                || String.IsNullOrWhiteSpace(FieldType)) return false;
            return isEntityType() || IsEnum() || IsComplexyType();
        }

        internal bool isEntityType()
        {
            if (FieldType.Equals("EntityType")) return true;
            return false;
        }

        internal bool IsClassProperty(string className)
        {
            if (this.ClassName.Equals(className) && !IsClassRecord(null)) return true;
            return false;
        }

        internal string ConvertToNullable()
        {
            if (PropertyType.Equals("Int32")
                || PropertyType.Equals("DateTime"))
                return PropertyType + "?";
            return PropertyType;
        }

        internal bool isReferenceRecord(string className)
        {
            if (ReferenceDataTable.Equals(className) && !String.IsNullOrWhiteSpace(referenceProperty)) return true;
            return false;
        }

        internal bool IsEnum()
        {
            if (FieldType.Equals("Enum")) return true;
            return false;
        }

        internal bool IsComplexyType()
        {
            if (FieldType.Equals("ComplexType")) return true;
            return false;
        }
    }

    public enum Key
    {
        PK, FK, NULL
    }
}
