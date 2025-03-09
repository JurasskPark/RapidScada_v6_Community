using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    public class CSV
    {
        public static DataTable Import(string FileName, bool ColumnNamesVisible, string Separator, string FormatEncoding)
        {
            DataTable tmp_DataTable = new DataTable();

            #region Кодировка
            Encoding CSVEncoding;
            if (FormatEncoding == "Unicode") // выбрана кодировка Unicode
            {
                CSVEncoding = Encoding.Unicode;
            }
            else if (FormatEncoding == "ASCII") // выбрана кодировка ASCII 
            {
                CSVEncoding = Encoding.ASCII;
            }
            else if (FormatEncoding == "UTF7") // выбрана кодировка UTF7
            {
                #pragma warning disable SYSLIB0001 // Тип или член устарел
                CSVEncoding = Encoding.UTF7;
                #pragma warning restore SYSLIB0001 // Тип или член устарел
            }
            else if (FormatEncoding == "UTF8") // выбрана кодировка UTF8
            {
                CSVEncoding = Encoding.UTF8;
            }
            else
            {
                CSVEncoding = Encoding.Unicode; // по умолчанию устанавливаем Unicode
            }
            #endregion Кодировка

            string s;
            StreamReader CSVToDataTable = new StreamReader(FileName, CSVEncoding); // cчитываем CSV файл как поток используя StreamReader и кодировку
            {
                char[] char_Separator = Separator.ToCharArray();

                string[] headers = CSVToDataTable.ReadLine().Split(char_Separator);
                foreach (string header in headers)
                {
                    tmp_DataTable.Columns.Add(header);
                }

                while ((s = CSVToDataTable.ReadLine()) != null)
                {
                    string[] strArray = s.Split(char_Separator);
                    tmp_DataTable.Rows.Add(strArray);
                }
            }
            return tmp_DataTable;
        }

        public static void Export(string FileName, DataTable Table, bool ColumnNamesVisible, string Separator, string FormatEncoding)
        {
            #region Кодировка
            Encoding CSVEncoding;
            if (FormatEncoding == "Unicode") // выбрана кодировка Unicode
            {
                CSVEncoding = Encoding.Unicode;
            }
            else if (FormatEncoding == "ASCII") // выбрана кодировка ASCII 
            {
                CSVEncoding = Encoding.ASCII;
            }
            else if (FormatEncoding == "UTF7") // выбрана кодировка UTF7
            {
                #pragma warning disable SYSLIB0001 // Тип или член устарел
                CSVEncoding = Encoding.UTF7;
                #pragma warning restore SYSLIB0001 // Тип или член устарел
            }
            else if (FormatEncoding == "UTF8") // выбрана кодировка UTF8
            {
                CSVEncoding = Encoding.UTF8;
            }
            else
            {
                CSVEncoding = Encoding.Unicode; // по умолчанию устанавливаем Unicode
            }
            #endregion Кодировка

            #region Разделитель



            #endregion Разделитель


            StreamWriter DataTableToCSV = new StreamWriter(FileName, false, CSVEncoding); // создаем CSV файл как поток используя StreamWriter и кодировку

            string string_Row = String.Empty; // объявляем строку для данных

            if (ColumnNamesVisible)
            {
                DataTableToCSV.WriteLine(GetColumnNames(Table, Separator)); // пишем заголовки колонок если отмечен CheckBox Chk_ColumnNames
            }

            for (int r = 0; r < Table.Rows.Count; r++)
            {
                string strRow = string.Empty;
                DataRow dataRow = Table.Rows[r];

                for (int f = 0; f < dataRow.ItemArray.Length; f++) // пока есть данные (поля)
                {
                    strRow += dataRow.ItemArray[f] + Separator;
                }

                DataTableToCSV.WriteLine(strRow); // записываем строку 
            }

            DataTableToCSV.Close(); // закрываем StreamWriter
        }

        private static string GetColumnNames(DataTable Table, string Separator)
        {
            string strRow = String.Empty; // конец строки
                                          // при помощи цикла вносим конец строки
            for (int i = 0; i < Table.Columns.Count; i++)
            {
                strRow += Table.Columns[i].ToString() + Separator;
            }
            return strRow;
        }
    }
}
