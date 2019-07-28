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
            MyKAOPTest test = new MyKAOPTest();
            try
            {
                test.KibaName = "Kiba518";

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
