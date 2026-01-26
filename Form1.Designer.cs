namespace FwcPrintApp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            buttonPrint = new Button();
            labelPrintTo = new Label();
            label2 = new Label();
            label1 = new Label();
            numericCopies = new NumericUpDown();
            groupBox1 = new GroupBox();
            pictureBoxImage = new PictureBox();
            tabPage2 = new TabPage();
            groupBox4 = new GroupBox();
            groupBoxDbg2 = new GroupBox();
            label5 = new Label();
            textBoxPrintRectOffset = new TextBox();
            checkBoxAllowEnterPrint = new CheckBox();
            groupBox3 = new GroupBox();
            comboBoxPrinters = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            comboBoxPaperSize = new ComboBox();
            groupBoxDbg = new GroupBox();
            checkBoxCloseAfterPrint = new CheckBox();
            checkBoxWsTimeout = new CheckBox();
            buttonReset = new Button();
            buttonReregisterProtocol = new Button();
            labelVersion = new Label();
            printDocument = new System.Drawing.Printing.PrintDocument();
            wsTimeout = new System.Windows.Forms.Timer(components);
            label6 = new Label();
            labelActivePS = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericCopies).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).BeginInit();
            tabPage2.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBoxDbg2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBoxDbg.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(2, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new Point(6, 6);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(581, 358);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(buttonPrint);
            tabPage1.Controls.Add(labelPrintTo);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(numericCopies);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 30);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(573, 324);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Print";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonPrint
            // 
            buttonPrint.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonPrint.Location = new Point(405, 254);
            buttonPrint.Name = "buttonPrint";
            buttonPrint.Size = new Size(70, 70);
            buttonPrint.TabIndex = 5;
            buttonPrint.Text = "Print";
            buttonPrint.UseVisualStyleBackColor = true;
            buttonPrint.Click += buttonPrint_Click;
            // 
            // labelPrintTo
            // 
            labelPrintTo.AutoSize = true;
            labelPrintTo.Location = new Point(141, 296);
            labelPrintTo.Name = "labelPrintTo";
            labelPrintTo.Size = new Size(95, 15);
            labelPrintTo.TabIndex = 4;
            labelPrintTo.Text = "SELECT PRINTER";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(71, 296);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 3;
            label2.Text = "Printing to:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(91, 267);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 2;
            label1.Text = "Copies:";
            // 
            // numericCopies
            // 
            numericCopies.Location = new Point(143, 265);
            numericCopies.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericCopies.Name = "numericCopies";
            numericCopies.Size = new Size(120, 23);
            numericCopies.TabIndex = 1;
            numericCopies.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBoxImage);
            groupBox1.Location = new Point(6, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(560, 247);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Preview";
            // 
            // pictureBoxImage
            // 
            pictureBoxImage.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxImage.Location = new Point(85, 23);
            pictureBoxImage.Name = "pictureBoxImage";
            pictureBoxImage.Size = new Size(384, 204);
            pictureBoxImage.TabIndex = 0;
            pictureBoxImage.TabStop = false;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox4);
            tabPage2.Controls.Add(groupBox3);
            tabPage2.Controls.Add(groupBoxDbg);
            tabPage2.Controls.Add(labelVersion);
            tabPage2.Location = new Point(4, 30);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(573, 324);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Settings";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(groupBoxDbg2);
            groupBox4.Controls.Add(checkBoxAllowEnterPrint);
            groupBox4.Location = new Point(6, 100);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(560, 156);
            groupBox4.TabIndex = 10;
            groupBox4.TabStop = false;
            groupBox4.Text = "App Settings";
            // 
            // groupBoxDbg2
            // 
            groupBoxDbg2.Controls.Add(labelActivePS);
            groupBoxDbg2.Controls.Add(label6);
            groupBoxDbg2.Controls.Add(label5);
            groupBoxDbg2.Controls.Add(textBoxPrintRectOffset);
            groupBoxDbg2.Location = new Point(355, 15);
            groupBoxDbg2.Name = "groupBoxDbg2";
            groupBoxDbg2.Size = new Size(200, 135);
            groupBoxDbg2.TabIndex = 9;
            groupBoxDbg2.TabStop = false;
            groupBoxDbg2.Text = "Debugging";
            groupBoxDbg2.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 25);
            label5.Name = "label5";
            label5.Size = new Size(90, 15);
            label5.TabIndex = 1;
            label5.Text = "PrintRectOffset:";
            // 
            // textBoxPrintRectOffset
            // 
            textBoxPrintRectOffset.Location = new Point(115, 22);
            textBoxPrintRectOffset.Name = "textBoxPrintRectOffset";
            textBoxPrintRectOffset.Size = new Size(79, 23);
            textBoxPrintRectOffset.TabIndex = 0;
            textBoxPrintRectOffset.Text = "-15;-5";
            // 
            // checkBoxAllowEnterPrint
            // 
            checkBoxAllowEnterPrint.AutoSize = true;
            checkBoxAllowEnterPrint.Checked = true;
            checkBoxAllowEnterPrint.CheckState = CheckState.Checked;
            checkBoxAllowEnterPrint.Location = new Point(6, 22);
            checkBoxAllowEnterPrint.Name = "checkBoxAllowEnterPrint";
            checkBoxAllowEnterPrint.Size = new Size(148, 19);
            checkBoxAllowEnterPrint.TabIndex = 8;
            checkBoxAllowEnterPrint.Text = "Use \"Enter\" key to print";
            checkBoxAllowEnterPrint.UseVisualStyleBackColor = true;
            checkBoxAllowEnterPrint.CheckedChanged += checkBoxAllowEnterPrint_CheckedChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(comboBoxPrinters);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(comboBoxPaperSize);
            groupBox3.Location = new Point(6, 6);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(560, 88);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Printing Settings";
            // 
            // comboBoxPrinters
            // 
            comboBoxPrinters.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPrinters.FormattingEnabled = true;
            comboBoxPrinters.Items.AddRange(new object[] { "Populating list, please wait..." });
            comboBoxPrinters.Location = new Point(71, 25);
            comboBoxPrinters.Name = "comboBoxPrinters";
            comboBoxPrinters.Size = new Size(273, 23);
            comboBoxPrinters.TabIndex = 1;
            comboBoxPrinters.SelectedIndexChanged += comboBoxPrinters_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 28);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 0;
            label3.Text = "Printer:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 57);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 2;
            label4.Text = "Paper size:";
            // 
            // comboBoxPaperSize
            // 
            comboBoxPaperSize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPaperSize.FormattingEnabled = true;
            comboBoxPaperSize.Items.AddRange(new object[] { "Populating list, please wait..." });
            comboBoxPaperSize.Location = new Point(71, 54);
            comboBoxPaperSize.Name = "comboBoxPaperSize";
            comboBoxPaperSize.Size = new Size(273, 23);
            comboBoxPaperSize.TabIndex = 3;
            comboBoxPaperSize.SelectedIndexChanged += comboBoxPaperSize_SelectedIndexChanged;
            // 
            // groupBoxDbg
            // 
            groupBoxDbg.Controls.Add(checkBoxCloseAfterPrint);
            groupBoxDbg.Controls.Add(checkBoxWsTimeout);
            groupBoxDbg.Controls.Add(buttonReset);
            groupBoxDbg.Controls.Add(buttonReregisterProtocol);
            groupBoxDbg.Location = new Point(6, 262);
            groupBoxDbg.Name = "groupBoxDbg";
            groupBoxDbg.Size = new Size(496, 55);
            groupBoxDbg.TabIndex = 7;
            groupBoxDbg.TabStop = false;
            groupBoxDbg.Text = "Debugging";
            groupBoxDbg.Visible = false;
            // 
            // checkBoxCloseAfterPrint
            // 
            checkBoxCloseAfterPrint.AutoSize = true;
            checkBoxCloseAfterPrint.Checked = true;
            checkBoxCloseAfterPrint.CheckState = CheckState.Checked;
            checkBoxCloseAfterPrint.Location = new Point(368, 24);
            checkBoxCloseAfterPrint.Name = "checkBoxCloseAfterPrint";
            checkBoxCloseAfterPrint.Size = new Size(106, 19);
            checkBoxCloseAfterPrint.TabIndex = 8;
            checkBoxCloseAfterPrint.Text = "CloseAfterPrint";
            checkBoxCloseAfterPrint.UseVisualStyleBackColor = true;
            checkBoxCloseAfterPrint.CheckedChanged += checkBoxCloseAfterPrint_CheckedChanged;
            // 
            // checkBoxWsTimeout
            // 
            checkBoxWsTimeout.AutoSize = true;
            checkBoxWsTimeout.Checked = true;
            checkBoxWsTimeout.CheckState = CheckState.Checked;
            checkBoxWsTimeout.Location = new Point(275, 25);
            checkBoxWsTimeout.Name = "checkBoxWsTimeout";
            checkBoxWsTimeout.Size = new Size(87, 19);
            checkBoxWsTimeout.TabIndex = 7;
            checkBoxWsTimeout.Text = "WsTimeout";
            checkBoxWsTimeout.UseVisualStyleBackColor = true;
            checkBoxWsTimeout.CheckedChanged += checkBoxWsTimeout_CheckedChanged;
            // 
            // buttonReset
            // 
            buttonReset.ForeColor = Color.Red;
            buttonReset.Location = new Point(6, 22);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(143, 23);
            buttonReset.TabIndex = 4;
            buttonReset.Text = "Reset settings and close";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // buttonReregisterProtocol
            // 
            buttonReregisterProtocol.Location = new Point(155, 21);
            buttonReregisterProtocol.Name = "buttonReregisterProtocol";
            buttonReregisterProtocol.Size = new Size(114, 23);
            buttonReregisterProtocol.TabIndex = 6;
            buttonReregisterProtocol.Text = "ReregisterProtocol";
            buttonReregisterProtocol.UseVisualStyleBackColor = true;
            buttonReregisterProtocol.Click += buttonReregisterProtocol_Click;
            // 
            // labelVersion
            // 
            labelVersion.AutoSize = true;
            labelVersion.Location = new Point(508, 303);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(45, 15);
            labelVersion.TabIndex = 5;
            labelVersion.Text = "version";
            labelVersion.Click += labelVersion_Click;
            // 
            // wsTimeout
            // 
            wsTimeout.Interval = 5000;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 117);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 2;
            label6.Text = "ActivePS:";
            // 
            // labelActivePS
            // 
            labelActivePS.AutoSize = true;
            labelActivePS.Location = new Point(68, 117);
            labelActivePS.Name = "labelActivePS";
            labelActivePS.Size = new Size(38, 15);
            labelActivePS.TabIndex = 3;
            labelActivePS.Text = "label7";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(tabControl1);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FWCPrintApp";
            FormClosing += Form1_FormClosing;
            KeyDown += Form1_KeyDown;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericCopies).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBoxDbg2.ResumeLayout(false);
            groupBoxDbg2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBoxDbg.ResumeLayout(false);
            groupBoxDbg.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label2;
        private Label label1;
        private NumericUpDown numericCopies;
        private GroupBox groupBox1;
        private PictureBox pictureBoxImage;
        private Label labelPrintTo;
        private ComboBox comboBoxPrinters;
        private Label label3;
        private Label labelVersion;
        private Button buttonReset;
        private ComboBox comboBoxPaperSize;
        private Label label4;
        private Button buttonPrint;
        private System.Drawing.Printing.PrintDocument printDocument;
        private Button buttonReregisterProtocol;
        private GroupBox groupBoxDbg;
        private GroupBox groupBox3;
        private CheckBox checkBoxAllowEnterPrint;
        private GroupBox groupBox4;
        private CheckBox checkBoxWsTimeout;
        private System.Windows.Forms.Timer wsTimeout;
        private GroupBox groupBoxDbg2;
        private Label label5;
        private TextBox textBoxPrintRectOffset;
        private CheckBox checkBoxCloseAfterPrint;
        private Label labelActivePS;
        private Label label6;
    }
}
