using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities.EntityForm
{
    public class DesignGroupDetail : BaseEntity<int>
    {
        public int FormId { get; set; }
        public int DesignGroupId { get; set; }
        [ForeignKey(nameof(DesignGroupId))]
        [InverseProperty("DesignGroupDetails")]
        public virtual DesignGroup DesignGroup { get; set; }
        [ForeignKey(nameof(FormId))]
        [InverseProperty("DesignGroupDetails")]
        public virtual Form Form { get; set; }
    }
}
