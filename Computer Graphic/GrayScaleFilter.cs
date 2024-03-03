using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Diagnostics;
using System.ComponentModel;

namespace Computer_Graphic
{
    internal class GrayScaleFilters : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            double Intencity = 0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B;
            Color resultColor = Color.FromArgb((int)Intencity, (int)Intencity, (int)Intencity);
            return resultColor;
        }
    }
}
