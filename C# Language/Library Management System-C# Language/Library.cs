namespace Library_Management_System_C__Language
{
    public static class Library
    {
        private static readonly List<Book> books = [];

        public static event Action? BookAdded;

        public static bool AddBook(Book newBook)
        {
            books.Add(newBook);
            BookAdded?.Invoke();
            return true;
        }

        public static Book? SearchBookByTitle(string title) => books.FirstOrDefault(x => !string.IsNullOrWhiteSpace(title) && x.Title.Contains(title, StringComparison.OrdinalIgnoreCase));

        public static List<Book>? SearchBooksByAuthor(string author) => books.Where(x => !string.IsNullOrWhiteSpace(author) && x.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}
