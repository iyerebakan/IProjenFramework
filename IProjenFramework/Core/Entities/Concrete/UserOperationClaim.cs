using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim : IEntity<int>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        [ForeignKey("OperationClaimId")]
        [InverseProperty("UserOperationClaims")]
        public virtual OperationClaim OperationClaim { get; set; }
    }
}
