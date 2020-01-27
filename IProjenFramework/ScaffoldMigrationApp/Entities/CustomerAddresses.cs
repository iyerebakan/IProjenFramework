using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScaffoldMigrationApp.Entities
{
    public partial class CustomerAddresses
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int? DistrictId { get; set; }
        public int? CityId { get; set; }
        public int? CountryId { get; set; }
        [Required]
        [StringLength(225)]
        public string FullAddress { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty(nameof(Cities.CustomerAddresses))]
        public virtual Cities City { get; set; }
        [ForeignKey(nameof(CountryId))]
        [InverseProperty(nameof(Countries.CustomerAddresses))]
        public virtual Countries Country { get; set; }
        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customers.CustomerAddresses))]
        public virtual Customers Customer { get; set; }
        [ForeignKey(nameof(DistrictId))]
        [InverseProperty(nameof(Districts.CustomerAddresses))]
        public virtual Districts District { get; set; }
    }
}
