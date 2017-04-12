using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoCodeGeneration3._0.Code;

namespace AutoCodeGeneration3._0.UControl
{
    public partial class EntityUControl : UserControl
    {
        public List<EntityModel> EntityModel { get; set; }

        public EntityUControl()
        {
            InitializeComponent();
        }

        public void Init(List<DataRecord> dataRecords)
        {
            
        }

        void ConvertToEntityModel(List<DataRecord> dataRecords)
        {
            if (dataRecords == null || dataRecords.Count <= 0) return;
            List<EntityModel> models = new List<EntityModel>();
            foreach (var item in dataRecords)
            {
                if (item.IsClassRecord(dataRecords))
                {
                    EntityModel temp = new EntityModel()
                    {
                        ClassName = item.ClassName,
                        Description=item.FieldDescription,
                        Domain=item.DomainName,
                        EntityType=item.FieldType,
                        TableName=item.DataTableName
                    };
                }
            }
            models.ForEach(it => {
                dataRecords.Where(dr => dr.DataTableName.Equals(it.TableName))
                    .ToList()
                    .ForEach(dr => {
                        if (it.EntityProperties == null) it.EntityProperties = new List<EntityProperty>();
                        it.EntityProperties.Add(new EntityProperty()
                        {
                            FieldName = dr.FieldName,
                        });
                    });
            });
        }
    }
}
