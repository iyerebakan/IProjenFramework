using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities.EntityForm
{
    public class Form : BaseEntity<int>
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        public bool Locked { get; set; }

        [InverseProperty("Form")]
        public virtual ICollection<DesignGroupDetail> DesignGroupDetails { get; set; }
    }
}
