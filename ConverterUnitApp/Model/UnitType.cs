using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterUnitApp.Model
{
    internal class UnitType
    {
        public UnitType(string name, string description)
        {
            Name = name;
            Description = description;
            Units = new List<Unit>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Unit> Units { get; set; }
    }
}
