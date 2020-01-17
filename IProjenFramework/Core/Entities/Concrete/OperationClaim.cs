using Core.Entities;
using Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities.Concrete
{
    public class OperationClaim : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [InverseProperty("OperationClaim")]
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
