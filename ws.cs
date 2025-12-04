using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*
 * modified version of code provided by mozilla.org
 * https://developer.mozilla.org/en-US/docs/Web/API/WebSockets_API/Writing_WebSocket_server
 */

/*
 * BUG: messages larger than 65000 are lost or something idk
 * 
 */

namespace FwcPrintApp
{
    public partial class Form1 : Form
    {
        private TcpListener server;
        private TcpClient client;
        private NetworkStream stream;
        private bool runWs = true;
        public void StartWsServer()
        {
            string ip = "127.0.0.1";
            int port = 21845;
            server = new TcpListener(IPAddress.Parse(ip), port);
            server.Start();
            try
            {
                client = server.AcceptTcpClient();

                stream = client.GetStream();
            } catch {
                /*
                 * the meaning of life isn't as clear as the contrast between black and white.
                 * we're set on earth for many reasons. some more important than others.
                 * for some, it's helping others. for others, it's it's helping themselves.
                 * as for me? it's killing threads victorian style but in 2025 where Thread.Abort() isn't allowed.
                 */
            }


            // enter to an infinite cycle to be able to handle every change in stream
            // I don't really like how much cpu this takes. need to either optimize or end thread once image is recieved...
            while (runWs)
            {
                handleWs();
            }
        }
        
        public void killWs()
        {
            runWs = false;
            server.Stop();
        }

        private void handleWs()
        {
            while (!stream.DataAvailable) ;
            while (client.Available < 3) ; // match against "get"

            byte[] bytes = new byte[client.Available];
            stream.Read(bytes, 0, bytes.Length);
            string s = Encoding.UTF8.GetString(bytes);

            if (Regex.IsMatch(s, "^GET", RegexOptions.IgnoreCase))
            {
                handleHandshake(s);
            }
            else
            {
                handleMessage(bytes);
            }
        }

        private void handleHandshake(string s)
        {
            // 1. Obtain the value of the "Sec-WebSocket-Key" request header without any leading or trailing whitespace
            // 2. Concatenate it with "258EAFA5-E914-47DA-95CA-C5AB0DC85B11" (a special GUID specified by RFC 6455)
            // 3. Compute SHA-1 and Base64 hash of the new value
            // 4. Write the hash back as the value of "Sec-WebSocket-Accept" response header in an HTTP response
            string swk = Regex.Match(s, "Sec-WebSocket-Key: (.*)").Groups[1].Value.Trim();
            string swkAndSalt = swk + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11";
            byte[] swkAndSaltSha1 = System.Security.Cryptography.SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(swkAndSalt));
            string swkAndSaltSha1Base64 = Convert.ToBase64String(swkAndSaltSha1);

            // HTTP/1.1 defines the sequence CR LF as the end-of-line marker
            byte[] response = Encoding.UTF8.GetBytes(
                "HTTP/1.1 101 Switching Protocols\r\n" +
                "Connection: Upgrade\r\n" +
                "Upgrade: websocket\r\n" +
                "Sec-WebSocket-Accept: " + swkAndSaltSha1Base64 + "\r\n\r\n");

            stream.Write(response, 0, response.Length);
        }

        private void handleMessage(byte[] bytes)
        {
            bool fin = (bytes[0] & 0b10000000) != 0,
                    mask = (bytes[1] & 0b10000000) != 0; // must be true, "All messages from the client to the server have this bit set"
            int opcode = bytes[0] & 0b00001111; // expecting 1 - text message
            ulong offset = 2,
                  msgLen = bytes[1] & (ulong)0b01111111;

            if (msgLen == 126)
            {
                // bytes are reversed because websocket will print them in Big-Endian, whereas
                // BitConverter will want them arranged in little-endian on windows
                msgLen = BitConverter.ToUInt16(new byte[] { bytes[3], bytes[2] }, 0);
                offset = 4;
            }
            else if (msgLen == 127)
            {
                // To test the below code, we need to manually buffer larger messages — since the NIC's autobuffering
                // may be too latency-friendly for this code to run (that is, we may have only some of the bytes in this
                // websocket frame available through client.Available).
                msgLen = BitConverter.ToUInt64(new byte[] { bytes[9], bytes[8], bytes[7], bytes[6], bytes[5], bytes[4], bytes[3], bytes[2] }, 0);
                offset = 10;
            }

            if (msgLen == 0)
            {
                MessageBox.Show("msgLen == 0");
            }
            else if (mask)
            {
                byte[] decoded = new byte[msgLen];
                byte[] masks = new byte[4] { bytes[offset], bytes[offset + 1], bytes[offset + 2], bytes[offset + 3] };
                offset += 4;

                for (ulong i = 0; i < msgLen; ++i)
                    decoded[i] = (byte)(bytes[offset + i] ^ masks[i % 4]);

                string text = Encoding.UTF8.GetString(decoded);
                ImageFromBase64(text);
            }
            else
            {
                MessageBox.Show("mask bit not set");
            }
        }
    }
}
