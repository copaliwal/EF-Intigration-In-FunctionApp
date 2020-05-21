using System;
using FunctionAppEF.EntityFramework;
using FunctionAppEF.EntityFramework.EntityFramework;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(FunctionAppEF.Startup))]
namespace FunctionAppEF
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<MasterContext>(options => options
                .UseSqlServer(
                    "Data source=DESKTOP-00MSETD\\SQLDEV;Initial Catalog=AzureFuncDB;User id=sa;password=Pass@007",
                    sqlOptions => sqlOptions.EnableRetryOnFailure())
                .ConfigureWarnings(x => x.Throw(RelationalEventId.QueryClientEvaluationWarning))
                .EnableSensitiveDataLogging(true));

            builder.Services.AddScoped<OrganizationRepository>();

            builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>(sp => 
                new OrganizationRepository(sp.GetRequiredService<MasterContext>()));
        }
    }
}
