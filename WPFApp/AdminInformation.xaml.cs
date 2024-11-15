using BusinessObjects.Models;
using DataAccessLayer;
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
    /// Interaction logic for AdminInformation.xaml
    /// </summary>
    public partial class AdminInformation : Window
    {
        private readonly IAdminService Service;
        private readonly Admin currentAdmin;
        public AdminInformation( Admin admin )
        {
            InitializeComponent();
            Service = new AdminService();
            this.currentAdmin = admin;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            adminname.Text = currentAdmin.Name.ToString();
            adminid.Text = currentAdmin.Id.ToString();
            admindob.Text = currentAdmin.BirthDay.ToString();
            admingender.Text = currentAdmin.Gender.ToString();
            adminemail.Text = currentAdmin.Email.ToString();
            adminphone.Text = currentAdmin.Phone.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_click(object sender, RoutedEventArgs e)
        {
            EditadminInformation editadminInformation = new EditadminInformation(currentAdmin.Id);
            this.Hide();
            editadminInformation.Show();
        }

        private void btnCancel_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_MngAssign(object sender, RoutedEventArgs e)
        {
            this.Close();
            ManageAssignAdmin manageAssignAdmin = new ManageAssignAdmin(currentAdmin);
            this.Hide();
            manageAssignAdmin.Show();
        }

        private void btn_MngStudent(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_MngTeacher(object sender, RoutedEventArgs e)
        {
            this.Close();
            ManageTeacherAdmin manage = new ManageTeacherAdmin(currentAdmin);
            manage.Show();
        }

        private void Btn_MngClass(object sender, RoutedEventArgs e)
        {
            this.Close();
            ManageClassAdmin admin = new ManageClassAdmin(currentAdmin);
            admin.Show();
        }

        private void Btn_MngSubject(object sender, RoutedEventArgs e)
        {
            this.Close();
            ManageSubjectAdmin admin = new ManageSubjectAdmin(currentAdmin);
            admin.Show();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void Btn_Info(object sender, RoutedEventArgs e)
        {
        }
    }
}
