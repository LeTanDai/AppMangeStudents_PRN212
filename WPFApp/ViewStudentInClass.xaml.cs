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
    /// Interaction logic for ViewStudentInClass.xaml
    /// </summary>
    public partial class ViewStudentInClass : Window
    {
        private Teacher currentTeacher;
        private Class currentClass;
        private readonly IAssignRepository assignRepository;
        private readonly IClassRepository classRepository;
        private readonly IStudentClassRepository studentClassRepository;
        private IStudentRepository studentRepository;
        public ViewStudentInClass(Class currentC, Teacher teacher)
        {
            InitializeComponent();
            this.currentClass = currentC;
            this.currentTeacher = teacher;
            assignRepository = new AssignRepository();
            classRepository = new ClassRepository();
            studentClassRepository = new StudentClassRepository();
            studentRepository = new StudentRepository();
        }

        private void loadStudentList()
        {
            List<Student> students = new List<Student>();
            try
            {
                var studentList = studentClassRepository.GetStudentsByClass(currentClass);
                if (studentList != null)
                {
                    foreach (var student in studentList)
                    {
                        var sList = studentRepository.GetStudentByID(student.Idstudent);
                        if (sList != null)
                        {
                            students.Add(sList);
                        }
                    }
                }
                dgData.ItemsSource = students;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                resetInput();
            }
        }
        private void resetInput()
        {
            txtName.Text = "";
            txtGender.Text = "";
            txtDob.Text = "";
            txtPhone.Text = "";
            txtId.Text = "";
            txtEmail.Text = "";
        }


        private void Btn_Info(object sender, RoutedEventArgs e)
        {
            this.Close();
            TeacherInformation teacher = new TeacherInformation(currentTeacher);
            teacher.Show();
        }

        private void Btn_Search(object sender, RoutedEventArgs e)
        {
            this.Close();
            SearchStudent searchStudent =  new SearchStudent(currentTeacher); 
            searchStudent.Show();
        }

        private void Btn_UpdateScore(object sender, RoutedEventArgs e)
        {
            this.Close();
            TeacherUpdateScore teacher = new TeacherUpdateScore(currentTeacher);
            teacher.Show();
        }

        private void Btn_MngClass(object sender, RoutedEventArgs e)
        {
            this.Close();
            ManageClassTeacher manageClassWindow = new ManageClassTeacher(currentTeacher);
            manageClassWindow.Show();
        }

        private void Btn_MngStudent(object sender, RoutedEventArgs e)
        {
            this.Close();
            TeacherManageStudent teacher = new TeacherManageStudent(currentTeacher);
            teacher.Show();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ManageClassTeacher manageClassWindow = new ManageClassTeacher(currentTeacher);
            manageClassWindow.Show();
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem == null || !(dgData.SelectedItem is Student selectedStudent))
                return;

            txtId.Text = selectedStudent.Idstudent.ToString();
            txtName.Text = selectedStudent.Name.ToString();
            txtGender.Text = selectedStudent.Gender.ToString();
            txtDob.Text = selectedStudent.BirthDay.ToString();
            txtPhone.Text = selectedStudent.Phone.ToString();
            txtEmail.Text = selectedStudent.Email.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadStudentList();
        }
    }
}
