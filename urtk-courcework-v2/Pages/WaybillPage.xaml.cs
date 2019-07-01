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
    /// Логика взаимодействия для WaybillPage.xaml
    /// </summary>
    public partial class WaybillPage : Page
    {
        List<WaybillModel> Inf = new List<WaybillModel>();
        public WaybillPage()
        {
            InitializeComponent();
            Inf = FullModel();
            InsertListBox();
        }
        public List<WaybillModel> FullModel()
        {
            using (var db = new groceryContext())
            {
                return db.Waybill.Select(domain => new WaybillModel
                {
                    IdWaybill = domain.IdWaybill,
                    NameProvider = db.Provider.FirstOrDefault(providerDomain => providerDomain.IdProvider == domain.IdProvider).NameProvider,
                    DateWaybill = domain.IdData,
                    ProductModels = domain.Product.Select(productDomain => new ProductModel
                    {
                        NameProduct = db.Dictionary.FirstOrDefault(dictionaryDomain => dictionaryDomain.IdDictionary == productDomain.IdDictionary).NameDictionary
                    }).ToList()
                }).ToList();
            }
        }

        public void InsertListBox()
        {
            database.ItemsSource = Inf;
            database.FontSize = 20;
            database.DisplayMemberPath = "IdWaybill";
            database.SelectedValuePath = "IdWaybill";
        }

        private void Database_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listItem = (ListBox)sender;
            var item = (WaybillModel)listItem.SelectedItem;
            if (item == null) return;
            provider.Text = item.NameProvider;
            date.Text = item.DateWaybill.ToString();
            var text = "";
            foreach (var itemProductModel in item.ProductModels)
            {
                text += itemProductModel.NameProduct + " ";
            }
            products.Text = text;
        }

        private void Denomintation_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        public void Refresh()
        {
            Inf = FullModel();
            InsertListBox();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addWaybill = new AddWaybillWindow();
            addWaybill.Show();
            addWaybill.addWaybill += Refresh;
        }
    }
}
