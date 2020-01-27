using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScaffoldMigrationApp.Entities
{
    public partial class DesignGroups
    {
        public DesignGroups()
        {
            DesignGroupDetails = new HashSet<DesignGroupDetails>();
            InverseDesignGroupMaster = new HashSet<DesignGroups>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(225)]
        public string Description { get; set; }
        public int? DesignGroupMasterId { get; set; }

        [ForeignKey(nameof(DesignGroupMasterId))]
        [InverseProperty(nameof(DesignGroups.InverseDesignGroupMaster))]
        public virtual DesignGroups DesignGroupMaster { get; set; }
        [InverseProperty("DesignGroup")]
        public virtual ICollection<DesignGroupDetails> DesignGroupDetails { get; set; }
        [InverseProperty(nameof(DesignGroups.DesignGroupMaster))]
        public virtual ICollection<DesignGroups> InverseDesignGroupMaster { get; set; }
    }
}
