
using System;

using Microsoft.AspNetCore.Mvc;
using ProjectName.DomainName.Application.ViewModels;
using ProjectName.Shared.Bus.Abstractions.ValueObjects;

namespace ProjectName.Web.API.Controllers
{
    public class ServiceController : BaseController
    {
        public ServiceController(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            
        }

        [HttpGet]
        [Route("api/Service/Index")]
        [Route("api/Service")]
        public IActionResult Index()
        {
            base.ServiceBus.PublishEvent(new Notification("Key", "Value!!!"));

            return Response();
        }

        // POST api/Service/Save
        [HttpPost]
        [Route("api/[controller]/Save")]
        public IActionResult Save([FromBody] AddressViewModel addressViewModel)
        {
            
            
            return Response();
        }
    }
}
