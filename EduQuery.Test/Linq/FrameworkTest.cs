using System;
using System.Collections.Generic;
using System.Linq;
using EduQuery.Test.Model;
using NUnit.Framework;

namespace EduQuery.Test.Linq
{
    [TestFixture]
    public class FrameworkTest : NHibernateBase
    {
        [Test]
        public void DisplayAllEntities()
        {
            var products = Query<Product>().ToList();
            var orders = Query<Order>().ToList();
            var orderDetails = Query<OrderDetail>().ToLookup(od => od.OrderId);

            foreach(var product in products)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine();
            Console.WriteLine();
            
            foreach(var order in orders)
            {
                Console.WriteLine(order);
                foreach(var orderDetail in orderDetails[order.Id])
                    Console.WriteLine(orderDetail);
                Console.WriteLine();
            }
        }
    }
}
