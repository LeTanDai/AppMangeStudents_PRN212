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

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for DashboardTeacher.xaml
    /// </summary>
    public partial class DashboardTeacher : Window
    {
        public DashboardTeacher()
        {
            InitializeComponent();
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginWindow logn = new LoginWindow();
            logn.Show();
        }

        private void Btn_Info(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Search(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_UpdateScore(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_MngClass(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_MngStudent(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Report(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Regulation(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
