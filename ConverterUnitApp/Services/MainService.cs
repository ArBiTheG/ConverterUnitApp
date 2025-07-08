using ConverterUnitApp.Model;
using System.Data;
using System.Diagnostics;

namespace ConverterUnitApp.Services
{
    internal class MainService
    {
        private List<UnitType> _unitTypes;

        public MainService()
        {
            _unitTypes = new List<UnitType>();

            InitBaseConversion();
        }

        public List<UnitType> UnitTypes { get { return _unitTypes; } }

        public decimal GetFactorValue(Unit from, Unit to, decimal value)
        {
            return (value * from.Factor) / to.Factor;
        }

        private void InitBaseConversion()
        {
            var length = CreateType("Длина");
            var mm = CreateUnit(length, "Милиметр", "мм", 0.001m);
            var cm = CreateUnit(length, "Сантиметр", "см", 0.01m);
            var inch = CreateUnit(length, "Дюйм", "\"", 0.0254m);
            var ft = CreateUnit(length, "Фут", "фт", 0.3048m);
            var m  = CreateUnit(length, "Метр", "м", 1);
            var km = CreateUnit(length, "Километр", "км", 1000);
        }

        private Unit CreateUnit(UnitType type, string name, string symbol = "", decimal factor = 1)
        {
            Unit unit = new Unit(name, symbol, factor);
            type.Units.Add(unit);
            return unit;
        }
        private UnitType CreateType(string name)
        {
            UnitType type = new UnitType(name);

            _unitTypes.Add(type);
            return type;
        }

    }
}
