using Core.RabbitMQ.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.RabbitMQ.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
