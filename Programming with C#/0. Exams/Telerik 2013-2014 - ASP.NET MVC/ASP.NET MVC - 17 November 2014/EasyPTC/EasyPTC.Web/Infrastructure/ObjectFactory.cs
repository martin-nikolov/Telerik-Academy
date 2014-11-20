namespace EasyPTC.Web.Infrastructure
{
    using EasyPTC.Web.App_Start;
using Ninject;
using System;

    public class ObjectFactory
    {
        private static IKernel kernel = NinjectWebCommon.Kernel;

        public static T GetInstance<T>()
        {
            return kernel.Get<T>();
        }

        public static object GetInstance(Type type)
        {
            return kernel.Get(type);
        }
    }
}