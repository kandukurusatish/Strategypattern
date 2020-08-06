using Strategypattern.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategypattern.Business.Strategies.SalesTax
{
    public class SweedenSalesTaxStrategy : ISalesStrategy
    {
        public decimal GetTax(Order order)
        {
            if (order.ShippingDetails.DestinationCountry.ToLowerInvariant() == order.ShippingDetails.OriginCountry.ToLowerInvariant())
            {
                return order.TotalPrice * 0.25m;
            }
            return 0;
        }
    }
}
