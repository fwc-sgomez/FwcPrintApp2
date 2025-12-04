using System.Drawing.Printing;

/*
 * printing.cs
 * handle populating combo boxes for printers and paper sizes
 * handle selecting default/previous selections
 * ...
 * squint and everything will look thread safe
 */

namespace FwcPrintApp
{
    public partial class Form1 : Form
    {
        public bool printerListFinishedInit;
        public bool paperSizesListFinishedInit;

        public void InitPrintersAndPaperSizes()
        {
            PopulatePrintersList();
            PopulatePaperSizeList();
        }
        public void PopulatePrintersList()
        {
            comboBoxPrinters.Items.Clear();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                comboBoxPrinters.Items.Add(printer);
            }

            LoadDefaultPrinter();
        }
        public void LoadDefaultPrinter()
        {
            string printerName = Properties.Settings.Default.selectedPrinterName;
            if (printerName.Length < 1)
            {
                // use system default printer
                printerName = new PrinterSettings().PrinterName;
                MessageBox.Show("Please select a printer!");
            }

            int idx = 0;
            foreach (string printer in comboBoxPrinters.Items)
            {
                if (printer == printerName)
                {
                    comboBoxPrinters.Invoke(cb => cb.SelectedIndex = idx);
                    printDocument.PrinterSettings.PrinterName = printerName;
                }
                idx++;
            }

            printerListFinishedInit = true;
        }

        public void SaveSelectedPrinter(string name)
        {
            if (labelPrintTo.InvokeRequired)
            {
                labelPrintTo.Invoke(new MethodInvoker(delegate { labelPrintTo.Text = name; })); // cross-threading is being done
            } else
            {
                labelPrintTo.Text = name;
            }
            if (!printerListFinishedInit)
            {
                return;
            }
            else
            {
                printDocument.PrinterSettings.PrinterName = name;
                Properties.Settings.Default.selectedPrinterName = name;
                Properties.Settings.Default.Save();

            }
            PopulatePaperSizeList();
        }

        // ------
        PrinterSettings.PaperSizeCollection paperSizes;
        public void PopulatePaperSizeList()
        {
            comboBoxPaperSize.Invoke(cb => cb.Items.Clear());
            paperSizes = printDocument.PrinterSettings.PaperSizes;
            foreach (PaperSize paperSize in paperSizes)
            {
                comboBoxPaperSize.Invoke(cb => cb.Items.Add(paperSize.PaperName));
            }

            LoadDefaultPaper();
        }

        public PaperSize activePaperSize;
        public void LoadDefaultPaper()
        {
            string sizeString = Properties.Settings.Default.selectedPaperSize;
            bool usingSelected = true;
            if (sizeString.Length < 1)
            {
                sizeString = printDocument.PrinterSettings.DefaultPageSettings.PaperSize.PaperName;
                usingSelected = false;
            }

            int idx = 0;
            foreach (PaperSize paperSize in paperSizes)
            {
                if (sizeString == paperSize.PaperName)
                {
                    comboBoxPaperSize.Invoke(cb => cb.SelectedIndex = idx);
                    activePaperSize = paperSize;
                } else if (paperSize.PaperName.Contains("99014") && !usingSelected)
                {
                    comboBoxPaperSize.Invoke(cb => cb.SelectedIndex = idx);
                    activePaperSize = paperSize;
                }

                idx++;
            }
            paperSizesListFinishedInit = true;
        }

        public void SaveSelectedPaper(string name)
        {
            if (!paperSizesListFinishedInit)
            {
                return;
            } else
            {
                Properties.Settings.Default.selectedPaperSize = name;
                Properties.Settings.Default.Save();
            }
            printDocument.DefaultPageSettings.PaperSize = activePaperSize;
        }
    }
}
