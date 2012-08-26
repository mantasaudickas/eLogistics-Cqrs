using System;

namespace SimpleCQRSCodeGenerator
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string initialDir = null;
            if (args != null && args.Length > 0)
                initialDir = args[0];

            if (initialDir == string.Empty)
                initialDir = null;

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            
            var mainForm = new MainForm {InitialDirectory = initialDir};
            System.Windows.Forms.Application.Run(mainForm);
        }
    }
}
