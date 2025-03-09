using Scada.Comm.Drivers.DrvModbusCM;

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

            Scada.Comm.Drivers.DrvModbusCM.View.Forms.FrmConfigForm form = new Scada.Comm.Drivers.DrvModbusCM.View.Forms.FrmConfigForm();
            Application.Run(form);
        }
    }
}