using Lab1_SunnyTravel.Core;
using System;
using System.Windows.Forms;
using Autofac;

namespace Lab1_SunnyTravel.WFProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var container = ContainerCreator.CreateContainer(RegisterForms);
            using (var scope = container.BeginLifetimeScope())
            {
                var fakeLoader = scope.ResolveOptional<IFakeEventDataLoader>();
                fakeLoader?.Load(); // Load on if this is registered

                var form = scope.Resolve<Form1>();
                Application.Run(form);
            }
        }

        private static void RegisterForms(ContainerBuilder builder)
        {
            builder.RegisterType<Form1>()
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
