using System;
using System.Windows.Forms;
using System.Windows.Media;

[assembly: DisableDpiAwareness]
namespace UXM
{
    static class Program
    {
        public static bool unattended { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Properties.Settings settings = Properties.Settings.Default;
            if (settings.UpgradeRequired)
            {
                settings.Upgrade();
                settings.UpgradeRequired = false;
                settings.Save();
            }

            unattended = args.Length == 1;
            if (unattended)
                settings.ExePath = args[0];

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());

            if (unattended)
                return;

            settings.Save();
        }
    }
}
