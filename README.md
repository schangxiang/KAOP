# KAOP
KAOP的改造

  * 使用KAOP说明：
     * 1、自己定义类特性，用于处理方法进入和退出的方法，特性继承KAopClassAttribute
     * 2、将自己定义类特性放到要处理的类上
     * 3、将这个类里面自己要处理的方法上增加特性：[KAopMethod]
     * 4、类要继承KAopContextBoundObject
     * 5、基于.NET FrameWork 4.5


            MyKAOPTest test = new MyKAOPTest();//KAopMethodAttribute就得加在实现方法定义上才行
            IMyKAOPTest test = new MyKAOPTest();//KAopMethodAttribute就得加在接口方法定义上才行
            /*
             * 注意：
             * 如果实例化的对象是接口IMyKAOPTest的话，那么在IsHaveKAopMethod方法体中的type类型就是IMyKAOPTest，那么KAopMethodAttribute就得加在接口方法定义上才行
             * 如果实例化的对象是MyKAOPTest的话，那么KAopMethodAttribute就得加在实现方法定义上才行
             */
