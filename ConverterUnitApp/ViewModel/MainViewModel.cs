using ConverterUnitApp.Model;
using ConverterUnitApp.Services;
using ConverterUnitApp.Utils;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ConverterUnitApp.ViewModel
{
    internal class MainViewModel: INotifyPropertyChanged
    {
        private MainService _mainService;
        private ObservableCollection<UnitType>? _unitTypes;
        private ObservableCollection<Unit>? _units;

        private UnitType? _selectedUnitType;
        private string _textFirstUnit;
        private Unit? _selectedFirstUnit;
        private string _textSecondUnit;
        private Unit? _selectedSecondUnit;

        private RelayCommand _calculateCommand;
        private RelayCommand _changeUnitsCommand;
        private RelayCommand _copyCommand;

        public ObservableCollection<UnitType>? UnitTypes
        {
            get { return _unitTypes; }
            set
            {
                _unitTypes = value;
                OnPropertyChanged(nameof(UnitTypes));
            }
        }

        public ObservableCollection<Unit>? Units
        {
            get { return _units; }
            set
            {
                _units = value;
                OnPropertyChanged(nameof(Units));
            }
        }

        public UnitType? SelectedUnitType
        {
            get { return _selectedUnitType; }
            set
            {
                _selectedUnitType = value;
                LoadUnits();
                OnPropertyChanged(nameof(SelectedUnitType));
            }
        }

        public string TextFirstUnit
        {
            get { return _textFirstUnit; }
            set
            {
                _textFirstUnit = value;
                OnPropertyChanged(nameof(TextFirstUnit));
            }
        }

        public Unit? SelectedFirstUnit
        {
            get { return _selectedFirstUnit; }
            set
            {
                _selectedFirstUnit = value;
                OnPropertyChanged(nameof(SelectedFirstUnit));
            }
        }

        public string TextSecondUnit
        {
            get { return _textSecondUnit; }
            set
            {
                _textSecondUnit = value;
                OnPropertyChanged(nameof(TextSecondUnit));
            }
        }

        public Unit? SelectedSecondUnit
        {
            get { return _selectedSecondUnit; }
            set
            {
                _selectedSecondUnit = value;
                OnPropertyChanged(nameof(SelectedSecondUnit));
            }
        }

        public RelayCommand CalculateCommand
        {
            get => _calculateCommand ?? new RelayCommand((obj) =>
            {
                string str = obj as string ?? "";
                TextSecondUnit = GetValue(SelectedFirstUnit, SelectedSecondUnit, str);
            });
        }
        public RelayCommand ChangeUnitsCommand
        {
            get => _changeUnitsCommand ?? new RelayCommand((obj) =>
            {
                var tempField = TextFirstUnit;
                TextFirstUnit = TextSecondUnit;
                TextSecondUnit = tempField;

                var tempUnit = SelectedFirstUnit;
                SelectedFirstUnit = SelectedSecondUnit;
                SelectedSecondUnit = tempUnit;

                TextSecondUnit = GetValue(SelectedFirstUnit, SelectedSecondUnit, TextFirstUnit);
            });
        }
        public RelayCommand CopyCommand
        {
            get => _copyCommand ?? new RelayCommand((obj) =>
            {
                string str = obj as string ?? "";
                Clipboard.SetText(str);
            });
        }

        private string GetValue(Unit? from, Unit? to, string value)
        {
            if (from != null && to != null)
            {
                decimal number = decimal.Parse(value);
                return _mainService.GetFactorValue(from, to, number).ToString();
            }
            return value;
        } 

        private void LoadUnits()
        {
            if (SelectedUnitType != null) {

                Units = new ObservableCollection<Unit>(SelectedUnitType.Units);
                SelectedFirstUnit = Units[0];
                SelectedSecondUnit = Units[0];
            }
        }

        public MainViewModel()
        {
            _mainService = new MainService();
            UnitTypes = new ObservableCollection<UnitType>(_mainService.UnitTypes);
            SelectedUnitType = UnitTypes[0];
            _textFirstUnit = "0";
            _textSecondUnit = "0";
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
