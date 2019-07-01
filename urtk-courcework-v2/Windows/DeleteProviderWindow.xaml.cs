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
    /// Логика взаимодействия для DeleteProviderWindow.xaml
    /// </summary>
    public partial class DeleteProviderWindow : Window
    {
        public delegate void DeleteProvider();

        public event DeleteProvider deleteProvider;

        public ProviderDomain Provider { get; set; }
        public DeleteProviderWindow(int id)
        {
            InitializeComponent();
            using (var db = new groceryContext())
            {
                Provider = db.Provider.FirstOrDefault(domain => domain.IdProvider == id);
            }

            text.Text += Provider?.DenomintaionProvider;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new groceryContext())
            {
                db.Provider.Remove(Provider);
                db.SaveChanges();
            }

            deleteProvider?.Invoke();
            this.Close();
        }
    }
}
