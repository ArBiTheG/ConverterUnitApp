using ConverterUnitApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConverterUnitApp.View
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        MainViewModel _viewModel = new MainViewModel();

        public MainView()
        {
            InitializeComponent();
            DataContext = _viewModel;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox? textBox = sender as TextBox;
            if (textBox != null) 
            {
                if (!(char.IsDigit(e.Text, 0) || (e.Text == ".") && (!textBox.Text.Contains(".") && textBox.Text.Length != 0)))
                {
                    e.Handled = true;
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox? textBox = sender as TextBox;
            if (textBox != null) {
                if (textBox.Text == "")
                {
                    textBox.Text = "0";
                }
            }
        }
    }
}
