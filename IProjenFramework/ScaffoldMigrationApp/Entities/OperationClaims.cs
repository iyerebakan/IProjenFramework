using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScaffoldConsoleApp.Entities
{
    public partial class OperationClaims
    {
        public OperationClaims()
        {
            UserOperationClaims = new HashSet<UserOperationClaims>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [InverseProperty("OperationClaim")]
        public virtual ICollection<UserOperationClaims> UserOperationClaims { get; set; }
    }
}
