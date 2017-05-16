using System.ComponentModel.DataAnnotations;

namespace BookShopSytem.Models.Bms.Authors
{
    public class AddAuthorBm
    {
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
