using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Interfaces
{
    public interface IUser:IBaseEntity<int>
    {
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }

    }
}
