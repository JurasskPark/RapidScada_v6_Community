using Scada.Comm.Drivers.DrvModbusCM;
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
            string value00 = "00.";
            string value01 = "00.01.";
            string value02 = "01.01.";
            string value03 = "00.01.02.";
            string value04 = "01.01.02.";
            string value05 = "00.01.02.03.";
            string value06 = "01.01.02.03.";
            string value07 = "00.01.02.03.04.";
            string value08 = "01.01.02.03.04.";
            string value09 = "00.01.02.03.04.05.";
            string value10 = "01.01.02.03.04.05.";
            string value11 = "00.01.02.03.04.05.06.";
            string value12 = "01.01.02.03.04.05.06.";
            string value13 = "00.01.02.03.04.05.06.07.";
            string value14 = "01.01.02.03.04.05.06.07.";
            string value15 = "FF.FE.FD.FC.FB.FA.F9.F8.F7.";


            byte[] bytes00 = HEX_STRING.HEXSTRING_TO_BYTEARRAY(value00);
            byte[] bytes01 = HEX_STRING.HEXSTRING_TO_BYTEARRAY(value01);
            byte[] bytes02 = HEX_STRING.HEXSTRING_TO_BYTEARRAY(value02);
            byte[] bytes03 = HEX_STRING.HEXSTRING_TO_BYTEARRAY(value03);
            byte[] bytes04 = HEX_STRING.HEXSTRING_TO_BYTEARRAY(value04);
            byte[] bytes05 = HEX_STRING.HEXSTRING_TO_BYTEARRAY(value05);
            byte[] bytes06 = HEX_STRING.HEXSTRING_TO_BYTEARRAY(value06);
            byte[] bytes07 = HEX_STRING.HEXSTRING_TO_BYTEARRAY(value07);
            byte[] bytes08 = HEX_STRING.HEXSTRING_TO_BYTEARRAY(value08);
            byte[] bytes09 = HEX_STRING.HEXSTRING_TO_BYTEARRAY(value09);
            byte[] bytes10 = HEX_STRING.HEXSTRING_TO_BYTEARRAY(value10);
            byte[] bytes11 = HEX_STRING.HEXSTRING_TO_BYTEARRAY(value11);
            byte[] bytes12 = HEX_STRING.HEXSTRING_TO_BYTEARRAY(value12);
            byte[] bytes13 = HEX_STRING.HEXSTRING_TO_BYTEARRAY(value13);
            byte[] bytes14 = HEX_STRING.HEXSTRING_TO_BYTEARRAY(value14);
            byte[] bytes15 = HEX_STRING.HEXSTRING_TO_BYTEARRAY(value15);


            ulong Ulong00 = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(bytes00);
            ulong Ulong01 = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(bytes01);
            ulong Ulong02 = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(bytes02);
            ulong Ulong03 = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(bytes03);
            ulong Ulong04 = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(bytes04);
            ulong Ulong05 = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(bytes05);
            ulong Ulong06 = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(bytes06);
            ulong Ulong07 = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(bytes07);
            ulong Ulong08 = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(bytes08);
            ulong Ulong09 = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(bytes09);
            ulong Ulong10 = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(bytes10);
            ulong Ulong11 = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(bytes11);
            ulong Ulong12 = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(bytes12);
            ulong Ulong13 = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(bytes13);
            ulong Ulong14 = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(bytes14);
            ulong Ulong15 = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(bytes15);
        


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            FrmStart form = new FrmStart();
            Application.Run(form);
        }
    }
}