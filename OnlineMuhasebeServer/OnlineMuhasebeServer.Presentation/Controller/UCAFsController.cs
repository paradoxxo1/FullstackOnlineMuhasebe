using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using OnlineMuhasebeServer.Prenstation.Abstraction;

namespace OnlineMuhasebeServer.Prenstation.Controller
{
    public sealed class UCAFsController : ApiController
    {
        public UCAFsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUCAF(CreateUCAFCommand request, CancellationToken cancellationToken)
        {
            CreateUCAFCommandResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
