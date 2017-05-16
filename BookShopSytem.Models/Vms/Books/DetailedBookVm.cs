using System;
using System.Collections.Generic;

namespace BookShopSytem.Models.Vms.Books
{
    public class DetailedBookVm
    {
        public int Id { get; set; }
                                                
        public string Title { get; set; }
                                                
        public string Description { get; set; }

        public string EditionType { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string AgeRestriction { get; set; }

        public DetailedBookAuthorVm Author { get; set; }

        public IEnumerable<string> CategoryNames { get; set; }         
    }
}
