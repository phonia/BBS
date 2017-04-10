using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace BBS2._0.Cache
{
    public class CacheInterceptor : IInterceptionBehavior
    {
        private static ServiceCache _cache = new ServiceCache();

        #region IInterceptionBehavior 成员

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return this.GetType().GetInterfaces();
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            String className = input.MethodBase.DeclaringType.FullName;
            String methodName = input.MethodBase.Name;
            var attrs = input.MethodBase.GetCustomAttributes(false);
            if (attrs == null) return getNext()(input, getNext);
            foreach (var item in attrs)
            {
                if (!(item is CacheAttribute)) continue;
                else
                {
                    CacheAttribute attr = item as CacheAttribute;
                    String keyParam = GetKeyParam(attr.CacheMethod, input.Inputs);
                    switch (attr.CacheMethod)
                    {
                        case CacheMethod.GetCollection:
                            var retValue = _cache.Get(attr.Key, methodName+"-"+keyParam);
                            if (retValue == null)
                            {
                                var getValue = getNext()(input, getNext);
                                _cache.Add(attr.Key, methodName + "-" + keyParam, getValue);
                                return getValue;
                            }
                            else
                            {
                                //var args = new object[input.Arguments.Count];
                                //input.Arguments.CopyTo(args, 0);
                                //return new VirtualMethodReturn(input, retValue, args);
                                return (IMethodReturn)retValue;
                            }
                        case CacheMethod.RemoveCollection:
                            _cache.Remove(attr.Key);
                            break;
                        default: break;
                    }
                    break;
                }

            }
            return getNext()(input, getNext);
        }

        String GetKeyParam(CacheMethod cacheMethod,IParameterCollection inputs)
        {
            StringBuilder sb = new StringBuilder();
            sb.ToString();
            sb.Append(cacheMethod.ToString());
            if (inputs != null && inputs.Count > 0)
            {
                foreach (var item in inputs)
                {
                    sb.Append("-");
                    sb.Append(item.ToString());
                }
            }
            return sb.ToString();
        }

        object Cached(String key,String keyparam)
        {
            return null;
        }

        public bool WillExecute
        {
            //get { throw new NotImplementedException(); }
            get { return true; }
        }

        #endregion
    }
}