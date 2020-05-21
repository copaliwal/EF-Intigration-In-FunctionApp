using System;
using System.Linq;
using System.Threading.Tasks;
using FunctionAppEF.EntityFramework.EntityFramework;
using FunctionAppEF.EntityFramework.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace FunctionAppEF.EntityFramework
{
    public interface IOrganizationRepository
    {
        Task<string> GetOrganisationConnection();
    }

    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly MasterContext _masterContext;

        public OrganizationRepository(
            MasterContext masterContext)
        {
            _masterContext = masterContext;
        }

        public async Task<string> GetOrganisationConnection()
        {
            string name = "CP001";
            var organization = await _masterContext.MasterOrganizations
                .Where(o => o.Name == name)
                .FirstOrDefaultAsync();

            if (organization == null)
                return $"There is no organization with tenant key {name}";

            return organization.Connections;
        }
    }
}
