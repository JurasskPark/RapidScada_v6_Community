using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    public partial class FrmRegisterInputValue : Form
    {

        public ushort mode;
        public ulong value;

        public FrmRegisterInputValue()
        {
            InitializeComponent();
        }

        private void frm_RegisterInputValue_Load(object sender, EventArgs e)
        {
            if (mode == 0)
            {
                gpb_Boolean.Visible = true;
                rdb_False.Visible = true;
                rdb_True.Visible = true;
                gpb_Value.Visible = false;
                num_Value.Visible = false;

                if (value == 0)
                {
                    rdb_False.Checked = true;
                    rdb_True.Checked = false;
                }
                else if (value == 1)
                {
                    rdb_False.Checked = false;
                    rdb_True.Checked = true;
                }
            }
            else if (mode == 1)
            {
                gpb_Boolean.Visible = false;
                rdb_False.Visible = false;
                rdb_True.Visible = false;
                gpb_Value.Visible = true;
                num_Value.Visible = true;

                num_Value.Value = value;
                //Выделяем поле по умолчанию. У кнопок Ок и Отмена ставим TabStop = False
                num_Value.TabIndex = 0;
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            GetValue();
        }

      
        private void num_Value_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetValue();
            }
        }

        private void GetValue()
        {
            if (mode == 0)
            {
                if (rdb_False.Checked == true)
                {
                    value = 0;
                }
                else if (rdb_True.Checked == true)
                {
                    value = 1;
                }
            }
            else if (mode == 1)
            {
                value = Convert.ToUInt32(num_Value.Value);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }



        private void num_Value_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);            
            }
        }
    }
}
