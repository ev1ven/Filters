using System;
using System.Drawing;
using System.Windows.Forms;

namespace Computer_Graphic
{
    class ImageSaver
    {
        public void SaveImage(Bitmap image)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Images|*.png;*.bmp;*.jpg";
            saveFileDialog.Title = "Save an Image File";
            saveFileDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the file type selected in the dialog box.
                switch (saveFileDialog.FilterIndex)
                {
                    case 1:
                        image.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                        break;

                    case 2:
                        image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                }

                fs.Close();
            }
        }
    }
}
