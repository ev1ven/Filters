using System;
using System.Drawing;

namespace Computer_Graphic
{
    internal class WavesFilter2 : Filters
    {
        private int amplitude; // Амплитуда волны

        // Конструктор, принимающий амплитуду в качестве параметра
        public WavesFilter2(int amplitude)
        {
            this.amplitude = amplitude;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            // Вычисляем новые координаты с использованием второй волновой функции
            int newX = (int)(x + amplitude * Math.Sin(2 * Math.PI * x / 30));
            int newY = y;

            // Проверяем, что новые координаты находятся в пределах изображения
            if (newX >= 0 && newX < sourceImage.Width && newY >= 0 && newY < sourceImage.Height)
            {
                // Берем цвет из исходного изображения для новых координат
                Color newColor = sourceImage.GetPixel(newX, newY);
                return newColor;
            }
            else
            {
                // Возвращаем черный цвет для пикселей, которые выходят за границы изображения
                return Color.Black;
            }
        }
    }
}
