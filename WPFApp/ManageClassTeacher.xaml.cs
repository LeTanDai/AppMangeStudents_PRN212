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
    /// Interaction logic for ManageClassTeacher.xaml
    /// </summary>
    public partial class ManageClassTeacher : Window
    {
        private Teacher currentTeacher;
        private Class currentStudentClass;
        private readonly IAssignRepository _assignRepository;
        private readonly IClassRepository _classRepository;
        public ManageClassTeacher(Teacher teacher)
        {
            InitializeComponent();
            this.currentTeacher = teacher;
            _assignRepository = new AssignRepository();
            _classRepository = new ClassRepository();
        }
        public void LoadClassList()
        {

            try
            {
                var assignList = _assignRepository.GetAssignByTeacherId(currentTeacher.Idteacher);

                dgData.ItemsSource = assignList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error on load list of classes");
            }
            finally
            {
                resetInput();
            }
        }

        private void resetInput()
        {
            txtClass.Text = "";
            txtYear.Text = "";
            txtSubject.Text = "";
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            if (currentStudentClass != null)
            {
                this.Hide();
                ViewStudentInClass viewStudentInClass = new ViewStudentInClass(currentStudentClass, currentTeacher); // Pass currentStudentClass here
                viewStudentInClass.Show();
            }
            else
            {
                MessageBox.Show("Please select a class first.", "Error");
            }
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
            SearchStudent searchStudent = new SearchStudent(currentTeacher);
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
            ManageClassTeacher teacher = new ManageClassTeacher(currentTeacher);
            teacher.Show();
        }
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem == null || !(dgData.SelectedItem is Assign selectedAssign))
                return;

            txtClass.Text = selectedAssign.NameClass.ToString();
            txtSubject.Text = selectedAssign.Idsubject.ToString();
            txtYear.Text = selectedAssign.SchoolYear.ToString();
            currentStudentClass = _classRepository.GetClass(txtClass.Text, txtYear.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadClassList();
        }

        private void Btn_MngStudent(object sender, RoutedEventArgs e)
        {
            this.Close();
            TeacherManageStudent teacher = new TeacherManageStudent(currentTeacher);
            teacher.Show();
        }
    }
}
