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
            string savedPaperString = Properties.Settings.Default.selectedPaperSize;
            int idx = 0;
            PaperSize ps99014 = new("undefined", 0, 0);
            int ps99014Idx = 0;
            PaperSize psIdx0 = new("undefined", 0, 0);
            PaperSize psRestore = new("undefined", 0, 0);
            int psRestoreIdx = 0;

            foreach (PaperSize ps in paperSizes) 
            {
                if (ps.PaperName.Contains("99014"))
                {
                    // find 99014
                    if (ps.PaperName.Contains("Shipping"))
                    {
                        // try to save "99014 shipping"
                        ps99014 = ps;
                        ps99014Idx = idx;
                    } if (ps.PaperName.Length < 1)
                    {
                        // save any other 99014 if shipping does not exist
                        ps99014 = ps;
                        ps99014Idx = idx;
                    }
                } else if (ps.PaperName == savedPaperString)
                {
                    // try to find papersize to restore from
                    psRestore = ps;
                    psRestoreIdx = idx;
                }

                // save papersize at index 0, just in case?
                if (idx == 0)
                {
                    psIdx0 = ps;
                }
                idx++;
            }

            // could be simplified by moving into for-loop, however, this made the most sense for me at this time
            // prioritizing saved papersize -> ps99014 -> papersize @ idx 0 as last resort
            if (psRestore.PaperName != "undefined")
            {
                activePaperSize = psRestore;
                comboBoxPaperSize.Invoke(cb => cb.SelectedIndex = psRestoreIdx);
            } else if (ps99014.PaperName != "undefined")
            {
                activePaperSize = ps99014;
                comboBoxPaperSize.Invoke(cb => cb.SelectedIndex = ps99014Idx);
            } else
            {
                activePaperSize = psIdx0;
                comboBoxPaperSize.Invoke(cb => cb.SelectedIndex = 0);
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
            labelActivePS.Invoke(() =>
            {
                labelActivePS.Text = activePaperSize.PaperName;

            });
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
