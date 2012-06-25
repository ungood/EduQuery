using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EduQuery.Query;
using EduQuery.Test.Model;
using NSubstitute;
using NUnit.Framework;

namespace EduQuery.Test.SQLiteDialect
{
    [TestFixture]
    public class EmptyTests
    {
        [Test]
        public void EmptyOrderTest()
        {
            var dialect = new Dialect.SQLiteDialect();
            var command = Substitute.For<IDbCommand>();

            dialect.ConfigureCommand(command, new SqlQuery<Order>());
            Assert.AreEqual(command.CommandText, "SELECT [Id], [CreatedDate], [CustomerName] FROM [Order]");
        }

        [Test]
        public void EmptyOrderDetailTest()
        {
            var dialect = new Dialect.SQLiteDialect();
            var command = Substitute.For<IDbCommand>();

            dialect.ConfigureCommand(command, new SqlQuery<OrderDetail>());
            Assert.AreEqual(command.CommandText, "SELECT [Id], [OrderId], [Sku], [Quantity], [Price] FROM [OrderDetail]");
        }

        [Test]
        public void EmptyProductTest()
        {
            var dialect = new Dialect.SQLiteDialect();
            var command = Substitute.For<IDbCommand>();

            dialect.ConfigureCommand(command, new SqlQuery<Product>());
            Assert.AreEqual(command.CommandText, "SELECT [Sku], [Description] FROM [Product]");
        }
    }
}
