using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScaffoldMigrationApp.Entities
{
    public partial class FormRights
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? OperationClaimId { get; set; }
        public int FormId { get; set; }
        public bool ViewRight { get; set; }
        public bool InsertRight { get; set; }
        public bool UpdateRight { get; set; }
        public bool DeleteRight { get; set; }

        [ForeignKey(nameof(FormId))]
        [InverseProperty(nameof(Forms.FormRights))]
        public virtual Forms Form { get; set; }
        [ForeignKey(nameof(OperationClaimId))]
        [InverseProperty(nameof(OperationClaims.FormRights))]
        public virtual OperationClaims OperationClaim { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.FormRights))]
        public virtual Users User { get; set; }
    }
}
