using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScaffoldMigrationApp.Entities
{
    public partial class Users
    {
        public Users()
        {
            FormRights = new HashSet<FormRights>();
            UserOperationClaims = new HashSet<UserOperationClaims>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<FormRights> FormRights { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserOperationClaims> UserOperationClaims { get; set; }
    }
}
