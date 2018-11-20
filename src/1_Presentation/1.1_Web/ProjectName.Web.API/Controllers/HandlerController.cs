
using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using ProjectName.DomainName.Application.Commands.AddressCommands;
using ProjectName.DomainName.Application.ViewModels;
using ProjectName.DomainName.Domain.Interfaces.Repository;
using ProjectName.Shared.Bus.Abstractions;

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
            var addresses = await this._addressReadRepository.GetAllAsync();

            return Response(addresses);
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