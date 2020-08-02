using System.Windows;

using BookList.View;
using BookList.VM;

namespace BookList
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainVM = new MainViewModel();
            var mainWindow = new MainWindow() { DataContext = mainVM };
            mainWindow.Show();
        }
    }
}
