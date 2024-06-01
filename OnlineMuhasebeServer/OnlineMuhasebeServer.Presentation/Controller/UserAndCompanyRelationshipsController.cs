using MediatR;
using OnlineMuhasebeServer.Prenstation.Abstraction;

namespace OnlineMuhasebeServer.Presentation.Controller;

public class UserAndCompanyRelationshipsController : ApiController
{
    public UserAndCompanyRelationshipsController(IMediator mediator) : base(mediator) { }
}
