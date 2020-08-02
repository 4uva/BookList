using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using BookList.VM;

namespace BookList.View
{
    public partial class BookListPresentation : UserControl
    {
        public BookListPresentation()
        {
            InitializeComponent();
        }

        void ShowDescription(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var description = (string)button.Tag;
            FrameworkElement current = button;
            while (current != null && !(current is DataGridRow))
                current = (FrameworkElement)VisualTreeHelper.GetParent(current);
            if (current == null)
                return;
            // here current is DataGridRow
            var tooltip = new ToolTip()
            {
                Content = description,
                StaysOpen = false,
                IsOpen = true
            };
            current.ToolTip = tooltip;
            tooltip.Closed += (sender, args) => current.ToolTip = null;
        }

        void OnToggleFilter(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            var isOn = button.IsChecked == true;
            var booksCollectionView = CollectionViewSource.GetDefaultView(MainDG.ItemsSource);
            if (isOn)
                booksCollectionView.Filter = o => ((BookViewModel)o).IsInStock;
            else
                booksCollectionView.Filter = null;
        }
    }
}
