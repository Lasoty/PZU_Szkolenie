namespace Bibliotekarz.Model
{
    public class AddBookViewModel
    {
        public string Author { get; set; }

        public string Title { get; set; }

        public int PageCount { get; set; }

        public bool IsBorrowed { get; set; }

        public string BorrowerFirstName { get; set; }

        public string BorrowerLastName { get; set; }
    }
}
