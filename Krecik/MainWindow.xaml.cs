using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
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

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Driver.Linq;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Krecik
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MongoDBEntity.Users user;
        public MainWindow(MongoDBEntity.Users user)
        {
            InitializeComponent();
            this.user = user;
            Config(user);
        }
        private void Config(MongoDBEntity.Users u)
        {
            this.Title += " Zalogowano jako: " + u.login;
            if (u.permission == 1)
            {
                this.Title += "   Administrator";
                this.AdminPanel.Visibility = Visibility.Visible;
            }
            else
            {
                this.Title += "   Użytkownik";
                this.AdminPanel.Visibility = Visibility.Hidden;
            }

        }
        /*private void sth()
        {
            KlienciTable.Items.Clear();
            ComboBoxKlienci.Items.Clear();
            using (var ctx = new Model1Container())
            {
                var Lquery = from st in ctx.KlienciSet
                             select st;
                foreach (var s in Lquery)
                {
                    KlienciTable.Items.Add(s);
                    ComboBoxKlienci.Items.Add(s.Nazwa_firmy);
                }
            }
        }*/

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshKlients();
        }
        private void RefreshKlients()
        {
            KlienciTable.Items.Clear();
            //ComboBoxKlienci.Items.Clear();
            using (var ctx = new Model1Container())
            {
                var Lquery = from st in ctx.KlienciSet
                            select st;
                foreach (var s in Lquery)
                {
                    KlienciTable.Items.Add(s);
                    //ComboBoxKlienci.Items.Add(s.Nazwa_firmy);
                }
            }
        }

        private void DodajKlientaBUTTON_Click(object sender, RoutedEventArgs e)
        {
            var KlientOkno = new DodajKlienta();
            KlientOkno.Show();
        }

        private void UsunKlientaButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (KlienciTable.SelectedItem == null)
                    throw new Exception("Nie wybrano zadnego klienta");
                using (var ctx = new Model1Container())
                {
                    Klienci klient = KlienciTable.SelectedItem as Klienci;
                    int rowIndex = KlienciTable.SelectedIndex;
                    var Lquery = from st in ctx.KlienciSet
                                 where st.Id_klienta == klient.Id_klienta
                                 select st;
                    foreach (var x in Lquery)
                        ctx.KlienciSet.Remove(x);
                    ctx.SaveChanges();
                    RefreshKlients();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void EdytujKlientaButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (KlienciTable.SelectedItem == null)
                    throw new Exception("Nie wybrano zadnego klienta");
                Klienci klient = KlienciTable.SelectedItem as Klienci;
                var EdytujOkno = new EdytujKlienta(klient);
                EdytujOkno.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void UsunKlientaProcedureButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (KlienciTable.SelectedItem == null)
                    throw new Exception("Nie wybrano zadnego klienta");
                using (var ctx = new Model1Container())
                {
                    Klienci klient = KlienciTable.SelectedItem as Klienci;
                    ctx.DeleteKlient(klient.Id_klienta);
                    ctx.SaveChanges();
                    RefreshKlients();
                }
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType().ToString());
                if (ex.InnerException == null)
                    MessageBox.Show("Niepoprawne dane klienta.");
                else
                    MessageBox.Show(ex.InnerException.InnerException.Message);
            }
        }

        private void PokazWidok1Button_Click(object sender, RoutedEventArgs e)
        {
            var WindowView = new KlienciView1();
            WindowView.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string connectionstring = "mongodb://admin:admin@ds046047.mlab.com:46047/krecikdb";
            MongoClient client = new MongoClient(connectionstring);
            var db = client.GetDatabase("krecikdb");
            var collection = db.GetCollection<MongoDBEntity.Users>("Users");
            string czas = DateTime.Now.ToString();
            //update czas wylogowania
            var update = Builders<MongoDBEntity.Users>.Update.Set(a => a.czaswylogowania, czas);
            var result = collection.UpdateOne(b => b.login == user.login, update);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionstring = "mongodb://admin:admin@ds046047.mlab.com:46047/krecikdb";
                MongoClient client = new MongoClient(connectionstring);
                var db = client.GetDatabase("krecikdb");
                var collection = db.GetCollection<MongoDBEntity.Users>("Users");
                var query =
                        from ey in collection.AsQueryable<MongoDBEntity.Users>()
                        select ey;
                MongoLog.Items.Clear();
                foreach (var employee in query)
                {
                    string tekst;
                    if (employee.permission == 1)
                        tekst = "Administrator";
                    else
                        tekst = "Uzytkownik";

                    if (employee.czaswylogowania != "zalogowany")
                    {
                        DateTime czaszal = StringToTime(employee.czaszalogowania);
                        DateTime czaswyl = StringToTime(employee.czaswylogowania);
                        TimeSpan dif = czaswyl - czaszal;
                        MongoLog.Items.Add(new AdminMongoLog{ login = employee.login, permission = tekst, czaszal = employee.czaszalogowania, czaswyl = employee.czaswylogowania, online=dif.ToString()});
                    }
                    else if (employee.czaszalogowania != "never")
                    {
                            DateTime czaszal = StringToTime(employee.czaszalogowania);
                            DateTime czaswyl = DateTime.Now;
                            TimeSpan dif = czaswyl - czaszal;
                            MongoLog.Items.Add(new AdminMongoLog { login = employee.login, permission = tekst, czaszal = employee.czaszalogowania, czaswyl = employee.czaswylogowania, online = dif.ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił problem z odświeżaniem. Proszę spróbować ponownie. \n" + ex);
            }
        }

        public class AdminMongoLog
        {
            public string login { get; set; }
            public string permission { get; set; }
            public string czaszal { get; set; }
            public string czaswyl { get; set; }
            public string online { get; set; }
        }
        private DateTime StringToTime(string time)
        {
            return DateTime.ParseExact(time, "dd.MM.yyyy HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);
        }

        private void DodajUzytkownikaButton_Click(object sender, RoutedEventArgs e)
        {
            var okno = new DodajUzytkownika();
            okno.Show();
        }

        private void ShowDetails(object sender, RoutedEventArgs e)
        {

            AdminMongoLog obj = ((FrameworkElement)sender).DataContext as AdminMongoLog;
            try
            {
                string connectionstring = "mongodb://admin:admin@ds046047.mlab.com:46047/krecikdb";
                MongoClient client = new MongoClient(connectionstring);
                var db = client.GetDatabase("krecikdb");
                var collection = db.GetCollection<MongoDBEntity.Users>("Users");
                var query =
                        from ey in collection.AsQueryable<MongoDBEntity.Users>()
                        where ey.login == obj.login
                        select ey;
                foreach (var x in query)
                {
                        MessageBox.Show("Imie: " + x.dane.Imie + "\n" +
                            "Nazwisko: " + x.dane.Nazwisko + "\n" +
                            "Adres: " + x.dane.Adres + "\n" +
                            "E-mail: " + x.dane.AdresEmail + "\n" +
                            "Numer telefonu: " + x.dane.NumerTelefonu + "\n"
                            );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystapil blad z pobraniem danych \n\n\n\n" + ex);
            }
        }

        private void KategoriaProduktowOdswiez_Click(object sender, RoutedEventArgs e)
        {
            OdswiezKategorie();
        }
        private void OdswiezKategorie()
        {
            using (var ctx = new Model1Container())
            {
                KategorieProduktowView.ItemsSource = ctx.Kategorie_produktowSet.ToList();
            }
        }

        private void DodajKategorieButton_Click(object sender, RoutedEventArgs e)
        {
            var okno = new DodajKategorie();
            okno.Show();
        }

        private void EdytujKategorieButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (KategorieProduktowView.SelectedItem == null)
                    throw new Exception("Nie wybrano zadnego klienta");
                Kategorie_produktow kategoria = KategorieProduktowView.SelectedItem as Kategorie_produktow;
                var okno = new EdytujKategorie(kategoria);
                okno.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void UsunKategorieButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (KategorieProduktowView.SelectedItem == null)
                    throw new Exception("Nie wybrano zadnej kategorii");
                using (var ctx = new Model1Container())
                {
                    Kategorie_produktow kategoria = KategorieProduktowView.SelectedItem as Kategorie_produktow;
                    var Lquery = from st in ctx.Kategorie_produktowSet
                                 where st.Id_kategorii == kategoria.Id_kategorii
                                 select st;
                    foreach (var x in Lquery)
                        ctx.Kategorie_produktowSet.Remove(x);
                    ctx.SaveChanges();
                    OdswiezKategorie();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
