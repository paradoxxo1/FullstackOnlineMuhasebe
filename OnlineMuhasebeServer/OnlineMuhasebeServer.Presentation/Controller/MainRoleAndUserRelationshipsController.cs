using MediatR;
using OnlineMuhasebeServer.Prenstation.Abstraction;

namespace OnlineMuhasebeServer.Presentation.Controller;

public class MainRoleAndUserRelationshipsController : ApiController
{
    public MainRoleAndUserRelationshipsController(IMediator mediator) : base(mediator) { }
}
