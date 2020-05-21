using FunctionAppEF.EntityFramework.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace FunctionAppEF.EntityFramework.EntityFramework
{
    public class MasterContext : DbContext
    {
        public MasterContext(DbContextOptions<MasterContext> options) : base(options)
        {

        }

        public DbSet<MasterOrganization> MasterOrganizations { get; set; }
    }
}
