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
    /// Логика взаимодействия для DeleteDictionaryWindow.xaml
    /// </summary>
    public partial class DeleteDictionaryWindow : Window
    {
        public delegate void DeleteDictionary();

        public event DeleteDictionary deleteDictionary;

        public DictionaryDomain Dictionary { get; set; }

        public DeleteDictionaryWindow(int id)
        {
            InitializeComponent();
            using (var db = new groceryContext())
            {
                Dictionary = db.Dictionary.FirstOrDefault(domain => domain.IdDictionary == id);
            }
            text.Text += Dictionary?.NameDictionary;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new groceryContext())
            {
                db.Dictionary.Remove(Dictionary);
                db.SaveChanges();
            }

            deleteDictionary?.Invoke();
            this.Close();
        }
    }
}
