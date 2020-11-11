using System;
using MediatR;

namespace BILLSToPAY.Domain.Shared.Notification
{
    public class DomainNotification : INotification
    {
        public string Value { get; private set; }
        public Guid Id { get; private set; }


        public DomainNotification(string value)
        {
            Value = value;
            Id = Guid.NewGuid();
        }
    }
}
