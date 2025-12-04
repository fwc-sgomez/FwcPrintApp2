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
        CancellationTokenSource cts = new CancellationTokenSource();
        public Form1()
        {
            InitializeComponent();
            RegisterProtocol(false);
            labelVersion.Text = Assembly.GetEntryAssembly().GetName().Version.ToString();

            Thread threadPrinting = new Thread(InitPrintersAndPaperSizes);
            threadPrinting.Start();

            Thread threadWs = new Thread(StartWsServer);
            threadWs.Start();

        }



        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //msgOk(tabControl1.SelectedIndex.ToString());
            if (tabControl1.SelectedIndex == 0)
            {
                //Thread threadPrint = new Thread();
            }
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
            MessageBox.Show("Settings reset, app will now close.");
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            killWs();
        }

        private void buttonReregisterProtocol_Click(object sender, EventArgs e)
        {
            RegisterProtocol(true);
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            printDocument.PrintPage += (sender, e) => { 
                Point p = new(-10, 0);
                Rectangle r = e.PageBounds;
                r.Location = new Point(-15, -5);
                e.Graphics.DrawImage(printImg, r);
                //e.Graphics.DrawImage(printImg, p);
            };
            printDocument.PrinterSettings.Copies = (short)numericCopies.Value;
            printDocument.DefaultPageSettings.Landscape = true;
            printDocument.EndPrint += (sender, e) => {
                MessageBox.Show("Done printing!");
                this.Close();
            };
            //foreach (PrinterResolution res in printDocument.PrinterSettings.PrinterResolutions)
            //{
            //    string pr = $"x: {res.X}; y: {res.Y}";
            //    MessageBox.Show(pr);
            //}
            printDocument.Print();
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
