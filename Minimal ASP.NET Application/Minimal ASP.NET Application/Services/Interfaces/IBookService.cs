namespace Minimal_ASP.NET_Application.Services.Interfaces
{
    public interface IBookService
    {
        List<string> GetAllBooks();
        void AddBook(string title);
        void RemoveBook(string title);
    }
}
