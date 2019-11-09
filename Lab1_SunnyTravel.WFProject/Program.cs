using Autofac;
using Lab1_SunnyTravel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            var container = ContainerCreater.CreateContainer();
            using (var scope = container.BeginLifetimeScope())
            {
                Application.Run(new Form1(scope));
            }
        }
    }
}
