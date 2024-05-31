using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Domain;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateStaticMainRoles;

public sealed record CreateStaticMainRolesCommand(
    List<MainRole> MainRoles) : ICommand<CreateStaticMainRolesCommandResponse>;
