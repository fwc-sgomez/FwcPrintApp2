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
            buttonReregisterProtocol = new Button();
            labelVersion = new Label();
            buttonReset = new Button();
            comboBoxPaperSize = new ComboBox();
            label4 = new Label();
            comboBoxPrinters = new ComboBox();
            label3 = new Label();
            printDocument = new System.Drawing.Printing.PrintDocument();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericCopies).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).BeginInit();
            tabPage2.SuspendLayout();
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
            tabPage2.Controls.Add(buttonReregisterProtocol);
            tabPage2.Controls.Add(labelVersion);
            tabPage2.Controls.Add(buttonReset);
            tabPage2.Controls.Add(comboBoxPaperSize);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(comboBoxPrinters);
            tabPage2.Controls.Add(label3);
            tabPage2.Location = new Point(4, 30);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(573, 324);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Settings";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonReregisterProtocol
            // 
            buttonReregisterProtocol.Location = new Point(155, 294);
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
            // 
            // buttonReset
            // 
            buttonReset.ForeColor = Color.Red;
            buttonReset.Location = new Point(6, 295);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(143, 23);
            buttonReset.TabIndex = 4;
            buttonReset.Text = "Reset settings and close";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // comboBoxPaperSize
            // 
            comboBoxPaperSize.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPaperSize.FormattingEnabled = true;
            comboBoxPaperSize.Items.AddRange(new object[] { "Populating list, please wait..." });
            comboBoxPaperSize.Location = new Point(174, 71);
            comboBoxPaperSize.Name = "comboBoxPaperSize";
            comboBoxPaperSize.Size = new Size(273, 23);
            comboBoxPaperSize.TabIndex = 3;
            comboBoxPaperSize.SelectedIndexChanged += comboBoxPaperSize_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(106, 74);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 2;
            label4.Text = "Paper size:";
            // 
            // comboBoxPrinters
            // 
            comboBoxPrinters.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPrinters.FormattingEnabled = true;
            comboBoxPrinters.Items.AddRange(new object[] { "Populating list, please wait..." });
            comboBoxPrinters.Location = new Point(174, 42);
            comboBoxPrinters.Name = "comboBoxPrinters";
            comboBoxPrinters.Size = new Size(273, 23);
            comboBoxPrinters.TabIndex = 1;
            comboBoxPrinters.SelectedIndexChanged += comboBoxPrinters_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(123, 45);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 0;
            label3.Text = "Printer:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FWCPrintApp";
            FormClosing += Form1_FormClosing;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericCopies).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
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
    }
}
