using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Utils
{
    /// <summary>
    /// 单例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingleBase<T> where T : new()
    {
        private static T _instance = default(T);
        private static readonly object lockHelper = new object();
        /// <summary>
        /// 获取或创建实例
        /// </summary>
        /// <returns></returns>
        public static T GetInstance()
        {
            if (_instance == null)
            {
                lock (lockHelper)
                {
                    if (_instance == null)
                    {
                        _instance = new T();
                    }
                }
            }
            return _instance;
        }
    }
}
