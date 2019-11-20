using Autofac;
using System;
using Lab1_SunnyTravel.Core.Repositories;
using Lab1_SunnyTravel.Core.Services;

namespace Lab1_SunnyTravel.Core
{
    public class ContainerCreator
    {
        public static IContainer CreateContainer(Action<ContainerBuilder> registerAction = null)
        {
            var builder = new ContainerBuilder();

            RegisterRepositories(builder);
            RegisterServices(builder);
            
            registerAction?.Invoke(builder); // to register extra classes before build
            
            return builder.Build();
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<MemoryDataRepository>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<EventService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
