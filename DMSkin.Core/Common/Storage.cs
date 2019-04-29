﻿using System.Collections.Generic;

namespace YWK.OSA.Common
{
    /// <summary>
    /// 内存数据存储
    /// </summary>
    public class Storage
    {
        #region 初始化
        private static Dictionary<string,object> StorageData;
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Initialize()
        {
            StorageData = new Dictionary<string, object>();
        }
        #endregion

        #region 保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        public static bool SaveData<T>(string key, T data)
        {
            if (StorageData.ContainsKey(key))
            {
                //存在这个Key所以更新数据
                StorageData[key] = data;
            }
            else
            {
                StorageData.Add(key, data);
            }
            return true;
        }
        #endregion

        #region 查找数据
        /// <summary>
        /// 查找数据
        /// </summary>
        public static T GetData<T>(string name)
        {
            if (StorageData.ContainsKey(name))
            {
                if (StorageData[name] is T data)
                {
                    return data;
                }
            }
            return default;
        }
        #endregion

        #region 删除数据
        /// <summary>
        /// 删除数据
        /// </summary>
        public static bool DelData<T>(string name)
        {
            return StorageData.Remove(name);
        }
        #endregion

        #region 销毁全部
        /// <summary>
        /// 销毁全部
        /// </summary>
        public static void Destroy()
        {
            StorageData.Clear();
        } 
        #endregion
    }
}
