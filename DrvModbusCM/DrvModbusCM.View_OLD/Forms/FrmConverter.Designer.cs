namespace DrvModbusCMForm.Control
{
    partial class FrmConverter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtInputArray = new TextBox();
            button1 = new Button();
            txtOutputValue = new TextBox();
            txtOrderByte = new TextBox();
            txtInputValue = new TextBox();
            button2 = new Button();
            txtOutputArray = new TextBox();
            richTextBox1 = new RichTextBox();
            btnTest = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // txtInputArray
            // 
            txtInputArray.Location = new Point(12, 12);
            txtInputArray.Name = "txtInputArray";
            txtInputArray.Size = new Size(178, 23);
            txtInputArray.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(295, 13);
            button1.Name = "button1";
            button1.Size = new Size(102, 23);
            button1.TabIndex = 1;
            button1.Text = "Convert";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtOutputValue
            // 
            txtOutputValue.Location = new Point(403, 14);
            txtOutputValue.Name = "txtOutputValue";
            txtOutputValue.Size = new Size(178, 23);
            txtOutputValue.TabIndex = 2;
            // 
            // txtOrderByte
            // 
            txtOrderByte.Location = new Point(196, 27);
            txtOrderByte.Name = "txtOrderByte";
            txtOrderByte.Size = new Size(93, 23);
            txtOrderByte.TabIndex = 3;
            // 
            // txtInputValue
            // 
            txtInputValue.Location = new Point(12, 41);
            txtInputValue.Name = "txtInputValue";
            txtInputValue.Size = new Size(178, 23);
            txtInputValue.TabIndex = 4;
            // 
            // button2
            // 
            button2.Location = new Point(295, 42);
            button2.Name = "button2";
            button2.Size = new Size(102, 23);
            button2.TabIndex = 5;
            button2.Text = "Convert";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // txtOutputArray
            // 
            txtOutputArray.Location = new Point(403, 43);
            txtOutputArray.Name = "txtOutputArray";
            txtOutputArray.Size = new Size(178, 23);
            txtOutputArray.TabIndex = 6;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 96);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(569, 283);
            richTextBox1.TabIndex = 7;
            richTextBox1.Text = "";
            // 
            // btnTest
            // 
            btnTest.Location = new Point(587, 96);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(100, 23);
            btnTest.TabIndex = 8;
            btnTest.Text = "Test";
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Click += btnTest_Click;
            // 
            // button3
            // 
            button3.Location = new Point(587, 125);
            button3.Name = "button3";
            button3.Size = new Size(100, 23);
            button3.TabIndex = 9;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // FrmConverter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(btnTest);
            Controls.Add(richTextBox1);
            Controls.Add(txtOutputArray);
            Controls.Add(button2);
            Controls.Add(txtInputValue);
            Controls.Add(txtOrderByte);
            Controls.Add(txtOutputValue);
            Controls.Add(button1);
            Controls.Add(txtInputArray);
            Name = "FrmConverter";
            Text = "FrmConverter";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtInputArray;
        private Button button1;
        private TextBox txtOutputValue;
        private TextBox txtOrderByte;
        private TextBox txtInputValue;
        private Button button2;
        private TextBox txtOutputArray;
        private RichTextBox richTextBox1;
        private Button btnTest;
        private Button button3;
    }
}