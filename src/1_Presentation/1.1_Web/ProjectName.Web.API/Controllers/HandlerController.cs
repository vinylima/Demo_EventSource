
using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using ProjectName.DomainName.Application.Commands.AddressCommands;
using ProjectName.DomainName.Domain.Interfaces.Repository;
using ProjectName.Shared.Bus.Abstractions.ValueObjects;

namespace ProjectName.Web.API.Controllers
{
    public class HandlerController : BaseController
    {
        private readonly IAddressReadRepository _addressReadRepository;

        public HandlerController(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            this._addressReadRepository = serviceProvider.GetService<IAddressReadRepository>();
        }

        [HttpGet]
        [Route("api/Handler")]
        public async Task<IActionResult> Index()
        {
            await this.ServiceBus.PublishEvent(new Notification("Key", "Value"));

            return Response();
        }

        // POST api/Service/Save
        [HttpPost]
        [Route("api/Handler/Save")]
        public IActionResult Save([FromBody] SaveAddressCommand addressViewModel)
        {
            this.ServiceBus.SendCommand(addressViewModel);

            return Response();
        }

        [HttpGet]
        [Route("api/Handler/Search")]
        public async Task<IActionResult> Search(Guid addressId)
        {
            var addressViewModel = await this.ServiceBus.SendCommand(new SearchAddressCommand(addressId));

            return Response(addressViewModel);
        }
    }
}