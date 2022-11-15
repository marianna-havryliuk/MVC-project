using System.Drawing;

namespace WinFormMVC.Model
{
    public class FileModel
    {
        public FileModel (string fileName, Bitmap bitmap)
        {
            FileName = fileName;
            Bitmap = bitmap;
        }

        public string FileName { get; set; }
        public Bitmap Bitmap { get; set; }
    }
}
