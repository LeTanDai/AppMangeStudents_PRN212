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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EditStudentInformation : Window
    {
        private readonly IStudentRepository repository;
        private Student student;
        public EditStudentInformation( String id )
        {
            repository = new StudentRepository();
            student = repository.GetStudentByID(id);
            InitializeComponent();
        }
        private void Window_Loaded( object sender, RoutedEventArgs e )
        {
            DateTime datetime = DateTime.Parse(student.BirthDay.ToString());
            dpStudentdob.SelectedDate = datetime;
            txtStudentemail.Text = student.Email.ToString();
            txtStudentgender.Text = student.Gender.ToString();
            txtStudentid.Text = student.Idstudent.ToString();
            txtStudentname.Text = student.Name.ToString();
            txtStudentPassword.Text = student.PassWord.ToString();
            txtStudentphone.Text = student.Phone.ToString();
        }

        private void btnDoneofAddUser_click(object sender, RoutedEventArgs e)
        {
            DateTime datetime = dpStudentdob.SelectedDate.Value;
            DateOnly birth = DateOnly.FromDateTime(datetime);
            student.BirthDay = birth;
            student.Email = txtStudentemail.Text;
            student.Gender = txtStudentgender.Text;
            student.Idstudent = txtStudentid.Text;
            student.Name = txtStudentname.Text;
            student.PassWord = txtStudentPassword.Text;
            student.Phone = txtStudentphone.Text;
            repository.UpdateStudent(student);
            this.Hide();
            StudentInformation studentInformation = new StudentInformation(student.Idstudent);
            studentInformation.Show();
        }

        private void btnCancel_click(object sender, RoutedEventArgs e)
        {

        }

        private void txtStudentid_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
