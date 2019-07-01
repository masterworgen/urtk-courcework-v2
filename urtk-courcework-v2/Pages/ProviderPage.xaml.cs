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
using urtk_courcework_v2.Model;
using urtk_courcework_v2.Windows;

namespace urtk_courcework_v2.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProviderPage.xaml
    /// </summary>
    public partial class ProviderPage : Page
    {
        public List<ProviderModel> Inf;

        public ProviderPage()
        {
            InitializeComponent();
            Inf = FullModel();
            InsertListBox();
        }

        public List<ProviderModel> FullModel()
        {
            using (var db = new groceryContext())
            {
                return db.Provider.Select(domain => new ProviderModel
                {
                    IdProvider = domain.IdProvider,
                    DenomintaionProvider = domain.DenomintaionProvider,
                    NameProvider = domain.NameProvider,
                    SurnameProvider = domain.SurnameProvider,
                    PatronymicProvider = domain.PatronymicProvider,
                    CityProvider = domain.CityProvider,
                    FaxProvider = domain.FaxProvider,
                    PhoneProvider = domain.PhoneProvider
                }).ToList();
            }
        }

        public void InsertListBox()
        {
            database.ItemsSource = Inf;
            database.FontSize = 20;
            database.DisplayMemberPath = "DenomintaionProvider";
            database.SelectedValuePath = "IdProvider";
        }

        public void Refresh()
        {
            Inf = FullModel();
            InsertListBox();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addProvider = new AddProviderWindow();
            addProvider.Show();
            addProvider.addProvider += Refresh;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (database.SelectedValue != null)
            {
                var item = int.Parse(database.SelectedValue.ToString());
                var deleteProvider= new DeleteProviderWindow(item);
                deleteProvider.Show();
                deleteProvider.deleteProvider += Refresh;
            }
        }

        private void Database_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listItem = (ListBox) sender;
            var item = (ProviderModel)listItem.SelectedItem;
            if (item == null) return;
            denomintation.Text = item.DenomintaionProvider;
            name.Text = item.NameProvider;
            surname.Text = item.SurnameProvider;
            patronymic.Text = item.PatronymicProvider;
            phone.Text = item.PhoneProvider;
            fax.Text = item.FaxProvider;
            city.Text = item.CityProvider;
        }

        private void Denomintation_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox) sender;
            var selected = (ProviderModel)database.SelectedItem;
            using (var db = new groceryContext())
            {
                var provider = db.Provider.FirstOrDefault(domain => selected.IdProvider == domain.IdProvider);
                switch (textBox.Name)
                {
                    case "denomintation":
                        provider.DenomintaionProvider = textBox.Text;
                        break;
                    case "name":
                        provider.NameProvider = textBox.Text;
                        break;
                    case "surname":
                        provider.SurnameProvider = textBox.Text;
                        break;
                    case "patronymic":
                        provider.PatronymicProvider = textBox.Text;
                        break;
                    case "phone":
                        provider.PhoneProvider = textBox.Text;
                        break;
                    case "fax":
                        provider.FaxProvider = textBox.Text;
                        break;
                    case "city":
                        provider.CityProvider = textBox.Text;
                        break;
                }

                db.SaveChanges();
            }

        }
    }
}
