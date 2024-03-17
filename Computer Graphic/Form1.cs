using Computer_Graphic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_Graphic
{
    public partial class Form1 : Form
    {
        Bitmap image;
        private Button button1;

        public Form1()
        {
            InitializeComponent();

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Получаем новые размеры окна
            int newWidth = this.ClientSize.Width;
            int newHeight = this.ClientSize.Height;

            // Пересчитываем размеры и расположение элементов пропорционально новому размеру окна

            // PictureBox
            pictureBox1.Width = newWidth / 2;
            pictureBox1.Height = newHeight / 2;
            pictureBox1.Location = new Point((newWidth - pictureBox1.Width) / 2, (newHeight - pictureBox1.Height) / 2);

            // ProgressBar
            progressBar1.Width = newWidth / 2;
            progressBar1.Location = new Point((newWidth - progressBar1.Width) / 2, newHeight - progressBar1.Height - 20);

            // Button
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    Button button = (Button)control;
                    button.Width = newWidth / 8;
                    button.Location = new Point((newWidth - button.Width), newHeight - button.Height - 20);
                }
            }

            // Подобные операции выполняются для всех остальных элементов управления
        }


        // Остальной код класса Form1


        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files| *.png; *.jpg;* .bmp|All files(*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {

                image = new Bitmap(dialog.FileName);
            }

            pictureBox1.Image = image;
            pictureBox1.Refresh();
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //InvertFilter filter = new InvertFilter();
            //Bitmap resultImage = filter.processImage(image);
            //pictureBox1.Image = resultImage;
            //pictureBox1 .Refresh();

            Filters filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
            originalImage = pictureBox1.Image.Clone() as Bitmap;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
                image = newImage;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filters = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filters);
            originalImage = pictureBox1.Image.Clone() as Bitmap;
        }

        private void размытиеГауссаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = new Bitmap((Bitmap)pictureBox1.Image.Clone());
            Filters filter = new GaussianFilter();

            backgroundWorker1.RunWorkerAsync(filter);
            originalImage = pictureBox1.Image.Clone() as Bitmap;

        }

        private void grayScaleFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Создание экземпляра GrayScaleFilters
            GrayScaleFilters grayScaleFilter = new GrayScaleFilters();



            // Применение фильтра к изображению асинхронно
            backgroundWorker1.RunWorkerAsync(grayScaleFilter);
            originalImage = pictureBox1.Image.Clone() as Bitmap;
        }


        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Создание экземпляра SepiaFilter
            SepiaFilter sepiaFilter = new SepiaFilter();

            // Применение фильтра к изображению асинхронно
            backgroundWorker1.RunWorkerAsync(sepiaFilter);
            originalImage = pictureBox1.Image.Clone() as Bitmap;

        }

        private void увеличитьЯркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Создание экземпляра BrightnessFilter
            BrightnessFilter brightnessFilter = new BrightnessFilter();

            // Применение фильтра к изображению асинхронно
            backgroundWorker1.RunWorkerAsync(brightnessFilter);
            originalImage = pictureBox1.Image.Clone() as Bitmap;

        }

        private void sobelFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                // Создание экземпляра SobelFilter
                SobelFilter sobelFilter = new SobelFilter();


                // Применение фильтра к изображению асинхронно
                backgroundWorker1.RunWorkerAsync(sobelFilter);
            }
            else
            {
                MessageBox.Show("Загрузите изображение сначала.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            originalImage = pictureBox1.Image.Clone() as Bitmap;
        }

        private void sharpnessFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Создание экземпляра SharpnessFilter
            SharpnessFilter sharpnessFilter = new SharpnessFilter();

            // Применение фильтра к изображению асинхронно
            backgroundWorker1.RunWorkerAsync(sharpnessFilter);
            originalImage = pictureBox1.Image.Clone() as Bitmap;

        }

        private void тиснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Создание экземпляра EmbossFilter
            EmbossFilter embossFilter = new EmbossFilter();

            // Применение фильтра к изображению асинхронно
            backgroundWorker1.RunWorkerAsync(embossFilter);
            originalImage = pictureBox1.Image.Clone() as Bitmap;
        }

        private void переносВБокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Создание экземпляра TranslateFilter
            TranslateFilter translateFilter = new TranslateFilter();


            // Применение фильтра к изображению асинхронно
            backgroundWorker1.RunWorkerAsync(translateFilter);
            originalImage = pictureBox1.Image.Clone() as Bitmap;
        }

        private void поворотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Угол поворота в радианах (например, Math.PI / 4 для поворота на 45 градусов)
            double angle = Math.PI / 4;

            // Координаты центра поворота (пример: центр изображения)
            int centerX = image.Width / 2;
            int centerY = image.Height / 2;

            // Создание экземпляра RotateFilter
            RotateFilter rotateFilter = new RotateFilter(angle, centerX, centerY);

            // Применение фильтра к изображению асинхронно
            backgroundWorker1.RunWorkerAsync(rotateFilter);
            originalImage = pictureBox1.Image.Clone() as Bitmap;
        }

        private void волна1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Амплитуда волны
            int amplitude = 20;

            // Создание экземпляра WavesFilter1
            WavesFilter1 wavesFilter1 = new WavesFilter1(amplitude);



            // Применение фильтра к изображению асинхронно
            backgroundWorker1.RunWorkerAsync(wavesFilter1);
            originalImage = pictureBox1.Image.Clone() as Bitmap;
        }

        private void волна2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Амплитуда волны
            int amplitude = 20;

            // Создание экземпляра WavesFilter2
            WavesFilter2 wavesFilter2 = new WavesFilter2(amplitude);



            // Применение фильтра к изображению асинхронно
            backgroundWorker1.RunWorkerAsync(wavesFilter2);
            originalImage = pictureBox1.Image.Clone() as Bitmap;
        }

        private void стеклоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Создание экземпляра GlassEffectFilter
            GlassEffectFilter glassEffectFilter = new GlassEffectFilter();


            // Применение фильтра к изображению асинхронно
            backgroundWorker1.RunWorkerAsync(glassEffectFilter);
            originalImage = pictureBox1.Image.Clone() as Bitmap;
        }

        private void блюрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Создание экземпляра MotionBlurFilter с заданным радиусом размытия
            MotionBlurFilter motionBlurFilter = new MotionBlurFilter(10);


            // Применение фильтра к изображению асинхронно
            backgroundWorker1.RunWorkerAsync(motionBlurFilter);
            originalImage = pictureBox1.Image.Clone() as Bitmap;
        }

        // Создание экземпляра ImageSaver
        ImageSaver imageSaver = new ImageSaver();

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Проверка, что на форме есть изображение для сохранения
            if (pictureBox1.Image != null)
            {
                // Вызов метода SaveImage, передавая ему изображение в качестве аргумента
                imageSaver.SaveImage((Bitmap)pictureBox1.Image);
                MessageBox.Show("Image saved successfully!");
            }
            else
            {
                MessageBox.Show("No image to save!");
            }
        }
        private Bitmap originalImage;
        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                if (originalImage != null)
                {
                    // Восстанавливаем изображение из резервной копии
                    pictureBox1.Image = originalImage.Clone() as Bitmap;
                }
            }
        }
    }
}