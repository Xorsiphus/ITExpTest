using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities.Impl;

namespace Server.Infrastructure.Dal.Contexts
{
    public class ServerAppContext : DbContext
    {
        public DbSet<MyObject> MyObjects { get; set; }

        public ServerAppContext(DbContextOptions<ServerAppContext> options) : base(options)
        {
        }
    }
}