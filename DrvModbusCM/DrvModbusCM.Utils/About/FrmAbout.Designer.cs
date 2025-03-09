namespace About
{
    partial class FrmAbout
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
            pbAbout = new PictureBox();
            btnOK = new Button();
            lblTitle = new Label();
            lblDescription = new Label();
            gbLine = new GroupBox();
            lblVersion = new Label();
            lblBuildDate = new Label();
            lblCopyright = new Label();
            rchInfoMore = new RichTextBox();
            linkLabel1 = new LinkLabel();
            pcbIcon1 = new PictureBox();
            pcbIcon2 = new PictureBox();
            linkLabel2 = new LinkLabel();
            pcbIcon3 = new PictureBox();
            linkLabel3 = new LinkLabel();
            pcbIcon4 = new PictureBox();
            linkLabel4 = new LinkLabel();
            imgList = new ImageList(components);
            ((System.ComponentModel.ISupportInitialize)pbAbout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbIcon1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbIcon2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbIcon3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcbIcon4).BeginInit();
            SuspendLayout();
            // 
            // pbAbout
            // 
            pbAbout.Location = new Point(17, 20);
            pbAbout.Margin = new Padding(4, 5, 4, 5);
            pbAbout.Name = "pbAbout";
            pbAbout.Size = new Size(237, 200);
            pbAbout.TabIndex = 0;
            pbAbout.TabStop = false;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOK.Location = new Point(1070, 653);
            btnOK.Margin = new Padding(4, 5, 4, 5);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(109, 38);
            btnOK.TabIndex = 1;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.Location = new Point(263, 20);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(916, 25);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "%title%";
            lblTitle.Visible = false;
            // 
            // lblDescription
            // 
            lblDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDescription.Location = new Point(263, 60);
            lblDescription.Margin = new Padding(4, 0, 4, 0);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(916, 57);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "%description%";
            lblDescription.Visible = false;
            // 
            // gbLine
            // 
            gbLine.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbLine.Location = new Point(17, 230);
            gbLine.Margin = new Padding(4, 5, 4, 5);
            gbLine.Name = "gbLine";
            gbLine.Padding = new Padding(4, 5, 4, 5);
            gbLine.Size = new Size(1161, 3);
            gbLine.TabIndex = 4;
            gbLine.TabStop = false;
            // 
            // lblVersion
            // 
            lblVersion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblVersion.Location = new Point(17, 238);
            lblVersion.Margin = new Padding(4, 0, 4, 0);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(1161, 25);
            lblVersion.TabIndex = 5;
            lblVersion.Text = "Version %version%";
            lblVersion.Visible = false;
            // 
            // lblBuildDate
            // 
            lblBuildDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblBuildDate.Location = new Point(17, 270);
            lblBuildDate.Margin = new Padding(4, 0, 4, 0);
            lblBuildDate.Name = "lblBuildDate";
            lblBuildDate.Size = new Size(1161, 25);
            lblBuildDate.TabIndex = 6;
            lblBuildDate.Text = "Built on %builddate%";
            lblBuildDate.Visible = false;
            // 
            // lblCopyright
            // 
            lblCopyright.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCopyright.Location = new Point(17, 302);
            lblCopyright.Margin = new Padding(4, 0, 4, 0);
            lblCopyright.Name = "lblCopyright";
            lblCopyright.Size = new Size(1161, 25);
            lblCopyright.TabIndex = 7;
            lblCopyright.Text = "%company%";
            lblCopyright.Visible = false;
            // 
            // rchInfoMore
            // 
            rchInfoMore.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rchInfoMore.BackColor = SystemColors.ControlLight;
            rchInfoMore.Location = new Point(17, 332);
            rchInfoMore.Margin = new Padding(4, 5, 4, 5);
            rchInfoMore.Name = "rchInfoMore";
            rchInfoMore.ScrollBars = RichTextBoxScrollBars.Vertical;
            rchInfoMore.Size = new Size(1160, 309);
            rchInfoMore.TabIndex = 8;
            rchInfoMore.Text = "%info%";
            rchInfoMore.Visible = false;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(317, 130);
            linkLabel1.Margin = new Padding(4, 0, 4, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(69, 25);
            linkLabel1.TabIndex = 9;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "%link%";
            linkLabel1.TextAlign = ContentAlignment.MiddleLeft;
            linkLabel1.Visible = false;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // pcbIcon1
            // 
            pcbIcon1.Location = new Point(263, 115);
            pcbIcon1.Margin = new Padding(4, 5, 4, 5);
            pcbIcon1.Name = "pcbIcon1";
            pcbIcon1.Size = new Size(46, 53);
            pcbIcon1.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbIcon1.TabIndex = 10;
            pcbIcon1.TabStop = false;
            pcbIcon1.Visible = false;
            // 
            // pcbIcon2
            // 
            pcbIcon2.Location = new Point(711, 115);
            pcbIcon2.Margin = new Padding(4, 5, 4, 5);
            pcbIcon2.Name = "pcbIcon2";
            pcbIcon2.Size = new Size(46, 53);
            pcbIcon2.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbIcon2.TabIndex = 12;
            pcbIcon2.TabStop = false;
            pcbIcon2.Visible = false;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.LinkColor = Color.Black;
            linkLabel2.Location = new Point(766, 130);
            linkLabel2.Margin = new Padding(4, 0, 4, 0);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(69, 25);
            linkLabel2.TabIndex = 11;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "%link%";
            linkLabel2.TextAlign = ContentAlignment.MiddleLeft;
            linkLabel2.Visible = false;
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // pcbIcon3
            // 
            pcbIcon3.Location = new Point(263, 175);
            pcbIcon3.Margin = new Padding(4, 5, 4, 5);
            pcbIcon3.Name = "pcbIcon3";
            pcbIcon3.Size = new Size(46, 53);
            pcbIcon3.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbIcon3.TabIndex = 14;
            pcbIcon3.TabStop = false;
            pcbIcon3.Visible = false;
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.LinkColor = Color.Black;
            linkLabel3.Location = new Point(317, 190);
            linkLabel3.Margin = new Padding(4, 0, 4, 0);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(69, 25);
            linkLabel3.TabIndex = 13;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "%link%";
            linkLabel3.TextAlign = ContentAlignment.MiddleLeft;
            linkLabel3.Visible = false;
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // pcbIcon4
            // 
            pcbIcon4.Location = new Point(711, 175);
            pcbIcon4.Margin = new Padding(4, 5, 4, 5);
            pcbIcon4.Name = "pcbIcon4";
            pcbIcon4.Size = new Size(46, 53);
            pcbIcon4.SizeMode = PictureBoxSizeMode.StretchImage;
            pcbIcon4.TabIndex = 16;
            pcbIcon4.TabStop = false;
            pcbIcon4.Visible = false;
            // 
            // linkLabel4
            // 
            linkLabel4.AutoSize = true;
            linkLabel4.LinkColor = Color.Black;
            linkLabel4.Location = new Point(766, 190);
            linkLabel4.Margin = new Padding(4, 0, 4, 0);
            linkLabel4.Name = "linkLabel4";
            linkLabel4.Size = new Size(69, 25);
            linkLabel4.TabIndex = 15;
            linkLabel4.TabStop = true;
            linkLabel4.Text = "%link%";
            linkLabel4.TextAlign = ContentAlignment.MiddleLeft;
            linkLabel4.Visible = false;
            linkLabel4.LinkClicked += linkLabel4_LinkClicked;
            // 
            // imgList
            // 
            imgList.ColorDepth = ColorDepth.Depth8Bit;
            imgList.ImageStream = (ImageListStreamer)resources.GetObject("imgList.ImageStream");
            imgList.TransparentColor = Color.Transparent;
            imgList.Images.SetKeyName(0, "github.png");
            imgList.Images.SetKeyName(1, "mail.png");
            imgList.Images.SetKeyName(2, "home_page.png");
            imgList.Images.SetKeyName(3, "youtube.png");
            // 
            // FrmAbout
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1196, 712);
            Controls.Add(pcbIcon4);
            Controls.Add(linkLabel4);
            Controls.Add(pcbIcon3);
            Controls.Add(linkLabel3);
            Controls.Add(pcbIcon2);
            Controls.Add(linkLabel2);
            Controls.Add(pcbIcon1);
            Controls.Add(linkLabel1);
            Controls.Add(rchInfoMore);
            Controls.Add(lblCopyright);
            Controls.Add(lblBuildDate);
            Controls.Add(lblVersion);
            Controls.Add(gbLine);
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            Controls.Add(btnOK);
            Controls.Add(pbAbout);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAbout";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "About";
            ((System.ComponentModel.ISupportInitialize)pbAbout).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbIcon1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbIcon2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbIcon3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcbIcon4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbAbout;
        private Button btnOK;
        private Label lblTitle;
        private Label lblDescription;
        private GroupBox gbLine;
        private Label lblVersion;
        private Label lblBuildDate;
        private Label lblCopyright;
        private RichTextBox rchInfoMore;
        private LinkLabel linkLabel1;
        private PictureBox pcbIcon1;
        private PictureBox pcbIcon2;
        private LinkLabel linkLabel2;
        private PictureBox pcbIcon3;
        private LinkLabel linkLabel3;
        private PictureBox pcbIcon4;
        private LinkLabel linkLabel4;
        private ImageList imgList;
    }
}
