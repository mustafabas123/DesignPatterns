using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPattern
{
    // Yapılan değişiklikleri geri al
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book
            {
                Isbn="1234",
                Title="Sefiller",
                Author="Victor Hugo"
            };
            book.ShowBook();
            CareTaker history = new CareTaker();
            history.memento = book.CreateUndo();
            book.Isbn = "4321";
            book.Author = "VICTOR HUGO";
            book.ShowBook();
            book.RestoreFromUndo(history.memento);
            book.ShowBook();
            Console.ReadLine();
        }
    }
    class Book
    {
        private string title;
        private string author;
        private string isbn;
        private DateTime _lastEdited;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                SetLastEdited();
            }
        }
        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                SetLastEdited();
            }
        }
        public string Isbn
        {
            get { return isbn; }
            set
            {
                isbn = value;
                SetLastEdited();
            }
        }
        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }
        public Memento CreateUndo()
        {
            return new Memento(isbn,title,author, _lastEdited);
        }
        public void RestoreFromUndo(Memento memento)
        {
            title=memento.Title;
            author=memento.Author;
            isbn=memento.Isbn;
            _lastEdited = memento.LastEdited;
        }
        public void ShowBook()
        {
            Console.WriteLine("{0},{1},{2} edited : {3}", isbn, title, author, _lastEdited);
        }

    }
    class Memento
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime LastEdited { get; set; }
        public Memento(string isbn,string title,string author, DateTime lastEdited)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            LastEdited = lastEdited;
        }
    }
    class CareTaker
    {
        public Memento memento { get; set; }
    }
}
