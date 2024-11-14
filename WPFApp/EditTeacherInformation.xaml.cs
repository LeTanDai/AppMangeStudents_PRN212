using BusinessObjects;
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
using BusinessObjects.Models;
namespace WPFApp
{
    /// <summary>
    /// Interaction logic for EditTeacherInformation.xaml
    /// </summary>
    public partial class EditTeacherInformation : Window
    {
        private readonly ITeacherRepository repository;
        private Teacher Teacher;
        public EditTeacherInformation(String id)
        {
            repository = new TeacherRepository();
            Teacher = repository.GetTeacherByID(id);
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime datetime = DateTime.Parse(Teacher.BirthDay.ToString());
            dpTeacherdob.SelectedDate = datetime;
            txtTeacheremail.Text = Teacher.Email.ToString();
            txtTeachergender.Text = Teacher.Gender.ToString();
            txtTeacherid.Text = Teacher.Idteacher.ToString();
            txtTeachername.Text = Teacher.Name.ToString();
            txtTeacherPassword.Text = Teacher.PassWord.ToString();
            txtTeacherphone.Text = Teacher.Phone.ToString();
        }

        private void btnDoneofAddUser_click(object sender, RoutedEventArgs e)
        {
            DateTime datetime = dpTeacherdob.SelectedDate.Value;
            DateOnly birth = DateOnly.FromDateTime(datetime);
            Teacher.BirthDay = birth;
            Teacher.Email = txtTeacheremail.Text;
            Teacher.Gender = txtTeachergender.Text;
            Teacher.Idteacher = txtTeacherid.Text;
            Teacher.Name = txtTeachername.Text;
            Teacher.PassWord = txtTeacherPassword.Text;
            Teacher.Phone = txtTeacherphone.Text;
            repository.UpdateTeacher(Teacher);
            this.Hide();
            TeacherInformation TeacherInformation = new TeacherInformation(Teacher.Idteacher);
            TeacherInformation.Show();
        }

        private void btnCancel_click(object sender, RoutedEventArgs e)
        {

        }

        private void txtTeacherid_TextChanged(object sender, TextChangedEventArgs e)
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
