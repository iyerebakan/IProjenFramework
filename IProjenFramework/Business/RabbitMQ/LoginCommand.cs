using Core.RabbitMQ.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.RabbitMQ
{
    public class LoginCommand : Command
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        public string Message { get; protected set; }
    }
}
