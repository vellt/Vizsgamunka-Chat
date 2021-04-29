using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SZBvizsgamunkaChat.ImageCompressor
{
    /// <summary>
    /// Képtömörítési osztály
    /// </summary>
    class Resizer
    {
        #region Fields
        int height;
        int width;
        string source;
        private BitmapSource image;
        private byte[] array; 
        #endregion
        public Resizer(int height, int width, string source)
        {
            this.height = height;
            this.width = width;
            this.source = source;
            compress();
        }

        #region Public metods
        /// <summary>
        /// Megadja a tömörített állományt byte tömb formályában
        /// </summary>
        public byte[] GetByteArray()
        {
            return this.array;
        }

        /// <summary>
        /// Megadja a tömörített állományt BitmapSource formályában
        /// </summary>
        public BitmapSource GetBitmapSource()
        {
            return this.image;
        }
        #endregion

        #region private methods
        /// <summary>
        /// legenerálja a kimenő adatokat, a bejövő paraméterek alapján
        /// </summary>
        private void compress()
        {
            using (var img = System.Drawing.Image.FromFile(this.source))
            {
                Bitmap bmp = new Bitmap(FixedSize(img, this.width, this.height, true)); //tömöritett bitmap

                //bitmapsource készitese
                this.image = Imaging.CreateBitmapSourceFromHBitmap(bmp.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

                //byte array készitese
                MemoryStream memoryStream = new MemoryStream();
                bmp.Save(memoryStream, ImageFormat.Jpeg);
                this.array = memoryStream.ToArray();
            }
        }

        private System.Drawing.Image FixedSize(System.Drawing.Image image, int Width, int Height, bool needToFill)
        {
            #region számítások
            int sourceWidth = image.Width;
            int sourceHeight = image.Height;
            int sourceX = 0;
            int sourceY = 0;
            double destX = 0;
            double destY = 0;

            double nScale = 0;
            double nScaleW = 0;
            double nScaleH = 0;

            nScaleW = ((double)Width / (double)sourceWidth);
            nScaleH = ((double)Height / (double)sourceHeight);
            if (!needToFill)
            {
                nScale = Math.Min(nScaleH, nScaleW);
            }
            else
            {
                nScale = Math.Max(nScaleH, nScaleW);
                destY = (Height - sourceHeight * nScale) / 2;
                destX = (Width - sourceWidth * nScale) / 2;
            }

            if (nScale > 1)
                nScale = 1;

            int destWidth = (int)Math.Round(sourceWidth * nScale);
            int destHeight = (int)Math.Round(sourceHeight * nScale);
            #endregion

            System.Drawing.Bitmap bmPhoto = null;
            try
            {
                bmPhoto = new System.Drawing.Bitmap(destWidth + (int)Math.Round(2 * destX), destHeight + (int)Math.Round(2 * destY));
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("destWidth:{0}, destX:{1}, destHeight:{2}, desxtY:{3}, Width:{4}, Height:{5}",
                    destWidth, destX, destHeight, destY, Width, Height), ex);
            }
            using (System.Drawing.Graphics grPhoto = System.Drawing.Graphics.FromImage(bmPhoto))
            {
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grPhoto.CompositingQuality = CompositingQuality.HighQuality;
                grPhoto.SmoothingMode = SmoothingMode.HighQuality;

                System.Drawing.Rectangle to = new System.Drawing.Rectangle((int)Math.Round(destX), (int)Math.Round(destY), destWidth, destHeight);
                System.Drawing.Rectangle from = new System.Drawing.Rectangle(sourceX, sourceY, sourceWidth, sourceHeight);
                grPhoto.DrawImage(image, to, from, System.Drawing.GraphicsUnit.Pixel);

                return bmPhoto;
            }
        } 
        #endregion
    }
}
