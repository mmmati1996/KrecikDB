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
    /// Logika interakcji dla klasy KlienciView1.xaml
    /// </summary>
    public partial class KlienciView1 : Window
    {
        public KlienciView1()
        {
            InitializeComponent();
            using (var ctx = new Model1Container())
            {
                KlienciView1Table.ItemsSource = ctx.Imiona_Klientow_View.ToList();
            }
        }
    }
}
