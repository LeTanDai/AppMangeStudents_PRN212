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
    /// Interaction logic for StudentViewScore.xaml
    /// </summary>
    public partial class StudentViewScore : Window
    {
        private readonly IStudentRepository repository;
        private readonly IMarkRepository markRepository;
        private readonly string studentId;
        private Student student;

        public StudentViewScore(string id)
        {
            InitializeComponent();
            this.repository = new StudentRepository();
            this.markRepository = new MarkRepository();
            this.studentId = id;

            // Load student details
            student = repository.GetStudentByID(id);
        }
        public void loadMarkList()
        {
            try
            {

                var markList = markRepository.GetMarksByStudent(studentId);


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
            studentname.Text = student?.Name ?? "Student not found";
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle the selection change if needed
        }
    }
}
