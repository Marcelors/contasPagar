using BILLSToPAY.ApplicationService.Interfaces;
using BILLSToPAY.ApplicationService.Model;
using BILLSToPAY.Domain.Shared.Models;
using BILLSToPAY.Domain.Shared.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
namespace BILLSToPAY.API.Controllers
{
    [Route("v1/accounts")]
    [ApiController]
    public class AccountController : ApiController
    {
        private readonly IAccountApplicationService _accountApplicationService;

        public AccountController(IMediator bus, INotificationHandler<DomainNotification> notifications, IAccountApplicationService accountApplicationService) : base(bus, notifications)
        {
            _accountApplicationService = accountApplicationService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] Filter filter)
        {
            var result = _accountApplicationService.Get(filter);
            return Response(result);
        }


        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var result = _accountApplicationService.GetById(id);
            return Response(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] AccountModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response();
            }
            _accountApplicationService.Add(model);
            return Response();
        }


        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _accountApplicationService.Remove(id);
            return Response();
        }

    }
}
