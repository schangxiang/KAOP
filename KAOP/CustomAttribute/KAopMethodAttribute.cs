/*
 * CLR Version：4.0.30319.42000
 * NameSpace：KAOP
 * FileName：KAopMethodAttribute
 * CurrentYear：2019
 * CurrentTime：2019/7/27 9:55:36
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2019/7/27 9:55:36 新規作成 (by shaocx)
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAOP
{
    /// <summary>
    /// KAOP方法特性
    /// </summary>
     [AttributeUsage(AttributeTargets.Method)]
    public class KAopMethodAttribute : Attribute
    {

    }
}
