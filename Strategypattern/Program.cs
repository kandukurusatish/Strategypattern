using Strategypattern.Business.Models;
using Strategypattern.Business.Strategies.SalesTax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategypattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                ShippingDetails = new ShippingDetails
                {
                    OriginCountry = "Sweeden",
                    DestinationCountry = "Sweeden"
                },
                //SalesStrategy = new SweedenSalesTaxStrategy()

            };

            order.LineItems.Add(new Item("CSHARP", "C#", 100m, ItemType.Literature), 1);
            order.LineItems.Add(new Item("CONSULTING", "Building a Website", 100m, ItemType.Service), 1);
            Console.WriteLine(order.GetTax(new SweedenSalesTaxStrategy()));
        }
    }
}
