using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Interfaces
{
    public interface ICardBaseEntity<TKey, TUser> : IEntity<TKey>
        where TUser : User
    {
        string ModifiedBy { get; set; }

        string CreatedBy { get; set; }

        DateTime CreationDate { get; set; }

        DateTime? UpdatedDate { get; set; }

        Guid RowVersion { get; set; }

        bool Active { get; set; }

        bool IsDeleted { get; set; }

        TUser ModifiedByUser { get; set; }

        TUser CreatedByUser { get; set; }
    }
}
