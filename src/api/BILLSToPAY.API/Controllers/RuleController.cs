using BILLSToPAY.ApplicationService.Interfaces;
using BILLSToPAY.ApplicationService.Model;
using BILLSToPAY.Domain.Shared.Models;
using BILLSToPAY.Domain.Shared.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
namespace BILLSToPAY.API.Controllers
{
    [Route("v1/rules")]
    [ApiController]
    public class RuleController : ApiController
    {
        private readonly IRuleApplicationService _ruleApplicationService;

        public RuleController(IMediator bus, INotificationHandler<DomainNotification> notifications, IRuleApplicationService ruleApplicationService) : base(bus, notifications)
        {
            _ruleApplicationService = ruleApplicationService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] Filter filter)
        {
            var result = _ruleApplicationService.Get(filter);
            return Response(result);
        }

        [HttpGet("types")]
        public IActionResult GetTypes()
        {
            var result = _ruleApplicationService.GetTypes();
            return Response(result);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var result = _ruleApplicationService.GetById(id);
            return Response(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] RuleModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response();
            }
            _ruleApplicationService.Add(model);
            return Response();
        }


        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _ruleApplicationService.Remove(id);
            return Response();
        }

        [HttpPost("enable/{id:guid}")]
        public IActionResult Enable(Guid id)
        {
            _ruleApplicationService.Enable(id);
            return Response();
        }

        [HttpPost("disable/{id:guid}")]
        public IActionResult Disable(Guid id)
        {
            _ruleApplicationService.Disable(id);
            return Response();
        }
    }
}
