using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopSytem.Models.Vms.Authors
{
    public class DetailedAuthorVm
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public IEnumerable<string> BookTitles { get; set; }
    }
}
