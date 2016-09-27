using System.ComponentModel.DataAnnotations;

namespace MVCCustomer.ViewModels
{
    public class CustomerEditViewModel
    {
        [Required, MaxLength(80)]
        public string FirstName { get; set; }

        [Required, MaxLength(80)]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string FavoriteColor { get; set; }
    }
}
