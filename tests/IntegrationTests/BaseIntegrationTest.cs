using Api.Interfaces;
using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests
{
    public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>
    {
        private readonly IServiceScope _scope;
        protected readonly ISecurityService _securityService;

        protected readonly ApplicationDbContext DbContext;

        protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
        {
            _scope = factory.Services.CreateScope();

            _securityService = _scope.ServiceProvider.GetRequiredService<ISecurityService>();
            DbContext = _scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        }
    }
}