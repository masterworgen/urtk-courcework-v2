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
using urtk_courcework_v2.Model;

namespace urtk_courcework_v2.Windows
{
    /// <summary>
    /// Логика взаимодействия для SellProductWindow.xaml
    /// </summary>
    public partial class SellProductWindow : Window
    {
        public delegate void SellProduct();

        public event SellProduct sellProduct;

        public List<ProductModel> Products = new List<ProductModel>();

        public SellProductWindow()
        {
            InitializeComponent();
            Products = FullProducts();
            InsertListBox();
        }
        public List<ProductModel> FullProducts()
        {
            using (var db = new groceryContext())
            {
                return db.Product.Select(domain => new ProductModel
                {
                    NameProduct = db.Dictionary.FirstOrDefault(dictionaryDomain => dictionaryDomain.IdDictionary == domain.IdDictionary).NameDictionary,
                    IdProduct = domain.IdProduct
                }).ToList();
            }
        }

        public void InsertListBox()
        {
            products.ItemsSource = Products;
            products.DisplayMemberPath = "NameProduct";
            products.SelectedValuePath = "IdProduct";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new groceryContext())
            {
                var sell = new SaleDomain
                {
                    IdProductNavigation = db.Product.FirstOrDefault(domain => domain.IdProduct == int.Parse(products.SelectedValue.ToString())),
                    IdProduct = int.Parse(products.SelectedValue.ToString()),
                    DataSale = DateTime.Now,
                    CountSale = int.Parse(count.Text)
                };
                var product = db.Product.FirstOrDefault(domain =>
                    domain.IdProduct == int.Parse(products.SelectedValue.ToString()));

                product.RestProduct -= int.Parse(count.Text);

                db.Sale.Add(sell);

                db.SaveChanges();

                sellProduct?.Invoke();
                this.Close();
            }
        }
    }
}
