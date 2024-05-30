using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;

public sealed class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id bilgisi boş olamaz. Lütfen Doldurun! ");
        RuleFor(p => p.Id).NotNull().WithMessage("Id bilgisi boş olamaz. Lütfen Doldurun! ");
        RuleFor(p => p.Code).NotEmpty().WithMessage("Role kodu bilgisi boş olamaz. Lütfen Doldurun! ");
        RuleFor(p => p.Code).NotEmpty().WithMessage("Role kodu  bilgisi boş olamaz. Lütfen Doldurun! ");
        RuleFor(p => p.Name).NotEmpty().WithMessage("Role adı bilgisi boş olamaz. Lütfen Doldurun! ");
        RuleFor(p => p.Name).NotEmpty().WithMessage("Role adı bilgisi boş olamaz. Lütfen Doldurun! ");
    }
}
