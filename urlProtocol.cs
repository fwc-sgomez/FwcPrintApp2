using Microsoft.Win32;
using System.Diagnostics;

/*
 * urlProtocol.cs
 * handle registering the fwcpa protocol required to launch this app from a browser.
 * currently only set per-user.
 */

namespace FwcPrintApp
{
    public partial class Form1 : Form
    {
        private readonly string protocolName = "fwcpa";
        private void RegisterProtocol(bool force)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Classes\\" + protocolName);
            string appPath = Process.GetCurrentProcess().MainModule.FileName;
            Console.WriteLine(key);
            if ((key == null) || force)
            {
                key = Registry.CurrentUser.CreateSubKey("Software\\Classes\\" + protocolName);
                key.SetValue(string.Empty, "URL: " + protocolName);
                key.SetValue("URL Protocol", string.Empty);

                key = key.CreateSubKey(@"shell\open\command");
                key.SetValue(string.Empty, appPath + " " + "%1");
            }
            key.Close();
        }
    }
}
