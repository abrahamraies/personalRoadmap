namespace Library_Management_System_C__Language
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Library.BookAdded += () => Console.WriteLine("Event: A new book has been added to the library!");

            Console.WriteLine("Welcome to the Library Management System!");
            int opt;
            do
            {
                Console.WriteLine("\nMenu:\n1. Add a book\n2. Search for a book by title\n3. Search for books by author\n4. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out opt))
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                    continue;
                }

                switch (opt)
                {
                    case 1:
                        AddBook();
                        break;

                    case 2:
                        SearchBookByTitle();
                        break;

                    case 3:
                        SearchBooksByAuthor();
                        break;

                    case 4:
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            } while (opt != 4);
        }

        private static void AddBook()
        {
            Console.Write("\nEnter the title of the book: ");
            string? title = Console.ReadLine();

            Console.Write("Enter the author of the book: ");
            string? author = Console.ReadLine();

            Console.Write("Enter the ISBN of the book: ");
            string? isbn = Console.ReadLine();

            Book book = new() { Title = title, Author = author, ISBN = isbn };
            Library.AddBook(book);

            Console.WriteLine("Book successfully added.");
        }

        private static void SearchBookByTitle()
        {
            Console.Write("Enter the title of the book: ");
            string? title = Console.ReadLine();

            Book? book = Library.SearchBookByTitle(title);
            if (book != null)
            {
                Console.WriteLine($"\nBook found: {book.Title} by {book.Author} (ISBN: {book.ISBN})");
            }
            else
            {
                Console.WriteLine("No book found with that title.");
            }
        }

        private static void SearchBooksByAuthor()
        {
            Console.Write("Enter the author's name: ");
            string author = Console.ReadLine();

            List<Book>? books = Library.SearchBooksByAuthor(author);
            if (books != null && books.Count != 0)
            {
                Console.WriteLine($"\nBooks by {author}:");
                foreach (Book book in books)
                {
                    Console.WriteLine($"- {book.Title} (ISBN: {book.ISBN})");
                }
            }
            else
            {
                Console.WriteLine("No books found by that author.");
            }
        }
    }
}