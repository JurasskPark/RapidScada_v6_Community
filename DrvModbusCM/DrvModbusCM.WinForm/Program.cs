using Scada.Comm.Drivers.DrvModbusCM.View;


namespace DrvModbusCMForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();


            string lanaugeDir = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Scada.Comm.Drivers.DrvModbusCM.DriverUtils.GetFileName(0));
            bool isRussian = false;
            //if (args != null && args.Length > 0)
            //{
            //    string culture = args[0];
            //    if (culture == "ru")
            //    {
            //        isRussian = true;
            //    }
            //}

            FrmConfig form = new FrmConfig(fileName);
            form.LoadLanguage(lanaugeDir, isRussian);
            Application.Run(form);
        }
    }
}