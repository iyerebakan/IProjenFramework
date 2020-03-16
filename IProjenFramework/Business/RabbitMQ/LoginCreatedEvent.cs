using Core.RabbitMQ.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.RabbitMQ
{
    public class LoginCreatedEvent : Event
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }

        public LoginCreatedEvent(string firstname,string lastname,string email)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Message = "Login Olundu.";
        }
    }
}
