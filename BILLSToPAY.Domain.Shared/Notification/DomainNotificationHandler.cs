using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace BILLSToPAY.Domain.Shared.Notification
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>, IDisposable
    {
        private IList<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }

        public virtual IList<DomainNotification> GetNotifications =>
            _notifications;


        public virtual bool HasNotifications() =>
           _notifications.Any();

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }

    }
}
