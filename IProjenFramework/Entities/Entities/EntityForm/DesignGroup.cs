using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities.EntityForm
{
    public class DesignGroup : BaseEntity<int>
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(225)]
        public string Description { get; set; }
        public int? DesignGroupMasterId { get; set; }

        [ForeignKey(nameof(DesignGroupMasterId))]
        [InverseProperty(nameof(DesignGroup.InverseDesignGroupMaster))]
        public virtual DesignGroup DesignGroupMaster { get; set; }
        [InverseProperty("DesignGroup")]
        public virtual ICollection<DesignGroupDetail> DesignGroupDetails { get; set; }
        [InverseProperty(nameof(DesignGroup.DesignGroupMaster))]
        public virtual ICollection<DesignGroup> InverseDesignGroupMaster { get; set; }
    }
}
