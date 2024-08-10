using System;
using System.Net;
using static System.Console;

// Part A
class Book
{
    // Task 1 - Arrays
    public static string[] categoryCodes = { "CS", "IS", "SE", "SO", "MI" }; 
    public static string[] categoryNames = { "Computer Science", "Information System", "Security", "Society", "Miscellaneous" };

    // Task 2 - Data fields
    private string bookId;
    private string categoryNameOfBook;

    // Task 3 - Auto-implemented properties
    public string BookTitle { get; set; }
    public int NumOfPages { get; set; }
    public double Price { get; set; }

    // Task 4 - Properties
    public string BookId
    {
        get
        {
            return bookId;
        }
        set
        {
            string code = value.Substring(0, 2);
            if (code!="CS" && code != "IS" && code != "SE" && code != "SO")
            {
                bookId = "MI" + value.Substring(2, 3);
            }
        }
    }
    public string CategoryNameOfBook
    {
        get
        {
            return categoryNameOfBook;
        }
    }

    // Task 5 - Constructors
    public Book ()
    {
    }
    public Book (string bookId, string bookTitle, int numPages, double price)
    {
        this.bookId = bookId;
        this.BookTitle = bookTitle;
        this.NumOfPages = numPages;
        this.Price = price;
        this.BookId = bookId;
    }

    // Task 6 - ToString method
    public override string ToString()
    {
        return bookId + " " + BookTitle + " " + NumOfPages + " " + Price.ToString("C");
    }
}

// Part B
class Program
{
    // Task 1 - InputValue method
    public static int InputValue(int min, int max)
    {
        int input;
        Write("Enter a number which is in the range of {0} and {1} >> ", min, max);
        while ( !int.TryParse(ReadLine(), out input) && (input < min || input > max))
        {
            WriteLine("The number is not in the range or a non-numeric value was entered.");
            Write("Please enter a number again >> ");
        }
        return input;
    }

    // Task 2 - IsValue method
    public static bool IsValid(string id)
    {
        const int LENGTH = 5;
        if (id.Length == LENGTH)
        {
            if (Char.IsUpper(id, 0) && Char.IsUpper(id, 1) && Char.IsDigit(id, 2) && Char.IsDigit(id, 3) && Char.IsDigit(id, 4))
                return true;
            else return false;
        }
        else return false;
    }

    // Task 3 - GetBookData method
    private static void GetBookData(int num, Book[] books)
    {
        string bookTitle, bookId;
        double price;
        int numPages;
        for (int x = 0; x < num; ++x)
        {
            Write("Enter Book name >> ");
            bookTitle = ReadLine();
            WriteLine("Category codes are");
            for (int y = 0; y < Book.categoryCodes.Length; ++y)
            {
                WriteLine(Book.categoryCodes[y] + " " + Book.categoryNames[y]);
            }
            Write("Enter book id which starts with a category code and ends with a 3-digit number >> ");
            bookId = ReadLine();
            while (IsValid(bookId) == false)
            {
                Write("Enter book id which starts with a category code and ends with a 3-digit number >> ");
                bookId = ReadLine();
            }
            Write("Enter book price >> ");
           price = double.Parse(ReadLine());
            Write("Enter book number of pages >> ");

            numPages = int.Parse(ReadLine());
            books[x] = new Book(bookId, bookTitle, numPages, price);
        }
    }

    // Task 4 - DisplayAllBooks method
    public static void DisplayAllBooks(Book[] books)
    {
        WriteLine("Information of all Books");
        for (int x = 0; x < books.Length; ++x)
        {
            WriteLine("Book {0}: " + books[x].ToString(), x + 1);
        }
    }


    // Task 5 - GetBookLists method
    private static void GetBookLists(int num, Book[] books)
    {
        string code;
        WriteLine("The codes of categories are: ");
        for (int x = 0; x < Book.categoryCodes.Length; ++x)
        {

            WriteLine(Book.categoryCodes[x] + " " + Book.categoryNames[x]);
        }
        Write("Enter a category code or Z to quit >> ");
        code = ReadLine();
        bool check = false;
        int count = 0;
        while (code != "Z")
        {
            for (int x = 0; x < Book.categoryCodes.Length; ++x)
            {
                count = 0;
                if (code == Book.categoryCodes[x])
                {
                    check = true;
                    WriteLine("Books with category code {0} are: ", code);
                    
                    foreach (Book book in books)
                    {
                        if (book.BookId.Substring(0,2) == code)
                        {
                            WriteLine(book.ToString());
                            count++;
                        }
                        if (count == 0)
                        {
                            WriteLine("No books in the category {0}", code);
                        }
                    } 
                }
            }
            if (check == false)
            {
                WriteLine("{0} is not a valid category code", code);
            }
            Write("Enter a category code or Z to quit >> ");
            code = ReadLine();
        }
    }

    // Task 6 - Main method
    static void Main()
        {
            int num = InputValue(1, 30);
            Book[] books = new Book[num];
            GetBookData(num, books);
            DisplayAllBooks(books);
            GetBookLists(num, books);
        }
    
}