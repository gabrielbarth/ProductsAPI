using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Estudos.Repositorio.ConfiguracaoHibernate
{
    public interface IUnityOfWork : IDisposable
    {
        Task UseTransaction(IsolationLevel isolationLevel);
        Task Commit(CancellationToken cancellationToken);
        Task SaveOrUpdate<T>(T entity, CancellationToken cancellationToken);
        Task Delete<T>(T entity, CancellationToken cancellationToken);
       Task<IQueryable<T>> Query<T>();

    }
}
