# KAOP
KAOP的改造

  * 使用KAOP说明：
     * 1、自己定义类特性，用于处理方法进入和退出的方法，特性继承KAopClassAttribute
     * 2、将自己定义类特性放到要处理的类上
     * 3、将这个类里面自己要处理的方法上增加特性：[KAopMethod]
     * 4、类要继承KAopContextBoundObject
