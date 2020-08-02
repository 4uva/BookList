using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookList.Model;

namespace BookList.VM
{
    class BookListViewModel : ViewModelBase
    {
        public BookListViewModel(string path)
        {
            _ = LoadDataAsync(path);
        }

        async Task LoadDataAsync(string path)
        {
            Status = "Loading";
            try
            {
                var modelBooks = await Task.Run(() => LoadBooksInBackground(path));
                if (Books != null)
                {
                    // unsubscribe from old books price change
                    foreach (var book in Books)
                        book.PropertyChanged -= OnBookPropertyChanged;
                }
                Books = modelBooks.Select(b => new BookViewModel(b)).ToList().AsReadOnly();
                // subscribe to new books price change
                foreach (var book in Books)
                    book.PropertyChanged += OnBookPropertyChanged;
                UpdateMinMaxPrice();
                Status = $"Loaded {Books.Count} books";
            }
            catch (Exception ex)
            {
                Status = "Loading failed: " + ex.Message;
            }
        }

        void OnBookPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(BookViewModel.Price))
                UpdateMinMaxPrice();
        }

        void UpdateMinMaxPrice()
        {
            decimal minPrice = 0, maxPrice = 0;
            if (Books.Count > 0)
            {
                minPrice = Books.Min(b => b.Price);
                maxPrice = Books.Max(b => b.Price);
            }
            MinPrice = minPrice;
            MaxPrice = maxPrice;
        }

        // will be called in background thread
        List<Book> LoadBooksInBackground(string path)
        {
            using (var stream = File.OpenRead(path))
            {
                var books = BookReader.Read(stream);
                return books;
            }
        }

        string status;
        public string Status
        {
            get => status;
            private set => Set(ref status, value);
        }

        IReadOnlyList<BookViewModel> books;
        public IReadOnlyList<BookViewModel> Books
        {
            get => books;
            private set => Set(ref books, value);
        }

        decimal minPrice;
        public decimal MinPrice
        {
            get => minPrice;
            set => Set(ref minPrice, value);
        }

        decimal maxPrice;
        public decimal MaxPrice
        {
            get => maxPrice;
            set => Set(ref maxPrice, value);
        }
    }
}

