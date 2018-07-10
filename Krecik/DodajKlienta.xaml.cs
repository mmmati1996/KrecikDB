using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
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

namespace Krecik
{
    /// <summary>
    /// Logika interakcji dla klasy DodajKlienta.xaml
    /// </summary>
    public partial class DodajKlienta : Window
    {
        public DodajKlienta()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ImieTB.Text == "" || NazwiskoTB.Text == "" || Nazwa_firmyTB.Text == "" || Kod_pocztowyTB.Text == "" || MiastoTB.Text == "" || Nr_domuTB.Text == "")
                    throw new Exception("Błędna wpisana wartość");
                using (var ctx = new Model1Container())
                {
                    var klient = new Klienci
                    {
                        Imie = ImieTB.Text,
                        Nazwisko = NazwiskoTB.Text,
                        Nazwa_firmy = Nazwa_firmyTB.Text,
                        Kod_pocztowy = Kod_pocztowyTB.Text,
                        Miasto = MiastoTB.Text,
                        Nr_domu = Nr_domuTB.Text,
                        Nr_lokalu = Nr_lokaluTB.Text,
                        Ulica = UlicaTB.Text
                    };
                    ctx.KlienciSet.Add(klient);
                    ctx.SaveChanges();
                }
                MessageBox.Show("Dodano nowego klienta.");
                this.Close();
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                    MessageBox.Show("Błąd przy dodawaniu klienta do bazy danych \nTreść błędu: \n\n" + ex.ToString());
                else
                    MessageBox.Show(ex.ToString());
            }
        }

       private void AddNewClientProcedurButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ImieTB.Text == "" || NazwiskoTB.Text == "" || Nazwa_firmyTB.Text == "" || Kod_pocztowyTB.Text == "" || MiastoTB.Text == "" || Nr_domuTB.Text == "")
                    throw new Exception("Błędna wpisana wartość");
                using (var ctx = new Model1Container())
                {
                    ctx.InsertNewKlient(ImieTB.Text,
                            NazwiskoTB.Text,
                            Nazwa_firmyTB.Text,
                            Kod_pocztowyTB.Text,
                            MiastoTB.Text,
                            Nr_domuTB.Text,
                            Nr_lokaluTB.Text,
                            UlicaTB.Text);
                    ctx.SaveChanges();
                }
                MessageBox.Show("Dodano nowego klienta.");
                this.Close();
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                .SelectMany(x => x.ValidationErrors)
                .Select(x => x.ErrorMessage);
                var fullErrorMessage = string.Join("; ", errorMessages);
                MessageBox.Show(fullErrorMessage);
            }
            catch (System.Data.Entity.Core.EntityCommandExecutionException ex)
            {
                if (ex.InnerException == null)
                    MessageBox.Show("Niepoprawne dane klienta.");
                else
                    MessageBox.Show(ex.InnerException.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType().ToString());
                if (ex.InnerException == null)
                    MessageBox.Show("Niepoprawne dane klienta.");
                else
                    MessageBox.Show(ex.InnerException.InnerException.Message);
            }
        }
    }
}
