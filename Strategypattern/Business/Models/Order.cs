﻿using Strategypattern.Business.Strategies.Invoice;
using Strategypattern.Business.Strategies.SalesTax;
using Strategypattern.Business.Strategies.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Strategypattern.Business.Models
{
    public class Order
    {
        public Dictionary<Item, int> LineItems { get; } = new Dictionary<Item, int>();
        public IList<Payment> SelectedPayments { get; } = new List<Payment>();
        public IList<Payment> FinalizedPayments { get; } = new List<Payment>();
        public decimal AmountDue => TotalPrice - FinalizedPayments.Sum(payment => payment.Amount);
        public decimal TotalPrice => LineItems.Sum(item => item.Key.Price * item.Value);
        public ShippingStatus ShippingStatus { get; set; } = ShippingStatus.WaitingForPayment;
        public ShippingDetails ShippingDetails { get; set; }

        public ISalesStrategy SalesStrategy { get; set; }

        public IInvoiceStrategy InvoiceStrategy { get; set; }

        public IShippingStrategy ShippingStrategy { get; set; }

        public decimal GetTax(ISalesStrategy salesStrategy = default)
        {
            //var destination = ShippingDetails.DestinationCountry.ToLowerInvariant();
            //if (destination == "sweeden")
            //{
            //    if (destination == ShippingDetails.OriginCountry.ToLowerInvariant())
            //    {
            //        return TotalPrice * 0.25m;
            //    }
            //    return 0;
            //}
            //if (destination == "us")
            //{
            //    switch (ShippingDetails.DestinationState.ToLowerInvariant())
            //    {
            //        case "la": return TotalPrice * 0.095m;
            //        case "ny": return TotalPrice * 0.04m;
            //        case "nyc": return TotalPrice * 0.045m;
            //        default:
            //            return 0m;
            //    }
            //}
            //return 0m;

            var strategy = salesStrategy ?? SalesStrategy;

            if (strategy == null)
            {
                return 0m;
            }
            return strategy.GetTax(this);
        }

        public void FinalizeOrder()
        {
            // Business Conditions here...
            InvoiceStrategy.Generate(this);

            ShippingStrategy.ShipOrder(this);
        }
    }
}
