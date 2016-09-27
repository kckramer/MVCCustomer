using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MVCCustomer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCustomer.Entities
{
    public class EmailValidation : ValidationAttribute//, IClientModelValidator
    {
        private string _email;
        private ICustomerData _customerData;

        public EmailValidation()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)value;

            if (_customerData.GetAll().Any(x => x.Email == customer.Email))
            {
                return new ValidationResult("Email address not unique. Please try again with a different email.");
            }

            return ValidationResult.Success;
        }
    }
}
