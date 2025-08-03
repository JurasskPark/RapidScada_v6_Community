using Scada.Comm.Drivers.DrvModbusCM;
using static Scada.Comm.Drivers.DrvModbusCM.ProjectTag;

namespace DrvModbusCM.Shared.Project.Tag
{
    public class ConverterFormatData
    {
        public ConverterFormatData() { }

        public static object ConvertStringtoObject(FormatData format, string value)
        {
            object result = new object();

            switch (format)
            {
                case FormatData.NONE:
                    result = string.Empty;
                    break;
                case FormatData.BIT:
                    result = Convert.ToBoolean(value);
                    break;
                case FormatData.BIT32:
                    result = Convert.ToInt32(value);
                    break;
                case FormatData.BIT64:
                    result = Convert.ToInt64(value);
                    break;
                case FormatData.BOOL:
                    result = ConvertStringToBoolean(value);
                    break;
                case FormatData.BYTE:
                    result = Convert.ToByte(value);
                    break;
                case FormatData.DATETIME4:
                case FormatData.DATETIME6:
                case FormatData.DATETIME8:
                    result = Convert.ToDateTime(value);
                    break;
                case FormatData.DOUBLE:
                    result = Convert.ToDouble(value);
                    break;
                case FormatData.FLOAT:
                    result = Convert.ToSingle(value);
                    break;
                case FormatData.HEX:
                    result = HEX_STRING.HEXSTRING_TO_BYTEARRAY(value);
                    break;
                case FormatData.INT:
                    result = Convert.ToInt32(value);
                    break;
                case FormatData.INT_HI:
                    result = Convert.ToInt32(value);
                    break;
                case FormatData.INT_LO:
                    result = Convert.ToInt32(value);
                    break;
                case FormatData.LONG:
                    result = Convert.ToInt64(value);
                    break;
                case FormatData.SBYTE:
                    result = Convert.ToSByte(value);
                    break;
                case FormatData.SHORT:
                    result = Convert.ToInt16(value);
                    break;
                case FormatData.UINT:
                    result = Convert.ToUInt32(value);
                    break;
                case FormatData.ULONG:
                    result = Convert.ToInt64(value);
                    break;
                case FormatData.USHORT:
                    result = Convert.ToUInt16(value);
                    break;
            }

            return result;
        }

        public static bool ConvertStringToBoolean(string input)
        {
            // Приводим строку к нижнему регистру и убираем пробелы
            string formattedInput = input.Trim().ToLower();

            // Определяем допустимые значения для true
            List<string> trueValues = new List<string> { "1", "true", "t", "yes", "y" };

            // Определяем допустимые значения для false
            List<string> falseValues = new List<string> { "0", "false", "f", "no", "n" };

            if (trueValues.Contains(formattedInput))
            {
                return true;
            }

            if (falseValues.Contains(formattedInput))
            {
                return false;
            }

            throw new FormatException("Invalid value for Boolean!");
        }
    }
}
