using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterUnitApp.Model
{
    internal class Unit
    {
        public Unit(string name, string symbol, decimal factor)
        {
            Name = name;
            Symbol = symbol;
            Factor = factor;
        }

        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal Factor { get; set; }
    }
}
