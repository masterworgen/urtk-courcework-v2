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
    /// Логика взаимодействия для AddDictionaryWindow.xaml
    /// </summary>
    public partial class AddDictionaryWindow : Window
    {
        public delegate void AddDictionary();

        public event AddDictionary addDictionary;
        public AddDictionaryWindow()
        {
            InitializeComponent();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new groceryContext())
            {
                db.Dictionary.Add(new DictionaryDomain
                {
                    NameDictionary = nameDictioanary.Text
                });
                db.SaveChanges();
            }
            addDictionary?.Invoke();
            this.Close();
        }
    }
}
