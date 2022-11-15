using System;
using WinFormMVC.View;
using WinFormMVC.Controller;

namespace UseMVCApplication
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ImageInvertorView view = new ImageInvertorView();
            view.Visible = false;
            ImageInvertorController controller = new ImageInvertorController(view);
            controller.LoadView();
            view.ShowDialog();
        }
    }
}
