using DbCustomersLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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

namespace WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CompanyContext _context = new CompanyContext();
        private Customer _customer;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _customer = _context.Customers.First();
            Formulaire.DataContext = _customer;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                _customer.AccountBalance = _customer.AccountBalance + (double)MontantAAjouterAuCompte.Value;

                try {
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch(DbUpdateConcurrencyException dbUpdConExp)
                {
                    MessageBox.Show(
                        "Erreur de mise à jour. Les données que vous tentez de modifier ont déjà été mises à jour par un autre utilisateur.",
                        "ERREUR",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );

                    var currentValues = dbUpdConExp.Entries.Single().GetDatabaseValues();


                    transaction.Rollback();
                }

            }

        }
    }
}
