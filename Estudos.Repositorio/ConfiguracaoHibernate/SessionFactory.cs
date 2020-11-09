using Estudos.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using NHibernate.Connection;
using NHibernate.Driver;
using NHibernate.Dialect;
using System.Data;
using System.Reflection;

namespace Estudos.Repositorio.ConfiguracaoHibernate
{

    public class SessionFactory
    {
        private ISessionFactory _sessionFactory;

        private readonly ConexaoDB _conexao;
        public SessionFactory(ConexaoDB conexao)
        {
            _conexao = conexao;
            _sessionFactory = BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }

        private ISessionFactory BuildSessionFactory()
        {
            var configuration = new Configuration();
            configuration.DataBaseIntegration(db =>
            {
                db.ConnectionString = _conexao.ConexaoString;
                db.ConnectionProvider<DriverConnectionProvider>();
                db.Driver<SqlClientDriver>();
                db.Dialect<MsSql2012Dialect>();
                db.BatchSize = 100;
                db.IsolationLevel = IsolationLevel.ReadCommitted;
                db.LogSqlInConsole = _conexao.ExibeSql;
                if (_conexao.ExibeSql)
                    db.LogFormattedSql = true;
            });
            var fluentlyConfiguration = Fluently.Configure(configuration);
            fluentlyConfiguration.Mappings(x =>
               x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())
            );
            return fluentlyConfiguration.BuildSessionFactory();
        }

    }
}
