using System;
using System.Drawing;

namespace Computer_Graphic
{
    internal class RotateFilter : Filters
    {
        private double angle; // Угол поворота в радианах
        private int centerX; // Координата центра по оси X
        private int centerY; // Координата центра по оси Y

        public RotateFilter(double angle, int centerX, int centerY)
        {
            this.angle = angle;
            this.centerX = centerX;
            this.centerY = centerY;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            // Вычисляем новые координаты после поворота
            int newX = (int)((x - centerX) * Math.Cos(angle) - (y - centerY) * Math.Sin(angle) + centerX);
            int newY = (int)((x - centerX) * Math.Sin(angle) + (y - centerY) * Math.Cos(angle) + centerY);

            // Проверяем, что новые координаты находятся в пределах изображения
            if (newX >= 0 && newX < sourceImage.Width && newY >= 0 && newY < sourceImage.Height)
            {
                // Возвращаем цвет из исходного изображения для новых координат
                return sourceImage.GetPixel(newX, newY);
            }
            else
            {
                // Возвращаем черный цвет для пикселей, которые выходят за границы изображения
                return Color.Black;
            }
        }
    }
}
