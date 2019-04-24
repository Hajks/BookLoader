using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SDP.WPF.DataAccess.Interface;
using SDP.WPF.Models;

namespace SDP.WPF.DataAccess.Implementation
{
    class XmlBookWriter : ISourceWriter
    {
        static XmlSerializer serializer = new XmlSerializer(typeof(List<Book>), new XmlRootAttribute("BookList"));

        public void WriteBooks(string filePath, List<Book> books)
        {
            TextWriter writer = new StreamWriter(filePath);
            serializer.Serialize(writer, books);
        }
    }
}
