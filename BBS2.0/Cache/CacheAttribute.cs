using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBS2._0.Cache
{
    public class CacheAttribute:Attribute
    {
        public CacheMethod CacheMethod { get; set; }
        public String Key { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cacheMethod"></param>
        /// <param name="key">尽量采用实体类型名称</param>
        public CacheAttribute(CacheMethod cacheMethod,String key)
        {
            this.CacheMethod = cacheMethod;
            this.Key = key;
        }
    }
}