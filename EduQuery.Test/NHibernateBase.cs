using System;
using System.Collections.Generic;
using System.Linq;
using EduQuery.Model;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Mapping;
using NHibernate.Cfg;
using NUnit.Framework;
using SessionProperties = NHibernate.Cfg.Environment;

namespace EduQuery.Test
{
    

    public abstract class NHibernateBase
    {
        public static ISessionFactory CreateSessionFactory(out Configuration configuration)
        {
            Configuration tmpCfg = null;
            var sessionFactory = Fluently.Configure()
                .Database(() => SQLiteConfiguration.Standard.UsingFile("testdb.db"))
                .Mappings(m =>
                {
                    m.FluentMappings.Add<OrderMap>();
                    m.FluentMappings.Add<OrderDetailMap>();
                    m.FluentMappings.Add<ProductMap>();
                })
                .ExposeConfiguration(cfg =>
                {
                    cfg.SetProperty(SessionProperties.GenerateStatistics, "true");
                    cfg.SetProperty(SessionProperties.FormatSql, "true");
                    cfg.SetProperty(SessionProperties.ShowSql, "true");
                    tmpCfg = cfg;
                })
                .BuildSessionFactory();

            configuration = tmpCfg;
            return sessionFactory;
        }

        private ISessionFactory sessionFactory;
        private ISessionFactory SessionFactory
        {
            get
            {
                Configuration cfg;
                if (sessionFactory == null)
                    sessionFactory = CreateSessionFactory(out cfg);
                return sessionFactory;
            }
        }

        private ISession session;

        [SetUp]
        public void Setup()
        {
            session = SessionFactory.OpenSession();
        }

        protected IQueryable<T> Query<T>()
        {
            return session.Query<T>();
        }

        [TearDown]
        public void TearDown()
        {
            if (session != null && session.IsOpen)
                session.Close();
        }

        #region Mappings

        private class OrderMap : ClassMap<Order>
        {
            public OrderMap()
            {
                Not.LazyLoad();
                Id(x => x.Id);
                Map(x => x.CreatedDate);
                Map(x => x.CustomerName);
            }
        }

        private class OrderDetailMap : ClassMap<OrderDetail>
        {
            public OrderDetailMap()
            {
                Not.LazyLoad();
                Id(x => x.Id);
                Map(x => x.Price);
                Map(x => x.OrderId);
                Map(x => x.Sku);
                Map(x => x.Quantity);
            }
        }

        private class ProductMap : ClassMap<Product>
        {
            public ProductMap()
            {
                Not.LazyLoad();
                Id(x => x.Sku);
                Map(x => x.Description);
            }
        }

        #endregion
    }
}
