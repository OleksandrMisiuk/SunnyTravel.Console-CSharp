using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_SunnyTravel.Core
{
    class ContainerCreater
    {
        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MemoryDataRepository>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            return builder.Build();
        }
    }
}
