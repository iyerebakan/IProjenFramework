using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Interfaces
{
    public interface ICardBaseEntity<TKey, TUser> : IBaseEntity<TKey>
        where TUser : User
    {
        int? UpdateUser { get; set; }

        int? CreateUser { get; set; }

        DateTime? CreateDate { get; set; }

        DateTime? UpdatedDate { get; set; }

        TUser UpdatedByUser { get; set; }

        TUser CreatedByUser { get; set; }
    }
}
