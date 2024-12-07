using Minimal_ASP.NET_Application.Services.Interfaces;

namespace Minimal_ASP.NET_Application.Services
{
    public class BookService : IBookService
    {
        private readonly List<string> _books = [];

        public List<string> GetAllBooks() => _books;

        public void AddBook(string title) => _books.Add(title);

        public void RemoveBook(string title) => _books.Remove(title);
    }
}
