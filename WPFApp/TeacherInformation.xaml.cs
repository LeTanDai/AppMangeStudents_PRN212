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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class TeacherInformation : Window
    {
        private readonly ITeacherService Service;
        private readonly Teacher teach;
        public TeacherInformation( Teacher teacher )
        {
            Service = new TeacherService();
            teach = teacher;
            InitializeComponent();
        }
        private void Window_Loaded( object sender, RoutedEventArgs e )
        {
            teachername.Text = teach.Name.ToString();
            teacherid.Text = teach.Idteacher.ToString();
            teacherdob.Text = teach.BirthDay.ToString();
            teachergender.Text = teach.Gender.ToString();
            teacheremail.Text = teach.Email.ToString();
            teacherphone.Text = teach.Phone.ToString();
        }

        private void btnEdit_click(object sender, RoutedEventArgs e)
        {
            EditTeacherInformation editTeacherInformation = new EditTeacherInformation(teach.Idteacher);
            this.Hide();
            editTeacherInformation.Show();
        }

        private void btnCancel_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_Info(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Search(object sender, RoutedEventArgs e)
        {
            this.Close();
            SearchStudent searchStudent = new SearchStudent(teach);
            searchStudent.Show();
        }

        private void Btn_UpdateScore(object sender, RoutedEventArgs e)
        {
            this.Hide();
            TeacherUpdateScore teacherUpdateScore = new TeacherUpdateScore(teach);
            teacherUpdateScore.Show();
        }

        private void Btn_MngClass(object sender, RoutedEventArgs e)
        {
            this.Close();
            ManageClassTeacher teacher = new ManageClassTeacher(teach);
            teacher.Show();
        }

        private void Btn_MngStudent(object sender, RoutedEventArgs e)
        {
            this.Close();
            TeacherManageStudent te = new TeacherManageStudent(teach);
            te.Show();
        }
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

    }
}
