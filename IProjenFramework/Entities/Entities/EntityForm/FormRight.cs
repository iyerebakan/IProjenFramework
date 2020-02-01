using Core.Entities.Concrete;
using Entities.Entities.EntityUser;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities.EntityForm
{
    public class FormRight : BaseEntity<int>
    {
        public int? UserId { get; set; }
        public int? OperationClaimId { get; set; }
        public int FormId { get; set; }
        public bool ViewRight { get; set; }
        public bool InsertRight { get; set; }
        public bool UpdateRight { get; set; }
        public bool DeleteRight { get; set; }

        [ForeignKey(nameof(FormId))]
        [InverseProperty("FormRights")]
        public virtual Form Form { get; set; }
        [ForeignKey(nameof(OperationClaimId))]
        [InverseProperty("FormRights")]
        public virtual OperationClaim OperationClaim { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("FormRights")]
        public virtual User User { get; set; }
    }
}
