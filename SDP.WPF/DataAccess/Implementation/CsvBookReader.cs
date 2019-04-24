using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using SDP.WPF.DataAccess.Interface;
using SDP.WPF.Models;

namespace SDP.WPF.DataAccess.Implementation
{
    class CsvBookReader : ISourceReader
    {
        private List<Book> BookList;
        public List<Book> ReadBooks(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.HasHeaderRecord = false;
                var records = csv.GetRecords<Book>().ToList();
                BookList = records;
            }

            return BookList;
        }
    }
}
