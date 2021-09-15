using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    /// <summary>
    ///     
    /// </summary>
    class Book
    {

        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public int NumberOfCopies { get; set; }
        public string Location { get; set; }


        public void retriveBookDetails()
        {
            Console.Write("BookId : " + BookId);
            Console.Write(" BookName : " + BookName);
            Console.Write(" Author : " + Author);
            Console.Write(" Number Of Copies : " + NumberOfCopies+"\n");
        }


    }
}
