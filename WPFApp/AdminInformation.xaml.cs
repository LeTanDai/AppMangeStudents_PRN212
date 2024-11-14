using BusinessObjects.Models;
using DataAccessLayer;
using Repositories;
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
    /// Interaction logic for AdminInformation.xaml
    /// </summary>
    public partial class AdminInformation : Window
    {
        private readonly IAdminRepository repository;
        private readonly Admin admin;
        public AdminInformation( String id )
        {
            repository = new AdminRepository();
            admin = repository.GetAdminByID( id );
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            adminname.Text = admin.Name.ToString();
            adminid.Text = admin.Id.ToString();
            admindob.Text = admin.BirthDay.ToString();
            admingender.Text = admin.Gender.ToString();
            adminemail.Text = admin.Email.ToString();
            adminphone.Text = admin.Phone.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_click(object sender, RoutedEventArgs e)
        {
            EditadminInformation editadminInformation = new EditadminInformation(admin.Id);
            this.Hide();
            editadminInformation.Show();
        }

        private void btnCancel_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
