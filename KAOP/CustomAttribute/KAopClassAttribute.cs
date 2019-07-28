/*
 * CLR Version：4.0.30319.42000
 * NameSpace：KAOP
 * FileName：KAOPAttribute
 * CurrentYear：2019
 * CurrentTime：2019/7/27 8:53:39
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2019/7/27 8:53:39 新規作成 (by shaocx)
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace KAOP
{
    /// <summary>
    /// KAOP类特性
    /// 切面
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class KAopClassAttribute : ContextAttribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public KAopClassAttribute() : base("KAopClass") { }
        /// <summary>
        /// 方法执行前的动作
        /// </summary>
        /// <param name="MethodName">方法名</param>
        /// <param name="InParams">方法参数</param>
        public abstract void PreExcute(string MethodName, IDictionary<string, object> InParams);

        /// <summary>
        /// 方法执行后的动作
        /// </summary>
        /// <param name="MethodName">方法名</param>
        /// <param name="OutParams">方法参数</param>
        /// <param name="ReturnValue">返回值</param>
        /// <param name="ex">异常信息</param>
        public abstract void EndExcute(string MethodName, IDictionary<string, object> InParams, object[] OutParams, object ReturnValue, Exception ex);

        /// <summary>
        /// IConstructionCallMessage
        /// 当用户创建新的客户端激活对象的实例通过调用new或Activator.CreateInstance和线程返回到用户代码之前IConstructionCallMessage发送到远程应用程序。
        /// 构造消息到达远程应用程序，通过远程处理激活器处理 (一个，或一个中指定的默认Activator属性)，并创建一个新的对象。
        /// 然后，远程处理应用程序返回IConstructionReturnMessage到本地应用程序。
        /// IConstructionReturnMessage包含的一个实例ObjRef，哪些程序包的远程对象有关的信息。 
        /// 远程处理基础结构将转换ObjRef到返回到用户代码的远程对象的代理的实例。
        /// </summary> 
        public override void GetPropertiesForNewContext(IConstructionCallMessage ctorMsg)
        {
            ctorMsg.ContextProperties.Add(new KibaContextProperty(this));
        }
    }
}
