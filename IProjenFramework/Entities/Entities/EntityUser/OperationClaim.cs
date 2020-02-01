using Core.Entities;
using Core.Entities.Concrete;
using Core.Entities.Interfaces;
using Entities.Entities.EntityForm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entities.EntityUser
{
    public class OperationClaim : BaseEntity<int>,IClaim
    {
        public string Name { get; set; }

        [InverseProperty("OperationClaim")]
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }

        [InverseProperty("OperationClaim")]
        public virtual ICollection<FormRight> FormRights { get; set; }
    }
}
