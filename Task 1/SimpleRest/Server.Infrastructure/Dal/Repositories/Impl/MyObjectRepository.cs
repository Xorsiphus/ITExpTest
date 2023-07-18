using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities.Impl;
using Server.Domain.Interfaces;
using Server.Infrastructure.Dal.Contexts;

namespace Server.Infrastructure.Dal.Repositories.Impl
{
    public class MyObjectRepository : BaseRepository<MyObject>, IMyObjectsRepository
    {
        public MyObjectRepository(ServerAppContext context) : base(context)
        {
        }

        public async Task ClearTable()
        {
            await InTransaction(() => Context.MyObjects.RemoveRange(Context.MyObjects));
            await Context.Database.ExecuteSqlRawAsync("ALTER SEQUENCE \"MyObjects_Id_seq\" RESTART WITH 1");
        }
    }
}