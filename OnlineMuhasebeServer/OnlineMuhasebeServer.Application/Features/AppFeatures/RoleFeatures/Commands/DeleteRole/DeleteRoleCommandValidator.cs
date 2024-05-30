using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;

public sealed class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
{
    public DeleteRoleCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id bilgisi yazılmalıdır. Boş olamaz! ");
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id bilgisi yazılmalıdır. Boş olamaz! ");
    }
}
