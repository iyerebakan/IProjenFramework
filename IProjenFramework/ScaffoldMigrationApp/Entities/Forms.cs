using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScaffoldMigrationApp.Entities
{
    public partial class Forms
    {
        public Forms()
        {
            DesignGroupDetails = new HashSet<DesignGroupDetails>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        public bool Locked { get; set; }

        [InverseProperty("Form")]
        public virtual ICollection<DesignGroupDetails> DesignGroupDetails { get; set; }
    }
}
