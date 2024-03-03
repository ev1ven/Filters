using System.Drawing;

namespace Computer_Graphic
{
    internal class TranslateFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            // Вычисляем новые индексы для переноса
            int newX = x + 50;
            int newY = y;

            // Проверяем, что новые индексы находятся в пределах изображения
            if (newX >= 0 && newX < sourceImage.Width && newY >= 0 && newY < sourceImage.Height)
            {
                // Возвращаем цвет из исходного изображения для новых индексов
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
