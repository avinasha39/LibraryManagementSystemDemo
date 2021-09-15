using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class User
    {
        private string userName;
        private float finePaid;

        public int UserID { get; set; }

        public List<Book> Borrowedbooks
        {
            get;
            set;
        }

        public User(int Id, string name)
        {
            UserID = Id;
            userName = name;
            finePaid = 0;
            Borrowedbooks = new List<Book>();
        }

        public void retriveUserDetails()
        {
            Console.Write("UserId : " + UserID);
            Console.Write(" UserName : " + userName);
            Console.Write(" Browwed books by the user :");
            foreach(var bk in Borrowedbooks)
            {
                Console.WriteLine(bk.BookName);
            }
        }

    }
}
