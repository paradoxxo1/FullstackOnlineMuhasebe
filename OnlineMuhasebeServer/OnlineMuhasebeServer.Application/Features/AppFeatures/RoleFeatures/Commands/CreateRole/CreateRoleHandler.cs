using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole
{
    public sealed class CreateRoleHandler : IRequestHandler<CreateRoleRequest, CreateRoleResponse>
    {
        private readonly RoleManager<AppRole> _roleManager;

        public CreateRoleHandler(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<CreateRoleResponse> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
        {
            AppRole role = await _roleManager.Roles.Where(p => p.Code == request.Code).FirstOrDefaultAsync();
            if (role != null) throw new Exception("Bu rol daha önce kayıt edilmiş! ");

            role = new AppRole
            {
                Id = Guid.NewGuid().ToString(),
                Code = request.Code,
                Name = request.Name,
            };

            await _roleManager.CreateAsync(role);
            return new();
        }
    }
}
