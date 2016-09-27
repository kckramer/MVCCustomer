using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCustomer.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, MaxLength(80)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailValidation]
        public string Email { get; set; }

        public string FavoriteColor { get; set; }
    }
}
