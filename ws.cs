using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.WebSockets;

namespace FwcPrintApp
{
    public partial class Form1
    {
        /*
        * im entering my vibecoding era
        */

        public string StoredBase64 { get; private set; } = string.Empty;

        private async void StartWebSocketServer()
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://127.0.0.1:21845/");
            listener.Start();

            // Create a cancellation token that expires after 5 seconds
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));

            try
            {
                HttpListenerContext context = await listener.GetContextAsync().WaitAsync(checkBoxWsTimeout.Checked ? cts.Token : CancellationToken.None);
                if (context.Request.IsWebSocketRequest)
                {
                    HttpListenerWebSocketContext wsContext = await context.AcceptWebSocketAsync(null);
                    WebSocket webSocket = wsContext.WebSocket;

                    // Use a MemoryStream to accumulate chunks of the message
                    using var ms = new MemoryStream();
                    byte[] buffer = new byte[4096]; // Standard chunk size
                    WebSocketReceiveResult result;

                    do
                    {
                        // Receive a single fragment/chunk
                        result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                        // Write the chunk into the MemoryStream
                        ms.Write(buffer, 0, result.Count);

                        // Continue until the client signals the end of the message
                    } while (!result.EndOfMessage);
                    //MessageBox.Show("hello");
                    // Convert the full accumulated stream to a string
                    ms.Seek(0, SeekOrigin.Begin);
                    using (var reader = new StreamReader(ms, Encoding.UTF8))
                    {
                        StoredBase64 = await reader.ReadToEndAsync();
                    }

                    ImageFromBase64(StoredBase64);

                    // Close connection safely
                    await webSocket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "Received", CancellationToken.None);
                    webSocket.Dispose();
                }
            }
            catch (OperationCanceledException)
            {
                // This blocks triggers when the 5-second timer hits
                this.Invoke(() => MessageBox.Show("WebSocket server timed out due to inactivity."));
            }
            catch (Exception ex)
            {
                this.Invoke(() => MessageBox.Show($"Error: {ex.Message}"));
            }
            finally
            {
                listener.Stop();
                listener.Close();
            }
        }

        /*
        * im leaving my vibecoding era
        */
    }
}
