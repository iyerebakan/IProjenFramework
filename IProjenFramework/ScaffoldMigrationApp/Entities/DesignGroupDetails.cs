using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScaffoldMigrationApp.Entities
{
    public partial class DesignGroupDetails
    {
        [Key]
        public int Id { get; set; }
        public int FormId { get; set; }
        public int DesignGroupId { get; set; }

        [ForeignKey(nameof(DesignGroupId))]
        [InverseProperty(nameof(DesignGroups.DesignGroupDetails))]
        public virtual DesignGroups DesignGroup { get; set; }
        [ForeignKey(nameof(FormId))]
        [InverseProperty(nameof(Forms.DesignGroupDetails))]
        public virtual Forms Form { get; set; }
    }
}
