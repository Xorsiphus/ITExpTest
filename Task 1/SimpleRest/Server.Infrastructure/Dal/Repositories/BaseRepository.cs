using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Domain.Interfaces;
using Server.Infrastructure.Dal.Contexts;

namespace Server.Infrastructure.Dal.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity, new()
    {
        protected readonly ServerAppContext Context;

        public BaseRepository(ServerAppContext context)
        {
            Context = context;
        }

        public async Task Save(T entity)
            => await InTransaction(() => Context.Set<T>().AddAsync(entity).AsTask());


        public async Task SaveAll(IEnumerable<T> entities)
        {
            var transaction = await Context.Database.BeginTransactionAsync();
            try
            {
                foreach (var entity in entities)
                {
                    await Context.Set<T>().AddAsync(entity);
                }

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }

            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> Query(int take, int offset)
        {
            return await Context.Set<T>()
                .AsQueryable()
                .OrderBy(e => e.Id)
                .Skip(offset)
                .Take(take)
                .ToListAsync();
        }

        public async Task<int> GetCount(Expression<Func<T, bool>> condition)
            => await Context.Set<T>()
                .Where(condition)
                .CountAsync();

        protected async Task InTransaction(Func<Task> func)
        {
            var transaction = await Context.Database.BeginTransactionAsync();
            try
            {
                await func();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }

            await Context.SaveChangesAsync();
        }

        protected async Task InTransaction(Action func)
        {
            var transaction = await Context.Database.BeginTransactionAsync();
            try
            {
                func();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }

            await Context.SaveChangesAsync();
        }
    }
}