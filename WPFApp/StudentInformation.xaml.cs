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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class StudentInformation : Window
    {
        private readonly IStudentService Service;
        private Student currentStudent;
        public StudentInformation( Student student )
        {
            this.Service = new StudentService();
            this.currentStudent = student;
            InitializeComponent();
        }
        private void Window_Loaded( object sender, RoutedEventArgs e )
        {
            studentdob.Text = currentStudent.BirthDay.ToString();
            studentemail.Text = currentStudent.Email.ToString();
            studentgender.Text = currentStudent.Gender.ToString();
            studentid.Text = currentStudent.Idstudent.ToString();
            studentname.Text = currentStudent.Name.ToString();
            studentphone.Text = currentStudent.Phone.ToString();
        }

        private void btnEdit_click(object sender, RoutedEventArgs e)
        {
            EditStudentInformation editStudentInformation = new EditStudentInformation(currentStudent.Idstudent);
            this.Hide();
            editStudentInformation.Show();
        }

        private void btnCancel_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_Info(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_Score(object sender, RoutedEventArgs e)
        {
            this.Close();
            StudentViewScore studentViewScore  = new StudentViewScore(currentStudent);
            studentViewScore.Show();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }
}
