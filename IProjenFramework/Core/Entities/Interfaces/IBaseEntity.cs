using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Interfaces
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
    }
}
