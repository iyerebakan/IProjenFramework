using Core.RabbitMQ.Bus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.RabbitMQ
{
    public class LoginCommandHandler : IRequestHandler<CreateLoginCommand, bool>
    {
        private readonly IEventBus _bus;

        public LoginCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateLoginCommand request, CancellationToken cancellationToken)
        {
            //publish event to RabbitMQ
            _bus.Publish(new LoginCreatedEvent(request.FirstName,request.LastName,request.Email));

            return Task.FromResult(true);
        }
    }
}

