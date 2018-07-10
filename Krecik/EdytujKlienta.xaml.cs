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

namespace Krecik
{
    /// <summary>
    /// Logika interakcji dla klasy EdytujKlienta.xaml
    /// </summary>
    public partial class EdytujKlienta : Window
    {
        Klienci klient;
        public EdytujKlienta(Klienci klient)
        {
            this.klient = klient;
            InitializeComponent();
            RefreshBoxes();
        }
        private void RefreshBoxes()
        {
            ImieTB.Text = klient.Imie;
            NazwiskoTB.Text = klient.Nazwisko;
            Nazwa_firmyTB.Text = klient.Nazwa_firmy;
            Kod_pocztowyTB.Text = klient.Kod_pocztowy;
            MiastoTB.Text = klient.Miasto;
            UlicaTB.Text = klient.Ulica;
            Nr_domuTB.Text = klient.Nr_domu;
            Nr_lokaluTB.Text = klient.Nr_lokalu;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ImieTB.Text == "" || NazwiskoTB.Text == "" || Nazwa_firmyTB.Text == "" || Kod_pocztowyTB.Text == "" || MiastoTB.Text == "" || Nr_domuTB.Text == "")
                    throw new Exception("Żadna wartość nie może być pusta");
                using (var ctx = new Model1Container())
                {
                    var Lquery = from st in ctx.KlienciSet
                                 where st.Id_klienta == klient.Id_klienta
                                 select st;
                    foreach(var x in Lquery)
                    {
                        x.Imie = ImieTB.Text;
                        x.Nazwisko = NazwiskoTB.Text;
                        x.Nazwa_firmy = Nazwa_firmyTB.Text;
                        x.Kod_pocztowy = Kod_pocztowyTB.Text;
                        x.Miasto = MiastoTB.Text;
                        x.Nr_domu = Nr_domuTB.Text;
                        x.Nr_lokalu = Nr_lokaluTB.Text;
                        x.Ulica = UlicaTB.Text;
                    }
                    ctx.SaveChanges();
                }
                MessageBox.Show("Edytowano klienta.");
                this.Close();
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                    MessageBox.Show("Błąd przy edytowaniu klienta w bazie danych \nTreść błędu: \n\n" + ex.ToString());
                else
                    MessageBox.Show(ex.ToString());
            }
        }
    }
}
