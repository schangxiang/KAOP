/*
 * CLR Version：4.0.30319.42000
 * NameSpace：KAOP
 * FileName：ReHelper
 * CurrentYear：2019
 * CurrentTime：2019/7/27 12:45:35
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2019/7/27 12:45:35 新規作成 (by shaocx)
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace KAOP
{
    /// <summary>
    /// KAOP帮助类
    /// </summary>
    internal class KAOPHelper
    {
        /// <summary>
        /// 获取参数字典（不包括out参数）
        /// </summary>
        /// <param name="call">方法调用消息接口</param>
        /// <returns>参数字典</returns>
        public static IDictionary<string, object> GetParamDictionary(IMethodCallMessage call)
        {
            IDictionary<string, object> paramDict = new Dictionary<string, object>();
            for (int i = 0; i < call.InArgs.Length; i++)
            {
                paramDict.Add(call.GetInArgName(i), call.InArgs[i]);
            }
            return paramDict;
        }
        /// <summary>
        /// 验证是否KAopMethodAttribute特性
        /// </summary>
        /// <param name="call">方法调用消息接口</param>
        /// <returns>true：是；false：否</returns>
        public static bool IsHaveKAopMethod(IMethodCallMessage call)
        {
            Type _type = KAOPHelper.FindTypeInCurrentDomain(call.TypeName);
            var _arr = _type.GetMethod(call.MethodName).GetCustomAttributes(typeof(KAopMethodAttribute), false);
            if (_arr != null && _arr.Length > 0)
                return true;
            return false;
        }
        /// <summary>
        /// 根据类型名获取类型
        /// </summary>
        /// <param name="typeName">类型名</param>
        /// <returns>类型</returns>
        private static Type FindTypeInCurrentDomain(string typeName)
        {
            Type type = null;

            //如果该类型已经装载
            type = Type.GetType(typeName);
            if (type != null)
            {
                return type;
            }

            //在EntryAssembly中查找
            if (Assembly.GetEntryAssembly() != null)
            {
                type = Assembly.GetEntryAssembly().GetType(typeName);
                if (type != null)
                {
                    return type;
                }
            }

            //在CurrentDomain的所有Assembly中查找
            Assembly[] assemblyArray = AppDomain.CurrentDomain.GetAssemblies();
            int assemblyArrayLength = assemblyArray.Length;
            for (int i = 0; i < assemblyArrayLength; ++i)
            {
                type = assemblyArray[i].GetType(typeName);
                if (type != null)
                {
                    return type;
                }
            }

            for (int i = 0; (i < assemblyArrayLength); ++i)
            {
                Type[] typeArray = assemblyArray[i].GetTypes();
                int typeArrayLength = typeArray.Length;
                for (int j = 0; j < typeArrayLength; ++j)
                {
                    if (typeArray[j].Name.Equals(typeName))
                    {
                        return typeArray[j];
                    }
                }
            }

            return type;
        }

    }
}
