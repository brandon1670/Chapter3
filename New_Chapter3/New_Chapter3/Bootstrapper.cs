using Autofac;
using New_Chapter3.ViewModels;

using System;
using System.Collections.Generic;
using System.Text;

namespace New_Chapter3
{
    public static class Bootstrapper
    {
        public static void Initialize()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterAssemblyTypes(typeof(App).Assembly)
                                      .Where(x => x.IsSubclassOf(typeof(ViewModel)));
            var container = containerBuilder.Build();
            Resolver.Initialize(container);
        }
    }
}
