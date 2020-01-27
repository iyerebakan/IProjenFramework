using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScaffoldMigrationApp.Entities
{
    public partial class Districts
    {
        public Districts()
        {
            CustomerAddresses = new HashSet<CustomerAddresses>();
        }

        [Key]
        public int Id { get; set; }
        public int CityId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty(nameof(Cities.Districts))]
        public virtual Cities City { get; set; }
        [InverseProperty("District")]
        public virtual ICollection<CustomerAddresses> CustomerAddresses { get; set; }
    }
}
