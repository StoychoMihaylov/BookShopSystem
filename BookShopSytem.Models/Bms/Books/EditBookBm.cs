namespace BookShopSytem.Models.Bms.Books
{
    public class EditBookBm
    {                                             
        public string Title { get; set; }
                                                  
        public string Description { get; set; }

        public string EditionType { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public string ReleaseDate { get; set; }

        public string AgeRestriction { get; set; }

        public int AuthorId { get; set; }
    }
}
