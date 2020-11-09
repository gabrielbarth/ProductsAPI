using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Estudos.Repositorio.ConfiguracaoHibernate
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly ISession _session;
        private ITransaction _transaction;
        private bool _isAlive = true;
        private bool _isCommitted;

        public UnityOfWork(SessionFactory sessionFactory)
        {
            _session = sessionFactory.OpenSession();
        }

        public async Task Commit(CancellationToken cancellationToken)
        {
            if (!_isAlive)
            {
                await Task.CompletedTask;
                return;
            }
            if (_isCommitted)
                return;
            await _transaction.CommitAsync(cancellationToken);
            _isCommitted = true;
        }

        public async Task Delete<T>(T entity, CancellationToken cancellationToken)
        {
            if (!_isAlive)
            {
                await Task.CompletedTask;
                return;
            }
            await _session.DeleteAsync(entity, cancellationToken);
        }

        // 
        public void Dispose()
        {
            if (!_isAlive)
                return;
            _isAlive = false;
            try
            {
                if (!_isCommitted)
                {
                    if (_transaction != null)
                        _transaction.Rollback();
                }
            }
            finally
            {
                if (_transaction != null)
                    _transaction.Dispose();
                _session.Dispose();
            }
        }

        public async Task<IQueryable<T>> Query<T>()
        {
            return await Task.FromResult(_session.Query<T>());
        }

        public async Task SaveOrUpdate<T>(T entity, CancellationToken cancellationToken)
        {
            await _session.SaveOrUpdateAsync(entity, cancellationToken);
        }

        public async Task UseTransaction(IsolationLevel isolationLevel)
        {
            _transaction = _session.BeginTransaction(isolationLevel);
            _isCommitted = false;
            await Task.CompletedTask;
        }
    }
}
