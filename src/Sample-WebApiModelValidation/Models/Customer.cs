using System;
using System.ComponentModel.DataAnnotations;

namespace Sample_WebApiModelValidation.Models
{
    public class Customer
    {
        public Guid? Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Range(1, 999)]
        public int Employees { get; set; }
    }
}
