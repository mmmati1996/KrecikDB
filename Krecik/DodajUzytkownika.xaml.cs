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

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Driver.Linq;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Krecik
{
    /// <summary>
    /// Logika interakcji dla klasy DodajUzytkownika.xaml
    /// </summary>
    public partial class DodajUzytkownika : Window
    {
        public DodajUzytkownika()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int perm = 0;
            if (combodostep.Text == "0 - użytkownik")
                perm = 0;
            else
                perm = 1;
            try
            {
                    string connectionstring = "mongodb://admin:admin@ds046047.mlab.com:46047/krecikdb";
                    MongoClient client = new MongoClient(connectionstring);
                    var db = client.GetDatabase("krecikdb");
                    var collection = db.GetCollection<BsonDocument>("Users");
                    var dodatkowe_info = new BsonDocument
                    {
                        {"Imie",ImieTB.Text},
                        {"Nazwisko",NazwiskoTB.Text},
                        {"Adres",AdresTB.Text},
                        {"AdresEmail",EmailTB.Text},
                        {"NumerTelefonu",NrTB.Text}
                    };
                    var documnt = new BsonDocument
                    {
                        {"login",LoginTB.Text},
                        {"password",HasloTB.Text},
                        {"permission",perm},
                        {"czaszalogowania",new DateTime().ToString()},
                        {"czaswylogowania",new DateTime().ToString()},
                        {"dane",dodatkowe_info }
                    };
                    collection.InsertOne(documnt);
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił problem z dodaniem użytkownika. Proszę spróbować ponownie. \n" + ex);
            }
        }
    }
}
