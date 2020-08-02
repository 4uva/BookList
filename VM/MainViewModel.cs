using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;

namespace BookList.VM
{
    class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            openCommand = new RelayCommand(OnOpen);
            exitCommand = new RelayCommand(OnExit);
        }

        string path;
        public string Path
        {
            get => path;
            private set { Set(ref path, value); LoadNewList(); }
        }

        BookListViewModel listVM;
        public BookListViewModel ListVM
        {
            get => listVM;
            private set => Set(ref listVM, value);
        }

        void LoadNewList()
        {
            ListVM = new BookListViewModel(Path);
        }

        RelayCommand openCommand, exitCommand;

        public ICommand OpenCommand => openCommand;
        void OnOpen()
        {
            var dialog = new OpenFileDialog()
            {
                AddExtension = true,
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false,
                Title = "Specify a book list",
                Filter = "CSV documents (.csv)|*.csv",
                DefaultExt = ".csv"
            };

            bool? result = dialog.ShowDialog();

            if (result == true)
                Path = dialog.FileName;
        }

        public ICommand ExitCommand => exitCommand;

        void OnExit() => Application.Current.Shutdown();
    }
}
