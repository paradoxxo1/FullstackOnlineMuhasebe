
using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain;
using OnlineMuhasebeServer.Domain.Repositories.UCAFRepositories;
using OnlineMuhasebeServer.Persistance;
using OnlineMuhasebeServer.Persistance.Repositories.UCAFRepositories;
using OnlineMuhasebeServer.Persistance.Services.AppServices;
using OnlineMuhasebeServer.Persistance.Services.CompanyServices;

namespace OnlineMuhasebeServer.WebApi.Configurations
{
    public class PersistanceDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            #region Context UnitIOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IContextService, ContextService>();
            #endregion


            #region Services
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IUCAFService, UCAFService>();
            #endregion


            #region Repositories
            services.AddScoped<IUCAFCommandRepository, UCAFCommandRepository>();
            services.AddScoped<IUCAFQueryRepository, UCAFQueryRepository>();
            #endregion

        }
    }
}
