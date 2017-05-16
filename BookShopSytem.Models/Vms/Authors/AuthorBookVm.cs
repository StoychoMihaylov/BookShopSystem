using System;
using System.Collections.Generic;
using BookShopSytem.Models.Entities;

namespace BookShopSytem.Models.Vms.Authors
{
    public class AuthorBookVm
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public EditionType EditionType { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public IEnumerable<string> CategoryNames { get; set; }
    }
}
