using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using urtk_courcework_v2.Pages;

namespace urtk_courcework_v2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            switch (button.Content.ToString())
            {
                case "Словарь":
                    frame.Navigate(new DictionaryPage());
                    break;
                case "Накладные":
                    frame.Navigate(new WaybillPage());
                    break;
                case "Поставщики":
                    frame.Navigate(new ProviderPage());
                    break;
                case "Продукты":
                    frame.Navigate(new ProductPage());
                    break;
                case "Продажа":
                    frame.Navigate(new SellPage());
                    break;
            }
        }
    }
}
 