using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;
using ImageMagick;

namespace FwcPrintApp
{
    public partial class Form1 : Form
    {
        Image printImg;

        public void Base64ToWebp(string base64Data)
        {
            byte[] imgBytes = Convert.FromBase64String(base64Data);

            using(var mImg = new MagickImage(imgBytes))
            {
                mImg.Format = MagickFormat.WebP;
                mImg.Quality = 100;
                printImg = WebpToBitmap(mImg);
            }
        }

        private Bitmap WebpToBitmap(MagickImage webpImg)
        {
            Bitmap bm;
            using (var mImg = new MagickImage(webpImg))
            {
                using (MemoryStream ms = new MemoryStream()) 
                {
                    mImg.Format = MagickFormat.Bmp;
                    mImg.Write(ms);
                    bm = new Bitmap(ms);
                }
            }
            return bm;
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
                Base64ToWebp(imgBase64);
                //return;
                //byte[] bytes = Convert.FromBase64String(imgBase64);

                //using (MemoryStream ms = new MemoryStream(bytes))
                //{
                //    printImg = Image.FromStream(ms);
                //}

                // TESTING vvv PROBABLY NOT GOOD
                // pp stands for PostProcess........
                Size ppSize = new Size(printImg.Width, printImg.Height);
                Size previewSize = new Size(pictureBoxImage.Width, pictureBoxImage.Height);
                Size test = new Size(1130, 600);
                Image pi = ScaleImageForPreview(printImg, test);
                printImg = pi;

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
            //g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            //g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw image with new width and height
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return b;
        }
    }
}
