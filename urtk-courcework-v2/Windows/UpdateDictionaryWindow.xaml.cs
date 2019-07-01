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

namespace urtk_courcework_v2.Windows
{
    /// <summary>
    /// Логика взаимодействия для UpdateDictionaryWindow.xaml
    /// </summary>
    public partial class UpdateDictionaryWindow : Window
    {
        public MainWindow mainWindow;
        public int Item { get; set; }

        public UpdateDictionaryWindow(int item)
        {
            InitializeComponent();
            Item = item;
            using(var db = new groceryContext())
            {
                nameDictioanary.Text = db.Dictionary.FirstOrDefault(domain => domain.IdDictionary == Item).NameDictionary;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new groceryContext())
            {
                var oldDictionary = db.Dictionary.FirstOrDefault(domain => domain.IdDictionary == Item);
                oldDictionary.NameDictionary = nameDictioanary.Text;
                db.SaveChanges();
            }
            
            this.Close();
        }
    }
}
