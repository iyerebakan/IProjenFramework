using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScaffoldMigrationApp.Entities
{
    public partial class Cities
    {
        public Cities()
        {
            CustomerAddresses = new HashSet<CustomerAddresses>();
            Districts = new HashSet<Districts>();
        }

        [Key]
        public int Id { get; set; }
        public int CountryId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [ForeignKey(nameof(CountryId))]
        [InverseProperty(nameof(Countries.Cities))]
        public virtual Countries Country { get; set; }
        [InverseProperty("City")]
        public virtual ICollection<CustomerAddresses> CustomerAddresses { get; set; }
        [InverseProperty("City")]
        public virtual ICollection<Districts> Districts { get; set; }
    }
}
