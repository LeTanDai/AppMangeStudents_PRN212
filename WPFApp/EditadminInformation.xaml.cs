using BusinessObjects.Models;
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
    /// Interaction logic for EditadminInformation.xaml
    /// </summary>
    public partial class EditadminInformation : Window
    {
        private readonly IAdminRepository repository;
        private readonly Admin Admin;
        public EditadminInformation( String id)
        {
            repository = new AdminRepository();
            Admin = repository.GetAdminByID(id);
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime datetime = DateTime.Parse(Admin.BirthDay.ToString());
            dpAdmindob.SelectedDate = datetime;
            txtAdminemail.Text = Admin.Email.ToString();
            txtAdmingender.Text = Admin.Gender.ToString();
            txtAdminid.Text = Admin.Id.ToString();
            txtAdminname.Text = Admin.Name.ToString();
            txtAdminPassword.Text = Admin.PassWord.ToString();
            txtAdminphone.Text = Admin.Phone.ToString();
        }

        private void btnDoneofAddUser_click(object sender, RoutedEventArgs e)
        {
            DateTime datetime = dpAdmindob.SelectedDate.Value;
            DateOnly birth = DateOnly.FromDateTime(datetime);
            Admin.BirthDay = birth;
            Admin.Email = txtAdminemail.Text;
            Admin.Gender = txtAdmingender.Text;
            Admin.Id = txtAdminid.Text;
            Admin.Name = txtAdminname.Text;
            Admin.PassWord = txtAdminPassword.Text;
            Admin.Phone = txtAdminphone.Text;
            repository.UpdateAdmin(Admin);
            this.Hide();
            AdminInformation AdminInformation = new AdminInformation(Admin.Id);
            AdminInformation.Show();
        }

        private void btnCancel_click(object sender, RoutedEventArgs e)
        {

        }

        private void txtAdminid_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void txtStudentid_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
