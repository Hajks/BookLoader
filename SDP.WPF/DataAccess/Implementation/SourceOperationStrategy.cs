using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDP.WPF.DataAccess.Interface;

namespace SDP.WPF.DataAccess.Implementation
{
    public class SourceOperationStrategy : ISourceOperationStrategy
    {
        private static readonly Dictionary<string, ISourceReader> _readers;
        private static readonly Dictionary<string, ISourceWriter> _writers;

        static SourceOperationStrategy()
        {
            _readers = new Dictionary<string, ISourceReader>();
            _writers = new Dictionary<string, ISourceWriter>();

            _readers.Add(".json", new JsonBookReader());
            _readers.Add(".xml", new XmlBookReader());
            _readers.Add(".csv", new CsvBookReader());

            _writers.Add(".json", new JsonBookWriter());
            _writers.Add(".xml", new XmlBookWriter());
            _writers.Add(".csv", new CsvBookWriter());

        }

        public ISourceReader GetReader(string fileName)
        {
            var extension = Path.GetExtension(fileName);

            if (_readers.TryGetValue(extension, out ISourceReader reader))
                return reader;

            return null;
        }

        public ISourceWriter GetWriter(string fileName)
        {
            {
                var extension = Path.GetExtension(fileName);

                if (_writers.TryGetValue(extension, out ISourceWriter writer))
                    return writer;

                return null;
            }
        }
    }
}
