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

            InitLengthConversion();
            InitMassConversion();
            InitTempConversion();
        }

        public List<UnitType> UnitTypes { get { return _unitTypes; } }

        public decimal GetFactorValue(Unit from, Unit to, decimal value)
        {
            return (value * from.Factor) / to.Factor;
        }

        private void InitLengthConversion()
        {
            var length = CreateType("Длина", "Физическая величина, характеризующая протяжённость объекта или расстояние между двумя точками в пространстве.");
            var mm = CreateUnit(length, "Милиметр", "мм", 0.001m);
            var cm = CreateUnit(length, "Сантиметр", "см", 0.01m);
            var inch = CreateUnit(length, "Дюйм", "\"", 0.0254m);
            var ft = CreateUnit(length, "Фут", "фт", 0.3048m);
            var m = CreateUnit(length, "Метр", "м", 1);
            var km = CreateUnit(length, "Километр", "км", 1000);
        }
        private void InitMassConversion()
        {
            var mass = CreateType("Масса", "Физическая величина, которая показывает, какое количество вещества содержится в теле");
            var mg = CreateUnit(mass, "Миллиграмм", "мг", 0.000001m);
            var g = CreateUnit(mass, "Грамм", "г", 0.001m);
            var u = CreateUnit(mass, "Унции", "фт", 0.02835m);
            var f = CreateUnit(mass, "Фунты", "фт", 0.4095m);
            var kg = CreateUnit(mass, "Килограмм", "кг", 1);
            var t = CreateUnit(mass, "Тонна", "т", 1000);
        }
        private void InitTempConversion()
        {
            var temp = CreateType("Объём", "Физическая величина, которая показывает, какое пространство (какую часть пространства) занимает тело или вещество.");
            var ml = CreateUnit(temp, "Миллилитр", "л", 0.000001m);
            var l = CreateUnit(temp, "Литр", "л", 0.001m);
            var g = CreateUnit(temp, "Галлон", "гл", 0.00454609m);
            var m = CreateUnit(temp, "Кубический метр", "m3", 1);
        }

        private Unit CreateUnit(UnitType type, string name, string symbol = "", decimal factor = 1)
        {
            Unit unit = new Unit(name, symbol, factor);
            type.Units.Add(unit);
            return unit;
        }
        private UnitType CreateType(string name, string description)
        {
            UnitType type = new UnitType(name, description);

            _unitTypes.Add(type);
            return type;
        }

    }
}
