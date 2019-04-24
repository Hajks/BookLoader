using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDP.WPF.Models;

namespace SDP.WPF.DataAccess.Interface
{
    public interface ISourceReader
    {
        List<Book> ReadBooks(string filePath);
    }
}
