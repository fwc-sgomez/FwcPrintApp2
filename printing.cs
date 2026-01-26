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
    public partial class Form1
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

            if (PrinterSettings.InstalledPrinters.Count > 0 )
            {
                foreach (string printer in PrinterSettings.InstalledPrinters)
                {
                    comboBoxPrinters.Items.Add(printer);
                }
            } else
            {
                MessageBox.Show("No printers installed!", "FWCPrintApp", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Please select a printer in the Settings tab.", "FWCPrintApp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
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
            SaveSelectedPaper(activePaperSize.PaperName);
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
            PaperSize aps = PaperNameToPaperSize(name);
            activePaperSize = aps;
            printDocument.DefaultPageSettings.PaperSize = activePaperSize;
            labelActivePS.Text = activePaperSize.PaperName;
        }

        public PaperSize PaperNameToPaperSize(string paperName)
        {
            PaperSize psReturn = new PaperSize();
            foreach (PaperSize paperSize in paperSizes)
            {
                if (paperSize.PaperName == paperName)
                {
                    psReturn = paperSize;
                }
            }
            return psReturn;
        }
    }
}
