/*
 * CLR Version：4.0.30319.42000
 * NameSpace：KAOPSample
 * FileName：MyKAOPTest
 * CurrentYear：2019
 * CurrentTime：2019/7/27 8:32:22
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2019/7/27 8:32:22 新規作成 (by shaocx)
 */


using KAOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAOPSample
{
    /*
     * 使用KAOP说明：
     * 1、自己定义类特性，用于处理方法进入和退出的方法，特性继承KAopClassAttribute
     * 2、将自己定义类特性放到要处理的类上
     * 3、将这个类里面自己要处理的方法上增加特性：[KAopMethod]
     * 4、类要继承KAopContextBoundObject
     */
    [MyLog]
    public class MyKAOPTest : KAopContextBoundObject, IMyKAOPTest
    {
        public string KibaName { get; set; }

        [KAopMethod]
        public string Test(int para)
        {
            Console.WriteLine(para);
            return "数字为：" + para;
        }
    }


}
