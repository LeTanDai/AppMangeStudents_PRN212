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
        private Student student;
        public StudentInformation( Student student )
        {
            this.Service = new StudentService();
            this.student = student;
            InitializeComponent();
        }
        private void Window_Loaded( object sender, RoutedEventArgs e )
        {
            studentdob.Text = student.BirthDay.ToString();
            studentemail.Text = student.Email.ToString();
            studentgender.Text = student.Gender.ToString();
            studentid.Text = student.Idstudent.ToString();
            studentname.Text = student.Name.ToString();
            studentphone.Text = student.Phone.ToString();
        }

        private void btnEdit_click(object sender, RoutedEventArgs e)
        {
            EditStudentInformation editStudentInformation = new EditStudentInformation(student.Idstudent);
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

        }
    }
}
