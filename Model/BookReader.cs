using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

using CsvHelper;

namespace BookList.Model
{
    class BookReader
    {
        readonly static CultureInfo localCulture = CultureInfo.GetCultureInfo("de-DE");
        public static List<Book> Read(Stream s)
        {
            using (var reader = new StreamReader(s))
            using (var csv = new CsvReader(reader, localCulture))
            {
                csv.Configuration.Delimiter = ";";
                var records = csv.GetRecords<Book>();
                return records.ToList();
            }
        }
    }
}
