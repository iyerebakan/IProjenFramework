using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScaffoldMigrationApp.Entities
{
    public partial class OperationClaims
    {
        public OperationClaims()
        {
            FormRights = new HashSet<FormRights>();
            UserOperationClaims = new HashSet<UserOperationClaims>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [InverseProperty("OperationClaim")]
        public virtual ICollection<FormRights> FormRights { get; set; }
        [InverseProperty("OperationClaim")]
        public virtual ICollection<UserOperationClaims> UserOperationClaims { get; set; }
    }
}
