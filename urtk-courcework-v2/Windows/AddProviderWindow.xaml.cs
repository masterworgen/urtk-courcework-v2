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
using System.Windows.Shapes;
using urtk_courcework_v2.Domain;

namespace urtk_courcework_v2.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddProviderWindow.xaml
    /// </summary>
    public partial class AddProviderWindow : Window
    {
        public delegate void AddProvider();

        public event AddProvider addProvider;

        public AddProviderWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new groceryContext())
            {
                db.Provider.Add(new ProviderDomain
                {
                    PatronymicProvider = patronymic.Text,
                    DenomintaionProvider = denomintation.Text,
                    CityProvider = city.Text,
                    FaxProvider = fax.Text,
                    NameProvider = name.Text,
                    PhoneProvider = phone.Text,
                    SurnameProvider = surname.Text
                });
                db.SaveChanges();
            }

            addProvider?.Invoke();
            this.Close();
        }
    }
}
