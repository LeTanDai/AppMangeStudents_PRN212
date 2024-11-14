using BusinessObjects.Models;
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
    /// Interaction logic for WindowListStudentByClass.xaml
    /// </summary>
    public partial class WindowListStudentByClass : Window
    {
        private Class currentClass;
        private readonly IStudentClassService studentClassService;
        public WindowListStudentByClass(Class cl)
        {
            InitializeComponent();
            currentClass = cl;
            studentClassService = new StudentClassService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadStudentListByClass(currentClass);
        }

        private void LoadStudentListByClass(Class cl)
        {
            try
            {
                var studentList = studentClassService.GetStudentsByClass(cl);
                dgData.ItemsSource = studentList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                resetInput();
            }
        }

        private void resetInput()
        {
            txtStudentID.Text = "";
            txtStudentName.Text = "";
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var studentClass = new StudentClass
                {
                    Idstudent = txtStudentID.Text,
                    NameClass = currentClass.NameClass,
                    SchoolYear = currentClass.SchoolYear,
                };
                studentClassService.CreateStudentClass(studentClass);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadStudentListByClass(currentClass);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var studentClass = new StudentClass
                {
                    Idstudent = txtStudentID.Text,
                    NameClass = currentClass.NameClass,
                    SchoolYear = currentClass.SchoolYear,
                };
                studentClassService.DeleteStudentClass(studentClass);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadStudentListByClass(currentClass);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem == null)
                return;

            Student? selectedStudent = dgData.SelectedItem as Student;
            if (selectedStudent != null)
            {
                txtStudentID.Text = selectedStudent.Idstudent?.ToString() ?? string.Empty;

                // Kiểm tra tên có null không
                txtStudentName.Text = selectedStudent.Name ?? string.Empty;
            }
        }
    }
}
