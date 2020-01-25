using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityCustomer.Entities.Entities
{
    public class CustomerAddress : CardBaseEntity<int>
    {
        public CustomerAddress(bool create, int userId)
            : base(create, userId)
        {
        }

        public CustomerAddress()
            : base(false, null)
        {
        }
        public int CustomerId { get; set; }
        public int? DistrictId { get; set; }
        public int? CityId { get; set; }
        public int? CountryId { get; set; }
        [Required]
        [StringLength(225)]
        public string FullAddress { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty("CustomerAddresses")]
        public virtual City City { get; set; }
        [ForeignKey(nameof(CountryId))]
        [InverseProperty("CustomerAddresses")]
        public virtual Country Country { get; set; }
        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("CustomerAddresses")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(DistrictId))]
        [InverseProperty("CustomerAddresses")]
        public virtual District District { get; set; }
    }
}
