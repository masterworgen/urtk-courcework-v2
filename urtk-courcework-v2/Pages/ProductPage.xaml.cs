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

namespace urtk_courcework_v2.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        List<ProductModel> Inf = new List<ProductModel>();

        public ProductPage()
        {
            InitializeComponent();
            Inf = FullModel();
            InsertListBox();
        }

        public List<ProductModel> FullModel()
        {
            using (var db = new groceryContext())
            {
                return db.Product.Select(domain => new ProductModel
                {
                    IdProduct = domain.IdProduct,
                    CountProduct = domain.CountProduct,
                    NameProduct = db.Dictionary.FirstOrDefault(dictionaryDomain => dictionaryDomain.IdDictionary == domain.IdDictionary).NameDictionary,
                    PriceProduct = domain.Price,
                    RestProduct = domain.RestProduct,
                    ShelfLifeProduct = domain.ShelfLifeProduct
                }).ToList();
            }
        }

        public void InsertListBox()
        {
            database.ItemsSource = Inf;
            database.FontSize = 20;
            database.DisplayMemberPath = "NameProduct";
            database.SelectedValuePath = "IdProduct";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Denomintation_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Database_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listItem = (ListBox)sender;
            var item = (ProductModel)listItem.SelectedItem;
            if (item == null) return;
            name.Text = item.NameProduct;
            shelfLife.Text = item.ShelfLifeProduct.ToString();
            count.Text = item.CountProduct.ToString();
            rest.Text = item.RestProduct.ToString();
            price.Text = item.PriceProduct.ToString();
        }
    }
}
