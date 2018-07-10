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
    /// Logika interakcji dla klasy DodajKategorie.xaml
    /// </summary>
    public partial class DodajKategorie : Window
    {
        public DodajKategorie()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (KategoriaNadrzednaTB.Text == "" || OpisKategoriiTB.Text == "" || NazwaCechyTB.Text == "" || WartoscCechyTB.Text == "")
                    throw new Exception("Błędna wpisana wartość");
                using (var ctx = new Model1Container())
                {
                    var kategoria = new Kategorie_produktow
                    {
                        Kategoria_nadrzedna = KategoriaNadrzednaTB.Text,
                        Opis_kategorii = OpisKategoriiTB.Text,
                        Nazwa_cechy = NazwaCechyTB.Text,
                        Wartość_cechy = WartoscCechyTB.Text 
                    };
                    ctx.Kategorie_produktowSet.Add(kategoria);
                    ctx.SaveChanges();
                }
                MessageBox.Show("Dodano nową kategorię.");
                this.Close();
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                    MessageBox.Show("Błąd przy dodawaniu kategorii do bazy danych \nTreść błędu: \n\n" + ex.ToString());
                else
                    MessageBox.Show(ex.ToString());
            }
        }
    }
}
