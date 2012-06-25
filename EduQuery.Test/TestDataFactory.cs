using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EduQuery.Test.Model;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace EduQuery.Test
{
    [SetUpFixture]
    public class TestDataFactory
    {
        [SetUp]
        public void CreateDatabaseIfNotExists()
        {
            if (File.Exists("testdb.db"))
                return;

            Configuration cfg;
            var sessionFactory = NHibernateBase.CreateSessionFactory(out cfg);
            var exporter = new SchemaExport(cfg);
            exporter.Execute(true, true, false);

            using(var session = sessionFactory.OpenSession())
            {
                CreateTestData(session);
            }
        }

        private void CreateTestData(ISession session)
        {
            for(int i = 1; i <= 10; i++)
            {
                var order = CreateOrder(i);
                var product = CreateProduct(i);

                session.Save(order);
                session.Save(product);

                for(int j = 1; j <= i; j++)
                {
                    var orderDetail = CreateOrderDetail(i, j);
                    session.Save(orderDetail);
                }
            }
        }

        private Order CreateOrder(int id)
        {
            return new Order
            {
                Id = id,
                CreatedDate = new DateTime(2012, 6, id, 12, 30, 31),
                CustomerName = "Order #" + id
            };
        } 

        private Product CreateProduct(int id)
        {
            return new Product
            {
                Sku = "SKUYOU" + id,
                Description = "Sample Product #" + id
            };
        }

        private OrderDetail CreateOrderDetail(int orderId, int id)
        {
            return new OrderDetail
            {
                Id = orderId * 1000 + id,
                OrderId = orderId,
                Price = id * orderId,
                Quantity = id,
                Sku = "SKUYOU" + id
            };
        }
    }
}
