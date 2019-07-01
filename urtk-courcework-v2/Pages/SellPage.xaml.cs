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
using Microsoft.EntityFrameworkCore;
using urtk_courcework_v2.Model;
using urtk_courcework_v2.Windows;

namespace urtk_courcework_v2.Pages
{
    /// <summary>
    /// Логика взаимодействия для SellPage.xaml
    /// </summary>
    public partial class SellPage : Page
    {
        List<SaleModel> Inf = new List<SaleModel>();

        public SellPage()
        {
            InitializeComponent();
            Inf = FullModel();
            InsertListBox();
        }
        public List<SaleModel> FullModel()
        {
            using (var db = new groceryContext())
            {
                var sales = db.Sale
                    .Include(t => t.IdProductNavigation)
                    .ThenInclude(p => p.IdDictionaryNavigation).ToList();
                return sales.Select(domain => new SaleModel
                {
                    IdSale = domain.IdSale,
                    CountSale = domain.CountSale,
                    DateSale = domain.DataSale,
                    Product = domain.IdProductNavigation
                }).ToList();
            }
        }

        public void InsertListBox()
        {
            database.ItemsSource = Inf;
            database.FontSize = 20;
            database.DisplayMemberPath = "IdSale";
            database.SelectedValuePath = "IdSale";
        }

        public void Refresh()
        {
            Inf = FullModel();
            InsertListBox();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var sellWindow = new SellProductWindow();
            sellWindow.Show();
            sellWindow.sellProduct += Refresh;
        }

        private void Database_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listItem = (ListBox)sender;
            var item = (SaleModel)listItem.SelectedItem;
            if (item == null) return;
            name.Text = item.Product.IdDictionaryNavigation.NameDictionary;
            count.Text = item.CountSale.ToString();
            price.Text = item.Product.Price.ToString();
            fullPrice.Text = (item.Product.Price * item.CountSale).ToString();
        }
    }
}
