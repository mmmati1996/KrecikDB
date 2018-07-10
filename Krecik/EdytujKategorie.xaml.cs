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
    /// Logika interakcji dla klasy EdytujKategorie.xaml
    /// </summary>
    public partial class EdytujKategorie : Window
    {
        Kategorie_produktow kategoria;
        public EdytujKategorie(Kategorie_produktow kate)
        {
            InitializeComponent();
            this.kategoria = kate;
            RefreshBoxes();
        }
        private void RefreshBoxes()
        {
            KategoriaNadrzednaTB.Text = kategoria.Kategoria_nadrzedna;
            OpisKategoriiTB.Text = kategoria.Opis_kategorii;
            NazwaCechyTB.Text = kategoria.Nazwa_cechy;
            WartoscCechyTB.Text = kategoria.Wartość_cechy;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (KategoriaNadrzednaTB.Text == "" || OpisKategoriiTB.Text == "" || NazwaCechyTB.Text == "" || WartoscCechyTB.Text == "")
                    throw new Exception("Żadna wartość nie może być pusta");
                using (var ctx = new Model1Container())
                {
                    var Lquery = from st in ctx.Kategorie_produktowSet
                                 where st.Id_kategorii == kategoria.Id_kategorii
                                 select st;
                    foreach (var x in Lquery)
                    {
                        x.Kategoria_nadrzedna = KategoriaNadrzednaTB.Text;
                        x.Opis_kategorii = OpisKategoriiTB.Text;
                        x.Nazwa_cechy = NazwaCechyTB.Text;
                        x.Wartość_cechy = WartoscCechyTB.Text; 
                    }
                    ctx.SaveChanges();
                }
                MessageBox.Show("Edytowano kategorie.");
                this.Close();
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                    MessageBox.Show("Błąd przy edytowaniu kategorii w bazie danych \nTreść błędu: \n\n" + ex.ToString());
                else
                    MessageBox.Show(ex.ToString());
            }
        }
    }
}
