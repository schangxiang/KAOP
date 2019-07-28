/*
 * CLR Version：4.0.30319.42000
 * NameSpace：KAOPSample
 * FileName：MyLogAttribute
 * CurrentYear：2019
 * CurrentTime：2019/7/27 8:51:32
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2019/7/27 8:51:32 新規作成 (by shaocx)
 */


using KAOP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAOPSample
{
    [AttributeUsage(AttributeTargets.All)]
    public class MyLogAttribute : KAopClassAttribute
    {
        public override void PreExcute(string MethodName, IDictionary<string, object> InParams)
        {

            Logger.Info("==================== " + MethodName + ":" + " Start====================");
            Logger.Info(string.Format("参数数量：{0}", InParams.Count()));

            int i = 0;
            foreach (var item in InParams)
            {
                Logger.Info(string.Format("参数序号[{0}] ============    参数类型：{1}    执行类：{1}", i + 1, item.Value));
                Logger.Info("传入参数：");
                string paramXMLstr = JsonConvert.SerializeObject((item.Value));
                Logger.Info(paramXMLstr);
                //Console.WriteLine(paramXMLstr);
                i++;
            }

            foreach (var item in InParams)
            {
                var para = item.Value;
                var type = para.GetType();
                string typename = type.ToString().Replace("System.Nullable`1[", "").Replace("]", "").Replace("System.", "").ToLower();
                if (typename == "int32")
                {
                    int inparame = Convert.ToInt16(item.Value);
                    if (inparame < 0)
                    {
                        throw new Exception("异常出现了哦");
                    }
                }
            }
        }

        /// <summary>
        /// 后处理
        /// </summary> 
        public override void EndExcute(string MethodName, IDictionary<string, object> InParams, object[] OutParams, object ReturnValue, Exception ex)
        {
            Type myType = ReturnValue.GetType();
            Logger.Info(string.Format("返回值类型：{0}", myType.Name));
            Logger.Info("返回值：");
            if (myType.Name != "Void")
            {
                string resXMLstr = JsonConvert.SerializeObject(ReturnValue);
                Logger.Info(resXMLstr);
            }

            if (OutParams.Count() > 0)//out 返回参数
            {
                Logger.Info(string.Format("out返回参数数量：{0}", OutParams.Count()));
                for (int i = 0; i < OutParams.Count(); i++)
                {
                    Logger.Info(string.Format("参数序号[{0}] == 参数值：{1}", i + 1, OutParams[i]));
                }
            }

            if (ex != null)
            {
                Logger.Error(ex);
            }
            Logger.Info("==================== " + MethodName + ":" + " End====================");
        }
    }
}
