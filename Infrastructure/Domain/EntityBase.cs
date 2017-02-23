using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Infrastructure
{
    public abstract class EntityBase
    {
        private List<BusinessRule> _broken = new List<BusinessRule>();

        /// <summary>
        /// 新运行base.Validate
        /// </summary>
        protected virtual void Validate()
        {
        }

        protected void AddBrokenRule(BusinessRule rule)
        {
            if (rule == null) return;
            if (_broken == null) _broken = new List<BusinessRule>();
            _broken.Add(rule);
        }

        public IEnumerable<BusinessRule> GetBrokens()
        {
            _broken.Clear();
            Validate();
            return _broken;
        }

        /// <summary>
        /// check this is equal the obj
        /// and just check the property which is value type
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {

            if (this.GetType() != obj.GetType()
                && !(this.GetType().BaseType == obj.GetType() && !(obj.GetType() == typeof(object)))
                && !(this.GetType() == obj.GetType().BaseType && !(this.GetType() == typeof(object)))
                )
                return false;

            PropertyInfo[] properties = this.GetType().GetProperties();
            PropertyInfo[] objProperties = obj.GetType().GetProperties();
            if (properties == null && objProperties == null) return true;

            if (properties != null && objProperties != null && properties.Count() == 0 && objProperties.Count() == 0) return true;

            if (properties != null && objProperties != null && properties.Count() == objProperties.Count())
            {
                foreach (PropertyInfo item in properties)
                {
                    if (item.PropertyType.IsGenericType || item.PropertyType.IsClass)
                    {
                        continue;
                    }
                    PropertyInfo node = objProperties.Where(it => it.Name.Equals(item.Name)).FirstOrDefault();
                    if (node != null)
                    {
                        if (!node.GetValue(obj, null).Equals(item.GetValue(this, null)))
                            return false;
                    }
                    else
                        return false;
                }
                return true;
            }
            return false;
        }

    }
}
