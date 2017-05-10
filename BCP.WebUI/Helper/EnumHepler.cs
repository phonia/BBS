using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using ViewModel;

namespace BCP.WebUI.Helper
{
    public class EnumHepler
    {
        public static List<ComboboxDTO> ConvertEnumToComboboxDTO<T>()
        {
            List<ComboboxDTO> list = new List<ComboboxDTO>();

            foreach (int myCode in Enum.GetValues(typeof(T)))
            {
                string strName = Enum.GetName(typeof(T), myCode);//获取名称
                string strVaule = myCode.ToString();//获取值
                FieldInfo fieldInfo = typeof(T).GetField(strName);
                DescriptionAttribute attr = Attribute.GetCustomAttribute(fieldInfo,
                    typeof(DescriptionAttribute), false) as DescriptionAttribute;
                if (attr != null)
                {
                    list.Add(new ComboboxDTO() { Id = strVaule, Text = attr.Description });
                }
                else
                {
                    list.Add(new ComboboxDTO() { Id = strVaule, Text = strName });
                }
            }

            return list;
        }
    }
}