using Core.Entities;
using Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities.EntityUser
{
    public class UserOperationClaim : IBaseEntity<int>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        [ForeignKey("OperationClaimId")]
        [InverseProperty("UserOperationClaims")]
        public virtual OperationClaim OperationClaim { get; set; }
    }
}
