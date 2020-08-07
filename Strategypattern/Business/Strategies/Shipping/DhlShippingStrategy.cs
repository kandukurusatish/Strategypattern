using Strategypattern.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategypattern.Business.Strategies.Shipping
{
    public class DhlShippingStrategy : IShippingStrategy
    {
        public void ShipOrder(Order order)
        {
            Console.WriteLine("Order Shipped in DHL");
        }
    }
}
