using System;
using System.IO;

namespace Le1Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
           new Program();
        }


        public Program()
        {
            BookListManager BL = new BookListManager();
            Console.WriteLine("Hello");
            BL.LoadBooks();
            Console.WriteLine("Books Loaded");

            int option = 0;

            do
            {
                Console.WriteLine();
                Console.WriteLine("MENU: What would you like to do?");
                Console.WriteLine("1. Save out of stock books to file");
                Console.WriteLine("2. Search for a book using a keyword");
                Console.WriteLine("3. Display books at a discounted price");
                Console.WriteLine("4. Delete all books containing a keyword");
                Console.WriteLine("5. Exit");

                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                   
                }


            } while (option != 0);


            Console.ReadLine();
        }
    }


    class BookListManager
    {
        Book [] book = new Book[2000];
        int size = 0;


        private void AddToList(Book b)
        // Post: Adds b to the list of books
        {

            book[size] = b; // adds the element b to the back of array.
            size++; //increment size.
           
        }

        public void DisplayDiscountedBooks()
        // Post: Display all books with a 10 % discount
        {
            for(int i = 0; i <= size; i++)
            {
                Console.WriteLine(book[i].GetTitle() + "," + book[i].GetAuthor() + "," + book[i].GetCategory() + "," + book[i].GetDiscountedPrice());
            }
        }

        private int FindBook(String keyword)
        // Pre: keyword contains a search string
        // Post: The first location of a book containing substring keyword in title or author fields is return. If not found then -1 is returned
        {
            
            for(int i = 0; i <= size; i++)
            {
                if (book[i].GetTitle().Contains(keyword) || book[i].GetAuthor().Contains(keyword)) 

                    return i;
            }
            return -1;
        }

        public void SearchBook(String keyword)
        // Pre: keyword contains a search string
        // Post: The first book containing substring keyword in title or author fields is displayed. Otherwise "Book not found" is displayed
        {

            int x = FindBook(keyword);

            if (x >= 0)
            {
                Console.WriteLine(book[x].GetAuthor() + "," + book[x].GetTitle() + "," + book[x].GetCategory() + book[x].GetPrice());
            }
            else
                Console.WriteLine("Book not found :");
        }


        public void LoadBooks()
        // Post: All the books from the file is loaded into the book list
        {

            StreamReader sr = new StreamReader("Library.csv");

            String line = sr.ReadLine();
            line = sr.ReadLine();
            while (line != null) //keeps reading until end of file, which is when line = null, so while loop must go on till line is not null
            {
                String[] elements = line.Split(",");
                Book temp;
                if (elements[4] == "Y")
                {
                    temp = new Book(elements[0], elements[1], elements[2], int.Parse(elements[3]), true, double.Parse(elements[5]));
                }
                else temp = new Book(elements[0], elements[1], elements[2], int.Parse(elements[3]), false, double.Parse(elements[5]));

                AddToList(temp);

                line = sr.ReadLine();
            }


            sr.Close();


        }

        public void SaveOutOfStock()
        // Post: All the books that are out of stock are saved to a comma delimited file
        {
            StreamWriter sw = new StreamWriter("NewFile.csv");

            for(int i = 0; i <= size; i++)
            {
                if(!book[i].GetInStock())
                {
                    sw.WriteLine(book[i].GetTitle() + "," + book[i].GetAuthor() + "," + book[i].GetCategory() + "," + book[i].GetNrPages() + ",N," + book[i].GetPrice());
                }
            }
            sw.Close();


        }

        public void DeleteAllBooks(String keyword)
        // Pre: keyword contains a search string
        // Post: All the books containing substring keyword in title or author fields is displayed and deleted from the list
        {
            

        }

        private void DeleteAt(int p)
        // Pre: p is a valid book location (i.e. 0 <= p < size)
        // Post: The book at loaction p is deleted and other books shifted to correct posistions
        {
            

        }

    }


    class Book
    {
        private String title;
        private String author;
        private String category;
        private int nrPages;
        private bool inStock;
        private double price;

        public Book(String title, String author, String category, int nrPages, bool inStock, double price)
        {
            this.title = title;
            this.author = author;
            this.category = category;
            this.nrPages = nrPages;
            this.inStock = inStock;
            this.price = price;
        }

        public String GetTitle()
        {
            return title;
        }

        public String GetAuthor()
        {
            return author;
        }

        public String GetCategory()
        {
            return category;
        }

        public int GetNrPages()
        {
            return nrPages;
        }

        public bool GetInStock()
        {
            return inStock;
        }

        public double GetPrice()
        {
            return price;
        }


        public double GetDiscountedPrice()
        // Post: A 10% discount is applied to price and returned
        {
            double discPrice = 0.9 * price;
            return discPrice;
        }

    }
}
