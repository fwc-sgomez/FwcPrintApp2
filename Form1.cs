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
                MessageBox.Show("Sent to printer!", "FWCPrintApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            };

            printDocument.Print();
        }

        private void WsTimoutKill(object sender, EventArgs e)
        {
            //killWs();
            wsTimeout.Stop();
            MessageBox.Show("No data recieved after 5 seconds. Please close this window and try again.", "FWCPrintApp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
