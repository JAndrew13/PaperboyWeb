using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paperboy.Api.Interfaces
{
    public interface IExchange
    {
        decimal GetPrice(string symbol);
    }
}