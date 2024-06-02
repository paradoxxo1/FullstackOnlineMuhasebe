using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRLFeatures.Commands.CreateUserAndCompanyRL;
using OnlineMuhasebeServer.Prenstation.Abstraction;

namespace OnlineMuhasebeServer.Presentation.Controller;

public class UserAndCompanyRelationshipsController : ApiController
{
    public UserAndCompanyRelationshipsController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateUserAndCompanyRLCommand request)
    {
        CreateUserAndCompanyRLCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}
