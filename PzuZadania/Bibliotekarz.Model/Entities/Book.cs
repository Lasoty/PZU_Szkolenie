using System.Collections.Generic;

namespace Bibliotekarz.Model.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public int PageCount { get; set; }

        public bool IsBorrowed { get; set; }

        public Customer Borrower { get; set; }
        
        public int? BorrowerId { get; set; }
    }
}
