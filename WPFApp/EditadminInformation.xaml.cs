using BusinessObjects.Models;
using Repositories;
using Services;
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
        private readonly IAdminService service;
        private readonly Admin Admin;
        public EditadminInformation( String id)
        {
            service = new AdminService();
            Admin = service.GetAdminByID(id);
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Gender();
            DateTime datetime = DateTime.Parse(Admin.BirthDay.ToString());
            dpAdmindob.SelectedDate = datetime;
            txtAdminemail.Text = Admin.Email.ToString();
            txtAdminid.Text = Admin.Id.ToString();
            txtAdminname.Text = Admin.Name.ToString();
            txtAdminPassword.Text = Admin.PassWord.ToString();
            txtAdminphone.Text = Admin.Phone.ToString();
        }

        private void Gender()
        {
            var genders = new List<string> { "Male", "Female" };
            cboAdmingender.SelectedValue = Admin.Gender.ToString();
            cboAdmingender.ItemsSource = genders;
        }
        private void btnDoneofAddUser_click(object sender, RoutedEventArgs e)
        {
            DateTime datetime = dpAdmindob.SelectedDate.Value;
            DateOnly birth = DateOnly.FromDateTime(datetime);
            Admin.BirthDay = birth;
            Admin.Email = txtAdminemail.Text;
            Admin.Gender = cboAdmingender.SelectedValue.ToString();
            Admin.Id = txtAdminid.Text;
            Admin.Name = txtAdminname.Text;
            Admin.PassWord = txtAdminPassword.Text;
            Admin.Phone = txtAdminphone.Text;
            service.UpdateAdmin(Admin);
            this.Hide();
            AdminInformation AdminInformation = new AdminInformation(Admin);
            AdminInformation.Show();
        }

        private void btnCancel_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminInformation AdminInformation = new AdminInformation(Admin);
            AdminInformation.Show();
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
