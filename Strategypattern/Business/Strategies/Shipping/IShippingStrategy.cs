using Strategypattern.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategypattern.Business.Strategies.Shipping
{
    public interface IShippingStrategy
    {
        public void ShipOrder(Order order);
    }
}
