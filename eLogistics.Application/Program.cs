using System;
using eLogistics.Application.CQRS.Service;
using eLogistics.Application.Tests;

namespace eLogistics.Application
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ServiceMediator.Register();

/*
            AddressTests t = new AddressTests();
            t.TestAddressHandler();
*/

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new MainForm());
        }
    }
}
