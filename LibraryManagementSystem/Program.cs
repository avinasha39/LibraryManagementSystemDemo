using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Library Management System");
            bool loop = true;
            List<Book> BooksInLibrary = new List<Book>();
            List<User> UsersInLibDb = new List<User>();
            while (loop) {
                Console.WriteLine("Choose a option below");
                Console.WriteLine("1. Enter book details");
                Console.WriteLine("2. Enter user details");
                Console.WriteLine("3. Borrow a book");
                Console.WriteLine("4. Return a book");
                Console.WriteLine("5. Search for a book");
                Console.WriteLine("6. Retrive all book details");
                Console.WriteLine("7. Retrive all user details");
                Console.WriteLine("8. Exit the program");

                int input = Int32.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        {                            
                            Console.WriteLine("Enter Book Details");
                            Console.WriteLine("Enter Book Id :");
                            int tempId = Int32.Parse(Console.ReadLine());

                            Console.WriteLine("Enter Book Name :");
                            string tempName = Console.ReadLine();

                            Console.WriteLine("Enter Book Author :");
                            string tempAuthor = Console.ReadLine();

                            Console.WriteLine("Enter number of copies of the Book :");
                            int tempnumberOfcopies = Int32.Parse(Console.ReadLine());

                            Console.WriteLine("Enter Book location :");
                            string templocation = Console.ReadLine();

                            Book tempbook = new Book { BookId = tempId, BookName = tempName, Author = tempAuthor, NumberOfCopies = tempnumberOfcopies, Location = templocation };
                            
                            foreach (Book book in BooksInLibrary){
                                if(book.BookId == tempId)
                                {
                                    Console.WriteLine("Duplicate Book details found, Please try again");
                                    break;
                                }
                            }

                            BooksInLibrary.Add(tempbook);
                            //Console.WriteLine("\n\n Showing Book location :");
                            //book.retriveBookDetails();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter User Details");
                            Console.WriteLine("Enter User Id :");
                            int tempId = Int32.Parse(Console.ReadLine());

                            Console.WriteLine("Enter User Name :");
                            string tempName = Console.ReadLine();

                            User usr = new User(tempId, tempName);
                            UsersInLibDb.Add(usr);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter details of book to be borrowed");
                            Console.WriteLine("Enter book Id");
                            int tempId = Int32.Parse(Console.ReadLine());
                            var validBook = SearchForBook(BooksInLibrary, tempId);
                            if (validBook == null)
                            {
                                Console.WriteLine("Invalid bookId, please try again");
                                break;
                            }
                            else if (validBook.NumberOfCopies <= 0)
                            {
                                Console.WriteLine("Currently that book is not avialble in library");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Enter user Id");
                                int usrId = Int32.Parse(Console.ReadLine());
                                var user = UsersInLibDb.First(x => x.UserID == usrId);
                                user.Borrowedbooks.Add(validBook);
                                validBook.NumberOfCopies--;
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter user Id");
                            int usrId = Int32.Parse(Console.ReadLine());
                            var user = UsersInLibDb.First(x => x.UserID == usrId);

                            Console.WriteLine("Which book do you want to return");
                            int tempId = Int32.Parse(Console.ReadLine());
                            var validBook = SearchForBook(BooksInLibrary, tempId);

                            if (validBook == null)
                            {
                                Console.WriteLine("You entered wrong book Id");
                            }

                            user.Borrowedbooks.Remove(validBook);
                            validBook.NumberOfCopies++;

                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter Book Id to be searched:");
                            var tempbookId = int.Parse(Console.ReadLine());
                            var bookfound = SearchForBook(BooksInLibrary, tempbookId);

                            if(bookfound == null)
                            {
                                Console.WriteLine("No Book details found for the Id provided");
                            }
                            else
                            {
                                Console.WriteLine("Book details as follows");
                                bookfound.retriveBookDetails();
                            }                            
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Showing all book details");
                            foreach(var bk in BooksInLibrary)
                            {
                                bk.retriveBookDetails();
                            }
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Showing all user details");
                            foreach (var usr in UsersInLibDb)
                            {
                                usr.retriveUserDetails();
                            }
                            break;
                        }
                    case 8:
                        {
                            loop = false;
                            break;
                        }
                    default:
                        Console.WriteLine("!!!! Invalid input, please try again !!!!");
                        break;

                }
            }
        }

        private static Book SearchForBook(List<Book> BooksInLibrary, int bookId)
        {
            foreach (Book book in BooksInLibrary)
            {
                if (book.BookId == bookId)
                {
                    return book;
                }
            }
            return null;
        }
    }
}
