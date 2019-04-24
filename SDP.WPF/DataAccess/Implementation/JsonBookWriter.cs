using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Newtonsoft.Json;
using SDP.WPF.DataAccess.Interface;
using SDP.WPF.Models;

namespace SDP.WPF.DataAccess.Implementation
{
    class JsonBookWriter : ISourceWriter
    {
        public void WriteBooks(string filePath, List<Book> books)
        {
            string output = JsonConvert.SerializeObject(books);
            File.WriteAllText(filePath, output);
        }
    }
}
