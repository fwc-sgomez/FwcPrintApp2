using System.Diagnostics;
using System.Drawing.Printing;
using System.Reflection;

/*
 * Form1.cs
 * initialization, event handling, etc.
 */

namespace FwcPrintApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadSettings();
            RegisterProtocol(false);
            labelVersion.Text = Assembly.GetEntryAssembly().GetName().Version.ToString();

            Thread threadPrinting = new Thread(InitPrintersAndPaperSizes);
            threadPrinting.Start();

            Thread threadWs = new Thread(StartWebSocketServer);
            threadWs.Start();

            if (checkBoxWsTimeout.Checked)
            {
                //wsTimeout.Start();

            }
        }
        private void LoadSettings()
        {
            checkBoxAllowEnterPrint.Checked = Properties.Settings.Default.allowEnterPrint;
            checkBoxWsTimeout.Checked = Properties.Settings.Default.wsTimeout;
            checkBoxCloseAfterPrint.Checked = Properties.Settings.Default.closeAfterPrint;
        }

        private void comboBoxPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveSelectedPrinter(comboBoxPrinters.SelectedItem.ToString());
        }

        private void comboBoxPaperSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveSelectedPaper(comboBoxPaperSize.SelectedItem.ToString());
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            MessageBox.Show("Settings reset, app will now close.", "FWCPrintApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // nothin
        }

        private void buttonReregisterProtocol_Click(object sender, EventArgs e)
        {
            RegisterProtocol(true);
            MessageBox.Show("Reregistered!", "FWCPrintApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            StartPrinting();
        }

        private void StartPrinting()
        {
            string[] pt = textBoxPrintRectOffset.Text.Split(";"); // the entire print op revolves around you... no pressure.
            try
            {
                int offsetX = int.Parse(pt[0]);
                int offsetY = int.Parse(pt[1]);
                printDocument.PrintPage += (sender, e) =>
                {
                    Rectangle r = e.PageBounds;
                    r.Location = new Point(-15, -5);
                    e.Graphics.DrawImage(printImg, r);
                    //e.Graphics.DrawImage(printImg, p);
                };
                printDocument.PrinterSettings.Copies = (short)numericCopies.Value;
                printDocument.DefaultPageSettings.Landscape = true;
                printDocument.EndPrint += (sender, e) =>
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        MessageBox.Show("Sent to printer!", "FWCPrintApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (checkBoxCloseAfterPrint.Checked) this.Close();
                    }));
                };

                printDocument.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("debug option PrintRectOffset is not formatted correctly. must be 2 integers, separated with a semicolon (\";\") in the middle. (default value: -15;-5)\nerror:" + ex);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if ((e.KeyCode == Keys.Enter) && (checkBoxAllowEnterPrint.Checked))
            {
                StartPrinting();
            }
        }

        private void checkBoxAllowEnterPrint_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.allowEnterPrint = checkBoxAllowEnterPrint.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBoxWsTimeout_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.wsTimeout = checkBoxWsTimeout.Checked;
            Properties.Settings.Default.Save();
        }

        private void labelVersion_Click(object sender, EventArgs e)
        {
            groupBoxDbg.Visible = true;
            groupBoxDbg2.Visible = true;
            
        }

        private void checkBoxCloseAfterPrint_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.closeAfterPrint = checkBoxCloseAfterPrint.Checked;
            Properties.Settings.Default.Save();
        }
    }

    // https://stackoverflow.com/a/36983936
    public static class Extensions
    {
        public static void Invoke<TControlType>(this TControlType control,  Action<TControlType> del)
            where TControlType : Control
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => del(control)));
            } else
            {
                del(control);
            }
        }
    }
}
