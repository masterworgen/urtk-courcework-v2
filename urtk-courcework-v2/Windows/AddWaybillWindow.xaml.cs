using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using urtk_courcework_v2.Domain;
using urtk_courcework_v2.Model;

namespace urtk_courcework_v2.Windows
{
    public partial class AddWaybillWindow : Window
    {
        public delegate void AddWaybill();

        public event AddWaybill addWaybill;

        public List<DictionaryModel> Products = new List<DictionaryModel>();

        public List<ProviderModel> Providers = new List<ProviderModel>();

        public AddWaybillWindow()
        {
            InitializeComponent();
            Products = FullProducts();
            Providers = FullProvider();
            InsertListBox();
        }

        public List<DictionaryModel> FullProducts()
        {
            using (var db = new groceryContext())
            {
                return db.Dictionary.Select(domain => new DictionaryModel
                {
                    NameDictionary = db.Dictionary
                        .FirstOrDefault(dictionaryDomain => dictionaryDomain.IdDictionary == domain.IdDictionary)
                        .NameDictionary,
                    IdDictionary = domain.IdDictionary
                }).ToList();
            }
        }

        public List<ProviderModel> FullProvider()
        {
            using (var db = new groceryContext())
            {
                return db.Provider.Select(domain => new ProviderModel
                {
                    NameProvider = domain.NameProvider,
                    IdProvider = domain.IdProvider
                }).ToList();
            }
        }
        public void InsertListBox()
        {
            products.ItemsSource = Products;
            products.DisplayMemberPath = "NameDictionary";
            products.SelectedValuePath = "IdDictionary";

            providers.ItemsSource = Providers;
            providers.DisplayMemberPath = "NameProvider";
            providers.SelectedValuePath = "IdProvider";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new groceryContext())
            {
                var product = (from DictionaryModel productsSelectedItem in products.SelectedItems
                select new ProductDomain
                {
                    IdDictionary = productsSelectedItem.IdDictionary,
                    RestProduct = int.Parse(count.Text),
                    CountProduct = int.Parse(count.Text),
                    ShelfLifeProduct = DateTime.Parse(date.Text),
                    IdDictionaryNavigation = db.Dictionary.FirstOrDefault(domain => domain.IdDictionary == productsSelectedItem.IdDictionary),
                    Price = decimal.Parse(price.Text)
                }).ToList();

                db.Product.AddRange(product);

                var waybill = new WaybillDomain
                {
                    IdData = DateTime.Now,
                    IdProvider = int.Parse(providers.SelectedValue.ToString()),
                    IdProviderNavigation = db.Provider.FirstOrDefault(domain => domain.IdProvider == int.Parse(providers.SelectedValue.ToString())),
                    Product = product
                };

                db.Waybill.Add(waybill);

                foreach (var productDomain in product)
                {
                    productDomain.IdWaybillNavigation = waybill;
                }

                db.SaveChanges();

                addWaybill?.Invoke();
                this.Close();
            }
        }
    }
}
