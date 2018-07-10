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
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
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
                MongoDBEntity.Users user = new MongoDBEntity.Users();
                bool iscorrect = false;
                foreach (var employee in query)
                {
                    if (employee.login == LoginBox.Text.ToLower())
                    {
                        user = employee;
                        iscorrect = true;
                        break;
                    }
                }
                if (iscorrect == true)
                {
                    if (user.login == LoginBox.Text.ToLower())
                    {
                        if (user.password == PasswordBox.Password.Trim())
                        {
                            string czas = DateTime.Now.ToString();
                            //update czas zalogowania
                            var update = Builders<MongoDBEntity.Users>.Update.Set(a => a.czaszalogowania, czas);
                            var result = collection.UpdateOne(b => b.login == user.login, update);
                            var update2 = Builders<MongoDBEntity.Users>.Update.Set(a => a.czaswylogowania, "zalogowany");
                            var result2 = collection.UpdateOne(b => b.login == user.login, update2);
                            var main = new MainWindow(user);
                            main.Show();
                            this.Close();
                        }
                        else
                            throw new Exception("Błędne dane logowania.");
                    }
                }
                else
                    throw new Exception("Błędne dane logowania.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił problem z zalogowaniem się do systemu. Proszę spróbować ponownie. \n"+ex);
            }
        }
    }
}
