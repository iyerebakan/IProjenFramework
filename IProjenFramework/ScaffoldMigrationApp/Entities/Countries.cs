using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScaffoldConsoleApp.Entities
{
    public partial class Countries
    {
        public Countries()
        {
            Cities = new HashSet<Cities>();
            CustomerAddresses = new HashSet<CustomerAddresses>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int deneme { get; set; }

        [InverseProperty("Country")]
        public virtual ICollection<Cities> Cities { get; set; }
        [InverseProperty("Country")]
        public virtual ICollection<CustomerAddresses> CustomerAddresses { get; set; }
    }
}
