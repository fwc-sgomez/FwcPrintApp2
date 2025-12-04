using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Text;

namespace FwcPrintApp
{
    public partial class Form1 : Form
    {
        Image printImg;

        public void WebpToSomethingLol()
        {

        }
        public void ImageFromBase64(string imageData)
        {
            string[] imgWHeader = imageData.Split(',');
            if (imgWHeader.Length < 2)
            {
                MessageBox.Show("failed to parse image data");
            }
            else
            {
                string imgBase64 = imgWHeader[1];
                byte[] bytes = Convert.FromBase64String(imgBase64);

                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    printImg = Image.FromStream(ms);
                }

                // TESTING vvv PROBABLY NOT GOOD
                // pp stands for PostProcess........
                Size ppSize = new Size(printImg.Width, printImg.Height);
                printImg = ScaleImageForPreview(printImg, ppSize);

                Size previewSize = new Size(pictureBoxImage.Width, pictureBoxImage.Height);
                pictureBoxImage.Image = ScaleImageForPreview(printImg, previewSize);
                killWs();
            }
        }

        private Image ScaleImageForPreview(Image imgToResize, Size resize)
        {
            // Get the image current width
            int sourceWidth = imgToResize.Width;
            // Get the image current height
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            // Calculate width and height with new desired size
            nPercentW = ((float)resize.Width / (float)sourceWidth);
            nPercentH = ((float)resize.Height / (float)sourceHeight);
            nPercent = Math.Min(nPercentW, nPercentH);
            // New Width and Height
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw image with new width and height
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return b;
        }
    }
}
