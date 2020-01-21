using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScaffoldConsoleApp.Entities
{
    public partial class UserOperationClaims
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        [ForeignKey(nameof(OperationClaimId))]
        [InverseProperty(nameof(OperationClaims.UserOperationClaims))]
        public virtual OperationClaims OperationClaim { get; set; }
    }
}
