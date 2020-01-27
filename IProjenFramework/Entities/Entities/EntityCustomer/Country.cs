using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityCustomer.Entities.Entities
{
    public class Country : BaseEntity<int>
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [InverseProperty("Country")]
        public virtual ICollection<City> Cities { get; set; }
        [InverseProperty("Country")]
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}
