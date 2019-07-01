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
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class DictionaryPage : Page
    {
        public List<DictionaryModel> Inf;

        public int Item { get; set; }

        public DictionaryPage()
        {
            InitializeComponent();
            Inf = FullModel();
            InsertListBox();
        }

        public List<DictionaryModel> FullModel()
        {
            using (var db = new groceryContext())
            {
                return db.Dictionary.Select(domain => new DictionaryModel
                {
                    IdDictionary = domain.IdDictionary,
                    NameDictionary = domain.NameDictionary
                }).ToList();
            }
        }

        public void InsertListBox()
        {
            database.ItemsSource = Inf;
            database.FontSize = 20;
            database.DisplayMemberPath = "NameDictionary";
            database.SelectedValuePath = "IdDictionary";
        }

        public void Refresh()
        {
            Inf = FullModel();
            database.ItemsSource = Inf;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addDictionary = new AddDictionaryWindow();
            addDictionary.Show();
            addDictionary.addDictionary += Refresh;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (database.SelectedValue != null)
            {
                var item = int.Parse(database.SelectedValue.ToString());
                var updateDictionary = new UpdateDictionaryWindow(item);
                updateDictionary.Show();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (database.SelectedValue != null)
            {
                var item = int.Parse(database.SelectedValue.ToString());
                var deleteDictionary = new DeleteDictionaryWindow(item);
                deleteDictionary.Show();
                deleteDictionary.deleteDictionary += Refresh;
            }
        }
    }
}
