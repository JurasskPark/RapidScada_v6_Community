using Scada.Agent;
using Scada.Comm.Drivers.DrvModbusCM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrvModbusCMForm.Control
{
    public partial class FrmConverter : Form
    {
        public FrmConverter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string arrInputStr = txtInputArray.Text.Trim();
            string byteOrderStr = txtOrderByte.Text.Trim();

            byte[] arrInput = HEX_STRING.HEXSTRING_TO_BYTEARRAY(arrInputStr);
            float value = HEX_FLOAT.BYTEARRAY_TO_FLOAT(arrInput, byteOrderStr);
            //arrInput = HEX_ARRAY.ArrayByteOrder(arrInput, byteOrderStr);
            //float value = BitConverter.ToSingle(arrInput);
            txtOutputValue.Text = value.ToString();
        }

        public static float[] ConvertByteToFloat(byte[] array)
        {
            float[] floatArr = new float[array.Length / 4];
            for (int i = 0; i < floatArr.Length; i++)
            {
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(array, i * 4, 4);
                }
                floatArr[i] = BitConverter.ToSingle(array, i * 4);
            }
            return floatArr;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            float inputValue = Convert.ToSingle(txtInputValue.Text.Trim());
            string byteOrderStr = txtOrderByte.Text.Trim();

            byte[] arrInput = BitConverter.GetBytes(inputValue);
            arrInput = HEX_ARRAY.ArrayByteOrder(arrInput, byteOrderStr);


            txtOutputArray.Text = HEX_STRING.BYTEARRAY_TO_HEXSTRING(arrInput);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            ProjectDevice device = new ProjectDevice();

            for (ulong index = 0; index < (ulong)65535; ++index)
            {
                bool status = false;
                ulong value = 0;

                device.SetCoil(Convert.ToUInt64(index), status);
                device.SetDiscreteInput(Convert.ToUInt64(index), status);
                device.SetHoldingRegister(Convert.ToUInt64(index), value);
                device.SetInputRegister(Convert.ToUInt64(index), value);
            }

            for (ulong index = 0; index < (ulong)9999999; ++index)
            {
                ulong value = 0;
                //device.SetDataBuffer(Convert.ToUInt64(index), value);
            }

            byte[] NumArrayRegisters = HEX_STRING.HEXSTRING_TO_BYTEARRAY("01.02.03.04.05.06.07.08.09.0A.0B.0C.0D.0E.0F.");
            ulong deviceRegistersBytes = 1;

            for (ulong index = 0; (ulong)index < (ulong)NumArrayRegisters.Length / deviceRegistersBytes; ++index)
            {
                ulong address = (ulong)((ulong)0 + (ulong)index);
                byte[] arrValue = new byte[4];
                arrValue = HEX_OPERATION.BYTEARRAY_SEARCH(NumArrayRegisters, (int)index * (int)deviceRegistersBytes, (int)deviceRegistersBytes);
                ulong value = BitConverter.ToUInt32(arrValue);

                //ulong value = (ulong)HEX_ENDIAN.SwapUInt32(BitConverter.ToUInt16(NumArrayRegisters, (int)index * (int)deviceRegistersBytes));
                device.SetHoldingRegister(address, value);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] unsigned = new byte[1];
            unsigned[0] = 125;
            VTD masterVTD = new VTD();
            DateTime dt = DateTime.Now;

            byte[] ttt = masterVTD.CalculateSendData(254, 85, 290, 0, 0, (ushort[])null, true);

            //masterVTD.GenerateTimeParametr(dt, 84, out ushort t1, out ushort t2);

            //object value = Convert.ToSByte(v);

            //int g = 5;
            //byte[] test = ArrayConverter.ToSByte(4);

            //sbyte[] signed = Array.ConvertAll(unsigned, b => unchecked((sbyte)b));

            //sbyte t = Array.Conv

        }
    }
}
