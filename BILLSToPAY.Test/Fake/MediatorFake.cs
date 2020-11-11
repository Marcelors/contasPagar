using System;
using System.Threading;
using System.Threading.Tasks;
using BILLSToPAY.Domain.Shared.Notification;
using MediatR;

namespace BILLSToPAY.Test.Fake
{
    public class MediatorFake : IMediator
    {
        private readonly DomainNotificationHandler _notifications;

        public MediatorFake(INotificationHandler<DomainNotification> notificationHandler)
        {
            _notifications = (DomainNotificationHandler)notificationHandler;
        }

        public Task Publish(object notification, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
        {
            _notifications.Handle(notification as DomainNotification, cancellationToken);
            return Task.CompletedTask;
        }

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<object> Send(object request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
