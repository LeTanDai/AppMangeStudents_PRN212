using BusinessObjects.Models;
using Repositories;
using Repository;
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
    /// Interaction logic for StudentViewScore.xaml
    /// </summary>
    public partial class StudentViewScore : Window
    {
        private readonly IStudentRepository repository;
        private readonly IMarkRepository markRepository;
        private readonly string studentId;
        private Student currentStudent;

        public StudentViewScore(Student student)
        {
            InitializeComponent();
            this.repository = new StudentRepository();
            this.markRepository = new MarkRepository();
            currentStudent = student;
            // Load student details
        }
        public void loadMarkList()
        {
            try
            {
                var markList = markRepository.GetMarksByStudent(currentStudent.Idstudent);
                dgData.ItemsSource = markList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading data");
            }
            finally
            {

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Load marks when the window is loaded
            loadMarkList();
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle the selection change if needed
            if (dgData.SelectedItem == null || !(dgData.SelectedItem is Mark selectedMark))
                return;
            txtSemester.Text = selectedMark.Semester.ToString();
            txtSubject.Text = selectedMark.Idsubject.ToString();
            txtPT1.Text =  selectedMark.ProgressTest1.ToString();
            txtPT2.Text = selectedMark.ProgressTest2.ToString();
            txtLab1.Text = selectedMark.Lab1.ToString();
            txtLab2.Text = selectedMark.Lab2.ToString();
            txtFinal.Text = selectedMark.FinalExam.ToString();
            txtPE.Text = selectedMark.PracticalExam.ToString();
            txtTotal.Text = selectedMark.Total.ToString();
        }

        private void btn_Score(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Info(object sender, RoutedEventArgs e)
        {
            this.Close();
            StudentInformation student = new StudentInformation(currentStudent);
            student.Show();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }
}
