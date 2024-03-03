using System;
using System.Drawing;

namespace Computer_Graphic
{
    internal class SepiaFilter : Filters
    {
        // Коэффициент для настройки оттенка сепии
        private const float SepiaIntensity = 20.0f;

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            // Рассчитываем интенсивность, как для полутонового изображения
            int intensity = (int)(0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B);

            // Применяем эффект сепии по формуле
            int newRed = Clamp((int)(intensity + 2 * SepiaIntensity), 0, 255);
            int newGreen = Clamp((int)(intensity + 0.5 * SepiaIntensity), 0, 255);
            int newBlue = Clamp((int)(intensity - SepiaIntensity), 0, 255);

            // Возвращаем цвет сепии
            return Color.FromArgb(newRed, newGreen, newBlue);
        }
    }
}
