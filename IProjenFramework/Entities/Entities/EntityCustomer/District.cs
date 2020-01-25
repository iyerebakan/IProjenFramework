using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityCustomer.Entities.Entities
{
    public class District
    {

        [Key]
        public int Id { get; set; }
        public int CityId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty("Districts")]
        public virtual City City { get; set; }
        [InverseProperty("District")]
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}
