using System;
using System.Drawing;

namespace Computer_Graphic
{
    internal class GlassEffectFilter : Filters
    {
        private Random random; // Генератор случайных чисел

        public GlassEffectFilter()
        {
            random = new Random();
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            // Генерируем случайное смещение для координат
            int xOffset = (int)((random.NextDouble() - 0.5) * 10);
            int yOffset = (int)((random.NextDouble() - 0.5) * 10);

            // Новые координаты с учетом смещения
            int newX = Clamp(x + xOffset, 0, sourceImage.Width - 1);
            int newY = Clamp(y + yOffset, 0, sourceImage.Height - 1);

            // Получаем цвет из исходного изображения для новых координат
            Color newColor = sourceImage.GetPixel(newX, newY);

            return newColor;
        }
    }
}
