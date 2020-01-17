using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Interfaces
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
