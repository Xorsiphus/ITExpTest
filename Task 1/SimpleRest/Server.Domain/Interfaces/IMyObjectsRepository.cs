using System.Threading.Tasks;
using Server.Domain.Entities.Impl;

namespace Server.Domain.Interfaces
{
    public interface IMyObjectsRepository : IBaseRepository<MyObject>
    {
        Task ClearTable();
    }
}