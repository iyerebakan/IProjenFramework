using Core.Entities;
using Core.Entities.Concrete;
using Core.Entities.Interfaces;
using Entities.Entities.EntityForm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities.EntityUser
{
    public class User : BaseEntity<int>,IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<FormRight> FormRights { get; set; }
    }
}
