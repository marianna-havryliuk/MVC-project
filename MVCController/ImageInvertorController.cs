using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using WinFormMVC.Model;

namespace WinFormMVC.Controller
{
    public class ImageInvertorController
    {
        IImageConvertorView _view;
        FileModel _loadedFile;

        public ImageInvertorController(IImageConvertorView view)
        {
            _view = view;
            view.SetController(this);
        }

        private void updateViewDetailValues(FileModel fileModel)
        {
            _view.FileModel = fileModel;
        }

        public void LoadView()
        {}

        public void LoadImage()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                _loadedFile = new FileModel(open.FileName, new Bitmap(open.FileName));
            }
            this.updateViewDetailValues(_loadedFile);
            _view.SetLoadedImageInPictureBox(_loadedFile);
        }

        public void TransformImage(Bitmap bitmap)
        {
            _loadedFile.Bitmap = Transform(bitmap);
            this.updateViewDetailValues(_loadedFile);
            _view.SetLoadedImageInPictureBox(_loadedFile);
        }

        private Bitmap Transform(Bitmap source)
        {
            Bitmap newBitmap = new Bitmap(source.Width, source.Height);
            Graphics g = Graphics.FromImage(newBitmap);
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]{new float[] {-1, 0, 0, 0, 0},
                                                                    new float[] {0, -1, 0, 0, 0},
                                                                    new float[] {0, 0, -1, 0, 0},
                                                                    new float[] {0, 0, 0, 1, 0},
                                                                    new float[] {1, 1, 1, 0, 1}
            }
            );
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);
            g.DrawImage(source, new Rectangle(0, 0, source.Width, source.Height),
                        0, 0, source.Width, source.Height, GraphicsUnit.Pixel, attributes);

            g.Dispose();
            return newBitmap;
        }
    }
}
