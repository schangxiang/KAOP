using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Messaging;

namespace KAOP
{
    /// <summary>
    /// 定义消息接收器。
    /// </summary>
    internal class KibaMessageSink : IMessageSink
    {
        //private KAspec kaspec = new KAspec();
        private IMessageSink nextSink;
        public KAopClassAttribute _kaopAttr = null;
        public KibaMessageSink(IMessageSink next, KAopClassAttribute kaopAttr)
        {
            nextSink = next;
            this._kaopAttr = kaopAttr;
        }
        public IMessageSink NextSink
        {
            get
            {
                return nextSink;
            }
        }
        public IMessage SyncProcessMessage(IMessage msg)
        {
            IMethodCallMessage call = msg as IMethodCallMessage;
            IDictionary<string, object> paramDict = null;
            if (call != null)
            {
                //拦截消息，做前处理
                //kaspec.PreExcute(call.MethodName, call.InArgs);
                if (KAOPHelper.IsHaveKAopMethod(call))
                {
                    paramDict = KAOPHelper.GetParamDictionary(call);
                    _kaopAttr.PreExcute(call.MethodName, paramDict);
                }
            }

            //传递消息给下一个接收器 
            IMessage retMsg = nextSink.SyncProcessMessage(call as IMessage);
            IMethodReturnMessage dispose = retMsg as IMethodReturnMessage;
            if (dispose != null)
            {
                //调用返回时进行拦截，并进行后处理
                if (KAOPHelper.IsHaveKAopMethod(call))
                {
                    _kaopAttr.EndExcute(dispose.MethodName, paramDict, dispose.OutArgs, dispose.ReturnValue, dispose.Exception);
                }
            }
            return retMsg;
        }
        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            return null;
        }
    }

}
