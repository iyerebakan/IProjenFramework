using System;
using System.Collections.Generic;
using System.Text;

namespace Business.RabbitMQ
{
    public class CreateLoginCommand : LoginCommand
    {
        public CreateLoginCommand(string firstname, string lastname, string email)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
        }
    }
}
