using System;
using Autofac;
using System.Collections.Generic;
using System.Text;

namespace New_Chapter3
{
    public static class Resolver
    {
        private static IContainer container;
        public static void Initialize(IContainer container)
        {
            Resolver.container = container;
        }
        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }

    }
}
