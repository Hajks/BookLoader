using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SDP.WPF.Commands;
using SDP.WPF.DataAccess.Implementation;
using SDP.WPF.DataAccess.Interface;
using SDP.WPF.Models;

namespace SDP.WPF.ViewModels
{
    class MainViewModel
    {
        public ObservableCollection<Book> Books { get; set; }
        private readonly IDialogService _dialogService;
        private readonly ISourceOperationStrategy _sourceOperations;

        public MainViewModel(IDialogService dialogService, ISourceOperationStrategy sourceOperations)
        {
            _dialogService = dialogService;
            _sourceOperations = sourceOperations;

            Books = new ObservableCollection<Book>();
            NewBook = new Book();
            AddBook = new RelayCommand(param => AddNewBook(), null);
            OpenFile = new RelayCommand(param => LoadDataFromFile(),null);
            SaveFile = new RelayCommand(param => SaveDataToFile(),null);
            Exit = new RelayCommand(param => System.Environment.Exit(0), null);

        }

        public Book NewBook { get; set; }

        public ICommand AddBook { get; private set; }

        public ICommand OpenFile { get; private set; }

        public ICommand SaveFile { get; private set; }

        public ICommand Exit { get; private set; }



        public void AddNewBook()
        {
            if (NewBook.IsValid)
            {
                Books.Add(new Book(NewBook));
            }

        }

        private void LoadDataFromFile()
        {
            var fileName = _dialogService.OpenFileDialog();
            if (fileName != null)
            {
                List<Book> bookList = _sourceOperations.GetReader(fileName).ReadBooks(fileName);
                Books.Clear();

                foreach (Book book in bookList)
                {
                    Books.Add(book);
                }
            }
        }

        private void SaveDataToFile()
        {
            var fileName = _dialogService.SaveFileDialog();
            if (fileName != null)
            {
                List<Book> bookListToSave = Books.ToList();
                _sourceOperations.GetWriter(fileName).WriteBooks(fileName, bookListToSave);
                Books.Clear();
            }
        }



    }
}
