using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScaffoldConsoleApp.Entities
{
    public partial class Customers
    {
        public Customers()
        {
            CustomerAddresses = new HashSet<CustomerAddresses>();
        }

        [Key]
        public int Id { get; set; }
        public int? UpdateUser { get; set; }
        public int? CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string Title { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        [Required]
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public string Identifier { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Code { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<CustomerAddresses> CustomerAddresses { get; set; }
    }
}
