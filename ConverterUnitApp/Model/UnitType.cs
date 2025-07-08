using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterUnitApp.Model
{
    internal class UnitType
    {
        public UnitType(string name)
        {
            Name = name;
            Units = new List<Unit>();
        }

        public string Name { get; set; }
        public List<Unit> Units { get; set; }
    }
}
