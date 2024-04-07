using Computer_Graphic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Computer_Graphic;
using System.Drawing;

namespace Computer_Graphic
{
    internal class InvertFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int blockSize = 64; // Размер блока
            Color sourceColor = sourceImage.GetPixel(x, y);

            // Определяем номер блока, в котором находится текущий пиксель
            int blockX = x / blockSize;
            int blockY = y / blockSize;

            // Проверяем, четный ли номер блока (0, 0), (0, 1), (1, 0), (1, 1) и т.д.
            if ((blockX + blockY) % 2 == 0)
            {
                // Инвертируем цвет пикселя
                Color resultColor = Color.FromArgb(255 - sourceColor.R, 255 - sourceColor.G, 255 - sourceColor.B);
                return resultColor;
            }

            // Возвращаем исходный цвет пикселя
            return sourceColor;
        }
    }
}

//namespace Computer_Graphic
//{
//    internal class InvertFilter : Filters
//    {
//        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
//        {
//            Color sourceColor = sourceImage.GetPixel(x, y);
//            Color resultColor = Color.FromArgb(255 - sourceColor.R, 255 - sourceColor.G, 255 - sourceColor.B);

//            return resultColor;
//        }



//    }
//}