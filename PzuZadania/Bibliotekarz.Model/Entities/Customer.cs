using System.Collections.Generic;

namespace Bibliotekarz.Model.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<Book> Books { get; set; }
    }
}