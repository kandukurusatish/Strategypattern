using Strategypattern.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategypattern.Business.Strategies.SalesTax
{
    public interface ISalesStrategy
    {
        decimal GetTax(Order order);
    }
}
