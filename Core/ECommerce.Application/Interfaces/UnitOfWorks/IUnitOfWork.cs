using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepository<T> GetReadRepostory<T>() where T : class, IEntityBase, new();
        IWriteRepository<T> GetWriteRepostory<T>() where T : class, IEntityBase, new();
        Task<int> SaveAsync();
        int Save();

    }
}
