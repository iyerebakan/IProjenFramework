using System;
using System.Collections.Generic;
using System.Text;

namespace Core.RabbitMQ.Events
{
    public abstract class Event
    {
        public DateTime Timestamp { get; protected set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
