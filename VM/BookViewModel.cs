using System;
using System.Collections.Generic;
using System.Text;
using BookList.Model;

namespace BookList.VM
{
    class BookViewModel : ViewModelBase
    {
        public BookViewModel(Book book)
        {
            title       = book.Title;
            author      = book.Author;
            price       = book.Price;
            year        = book.Year;
            binding     = book.Binding;
            isInStock   = book.IsInStock;
            description = book.Description;
        }

        string title;
        public string Title
        {
            get => title;
            set => Set(ref title, value);
        }

        string author;
        public string Author
        {
            get => author;
            set => Set(ref author, value);
        }

        decimal price;
        public decimal Price
        {
            get => price;
            set => Set(ref price, value);
        }

        int year;
        public int Year
        {
            get => year;
            set => Set(ref year, value);
        }

        Binding binding;
        public Binding Binding
        {
            get => binding;
            set => Set(ref binding, value);
        }

        bool isInStock;
        public bool IsInStock
        {
            get => isInStock;
            set => Set(ref isInStock, value);
        }

        string description;

        public string Description
        {
            get => description;
            set => Set(ref description, value);
        }
    }
}
