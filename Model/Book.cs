using System.ComponentModel;
using CsvHelper.Configuration.Attributes;

namespace BookList.Model
{
    public class Book
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }

        public int Year { get; set; }

        public Binding Binding { get; set; }

        [BooleanTrueValues("yes")]
        [BooleanFalseValues("no")]
        [Name("In Stock")]
        public bool IsInStock { get; set; }

        public string Description { get; set; }
    }
}