using System;
using System.Windows.Forms;
using WinFormMVC.Controller;
using WinFormMVC.Model;

namespace WinFormMVC.View
{
    public partial class ImageInvertorView : Form, IImageConvertorView
    {
        public ImageInvertorView()
        {
            InitializeComponent();
        }
        ImageInvertorController _controller;
        public FileModel FileModel { get; set; }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this._controller.LoadImage();
        }

        public void SetController(ImageInvertorController controller)
        {
            _controller = controller;
        }
        public void SetLoadedImageInPictureBox(FileModel fileModel)
        {
            if (fileModel != null)
            {
                this.pictureBox1.Image = fileModel.Bitmap;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (this.FileModel != null)
            {
                this._controller.TransformImage(this.FileModel.Bitmap);
            }
        }
    }
}
