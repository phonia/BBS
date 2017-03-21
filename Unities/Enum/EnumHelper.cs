using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Unities
{
    public static class EnumHelper
    {
        public static String GetDescriptionOrNull(this Enum value)
        {
            Type enumType = value.GetType();

            String name = Enum.GetName(enumType, value);

            if (name != null)
            {
                FieldInfo fieldInfo = enumType.GetField(name);

                if (fieldInfo != null)
                {
                    DescriptionAttribute attr = Attribute.GetCustomAttribute(fieldInfo,
                        typeof(DescriptionAttribute), false) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }
    }
}
