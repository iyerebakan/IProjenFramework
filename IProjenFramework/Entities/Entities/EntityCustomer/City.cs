using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityCustomer.Entities.Entities
{
    public class City : CardBaseEntity<int>
    {
        public City(bool create, int userId)
             : base(create, userId)
        {
        }

        public City()
            : base(false, null)
        {
        }
        public int CountryId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [ForeignKey(nameof(CountryId))]
        [InverseProperty("Cities")]
        public virtual Country Country { get; set; }
        [InverseProperty("City")]
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
        [InverseProperty("City")]
        public virtual ICollection<District> Districts { get; set; }
    }
}
