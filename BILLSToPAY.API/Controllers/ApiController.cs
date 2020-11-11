using System.Linq;
using BILLSToPAY.Domain.Shared.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BILLSToPAY.API.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected readonly DomainNotificationHandler _notifications;
        protected readonly IMediator Bus;

        protected ApiController(IMediator bus, INotificationHandler<DomainNotification> notifications)
        {
            Bus = bus;
            _notifications = (DomainNotificationHandler)notifications;
        }

        private bool IsValidOperation()
        {
            return _notifications.HasNotifications();
        }

        protected new IActionResult Response(object result = null)
        {
            if (!IsValidOperation())
            {
                return Ok(new { data = result });
            }

            var errorMessages = _notifications.GetNotifications;

            return BadRequest(new { message = string.Join("\n ", errorMessages.Select(x => x.Value)) });
        }


        protected void NotifyModelStateErrors()
        {
            var erros = ModelState.Values.SelectMany(x => x.Errors);

            AddNotifyError(string.Join("\n ", erros.Select(err => err.Exception == null ? err.ErrorMessage : err.Exception.Message)));
        }

        void AddNotifyError(string message)
        {
            Bus.Publish(new DomainNotification(message));
        }
    }
}
