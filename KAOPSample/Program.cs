using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAOPSample
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 注意：
             * 如果实例化的对象是接口IMyKAOPTest的话，那么在IsHaveKAopMethod方法体中的type类型就是IMyKAOPTest，那么KAopMethodAttribute就得加在接口方法定义上才行
             * 如果实例化的对象是MyKAOPTest的话，那么KAopMethodAttribute就得加在实现方法定义上才行
             */
            //MyKAOPTest test = new MyKAOPTest();//KAopMethodAttribute就得加在实现方法定义上才行
            IMyKAOPTest test = new MyKAOPTest();//KAopMethodAttribute就得加在接口方法定义上才行
            try
            {
                //test.KibaName = "Kiba518";

                test.Test(518);
                test.Test(-100);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
