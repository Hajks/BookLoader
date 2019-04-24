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
    class CsvBookWriter : ISourceWriter
    {
        public void WriteBooks(string filePath, List<Book> books)
        {  
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer))
            {
                    csv.WriteRecords(books); //No idea why this method occurs an error with RelayCommand. 
            }
        }
    }
}
