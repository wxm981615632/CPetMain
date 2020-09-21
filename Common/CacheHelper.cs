using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace Common
{
    public class CacheHelper
    {
        /// <summary>
        /// 获取数据缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        public static object GetCache(string cacheKey)
        {
            var objCache = HttpRuntime.Cache.Get(cacheKey);
            return objCache;
        }
        /// <summary>
        /// 设置数据缓存
        /// </summary>
        public static void SetCache(string cacheKey, object objObject)
        {
            var objCache = HttpRuntime.Cache;
            objCache.Insert(cacheKey, objObject);
        }
        /// <summary>
        /// 设置数据缓存
        /// </summary>
        public static void SetCache(string cacheKey, object objObject, int timeout = 7200)
        {
            try
            {
                if (objObject == null) return;
                var objCache = HttpRuntime.Cache;
                //相对过期
                //objCache.Insert(cacheKey, objObject, null, DateTime.MaxValue, timeout, CacheItemPriority.NotRemovable, null);
                //绝对过期时间
                objCache.Insert(cacheKey, objObject, null, DateTime.Now.AddSeconds(timeout), TimeSpan.Zero, CacheItemPriority.High, null);
            }
            catch (Exception)
            {
                //throw;
            }
        }
        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        public static void RemoveAllCache(string cacheKey)
        {
            var cache = HttpRuntime.Cache;
            cache.Remove(cacheKey);
        }
        /// <summary>
        /// 移除全部缓存
        /// </summary>
        public static void RemoveAllCache()
        {
            var cache = HttpRuntime.Cache;
            var cacheEnum = cache.GetEnumerator();
            while (cacheEnum.MoveNext())
            {
                cache.Remove(cacheEnum.Key.ToString());
            }
        }
    }
    /**
     public IEnumerable<CompanyModel> FindCompanys()
        {
            var cache = CacheHelper.GetCache("commonData_Company");//先读取
            if (cache == null)//如果没有该缓存
            {
                var queryCompany = _base.CompanyModel();//从数据库取出
                var enumerable = queryCompany.ToList();
                CacheHelper.SetCache("commonData_Company", enumerable);//添加缓存
                return enumerable;
            }
            var result = (List<CompanyModel>)cache;//有就直接返回该缓存
            return result;
        } 
     */
}
