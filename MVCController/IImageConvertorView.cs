using WinFormMVC.Model;

namespace WinFormMVC.Controller
{
    public interface IImageConvertorView
    {
        void SetController(ImageInvertorController controller);
        void SetLoadedImageInPictureBox(FileModel fileModel);
        FileModel FileModel { get; set; }

    }
}
