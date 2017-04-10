using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBS2._0.Cache
{
    public interface ICache {
        bool Add(String key, String keyParam, object value);
        bool Remove(String key, String keyParam);
        bool Remove(String key);
        object Get(String key, String keyParam);
    }

    public class ServiceCache:ICache
    {
        private List<CacheData> _data = new List<CacheData>();

        #region ICache 成员

        public bool Add(string key, string keyParam, object value)
        {
            CacheData cache = _data.Where(it => it.Key != null && it.Key.Equals(key)).FirstOrDefault();
            if (cache == null)
            {
                cache = new CacheData(key);
                cache.Add(keyParam, value);
                _data.Add(cache);
            }
            else
            {
                cache.Add(keyParam, value);
            }
            return true; ;
        }

        public bool Remove(string key, string keyParam)
        {
            CacheData cache = _data.Where(it => it.Key != null && it.Key.Equals(key)).FirstOrDefault();
            if (cache == null) return false;
            return cache.Remove(keyParam);
        }

        public bool Remove(string key)
        {
            CacheData cache = _data.Where(it => it.Key!=null&&it.Key.Equals(key)).FirstOrDefault();
            if (cache == null) return false;
            return _data.Remove(cache);
        }

        public object Get(string key, string keyParam)
        {
            CacheData cache = _data.Where(it => it.Key != null && it.Key.Equals(key)).FirstOrDefault();
            if (cache == null) return null;
            var value= cache.Value.Where(it => it.Key != null && it.Key.Equals(keyParam));
            if (value.Count() <= 0) return null;
            return value.First().Value;
        }

        #endregion
    }

    public class CacheData
    {
        public String Key { get; private set; }
        public Dictionary<String,object> Value { get; private set; }

        private CacheData() { }

        public CacheData(String key) { Value = new Dictionary<string, object>(); this.Key = key; }

        public bool Add(String param, object value)
        {
            Value.Add(param, value);
            return true;
        }

        //public Object Get(String param) { return null; }

        public bool Remove(String param)
        {
            this.Value.Clear();
            return true;
        }
    }

    public enum CacheMethod { 
        GetCollection,RemoveCollection
    }
}