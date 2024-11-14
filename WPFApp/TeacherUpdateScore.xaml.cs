using BusinessObjects.Models;
using Repositories;
using Repository;
using Reppositories;
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
using WpfApp1.ViewModel;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for TeacherUpdateScore.xaml
    /// </summary>
    public partial class TeacherUpdateScore : Window
    {
        private readonly IMarkRepository _markRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;
        private readonly ISubjectRepository _subjectRepository;
        public TeacherUpdateScore()
        {
            InitializeComponent();
            InitializeComponent();
            _studentRepository = new StudentRepository();
            _markRepository = new MarkRepository();
            _classRepository = new ClassRepository();
            _subjectRepository = new SubjectRepository();
        }
        public void loadMarkList()
        {
            try
            {
                // Retrieve all marks from the repository
                var markList = _markRepository.GetallMarks();

                // Directly bind the markList to the DataGrid
                dgData.ItemsSource = markList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading data");
            }
            finally
            {
                resetInput();
            }
        }


        public void LoadClassList()
        {
            try
            {
                var list = _classRepository.GetClasses();
                cmbclass.ItemsSource = list;
                cmbclass.DisplayMemberPath = "NameClass";
                cmbclass.SelectedValuePath = "NameClass";

                // Set default selection to show "All Classes" if available
                cmbclass.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading classes: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void LoadSubjectList()
        {
            try
            {
                var list = _subjectRepository.GetAllSubjects();
                cmbSubject.ItemsSource = list;
                cmbSubject.DisplayMemberPath = "Idsubject";
                cmbSubject.SelectedValuePath = "Idsubject";

                // Set a default selection if necessary, without including an "All" option
                if (list.Any())
                {
                    cmbSubject.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading subjects: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadClassList();

            LoadSubjectList();
            loadMarkList();
        }
        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem == null)
                return;

            // Cast the selected item to the correct ViewModel
            StudentMarkViewModel selectedItem = dgData.SelectedItem as StudentMarkViewModel;

            if (selectedItem != null)
            {
                // Access the Student and Mark from the ViewModel
                Student selectedStudent = selectedItem.Student;
                Mark selectedMark = selectedItem.Mark;

                // Populate the input fields with data from the selected student's marks
                if (selectedStudent != null && selectedMark != null)
                {
                    // Access the student's name
                    txttudentID.Text = selectedStudent.Idstudent.ToString(); // Ensure this is correct
                    txtStudentclassName.Text = selectedMark.NameClass;
                    txtStudentPT1Score.Text = selectedMark.ProgressTest1.ToString();
                    txtStudentPT2Score.Text = selectedMark.ProgressTest2.ToString();
                    txtStudentLab1Score.Text = selectedMark.Lab1.ToString();
                    txtStudentLab2Score.Text = selectedMark.Lab2.ToString();
                    txtStudentFEScore.Text = selectedMark.FinalExam.ToString();
                    txtStudentPEScore.Text = selectedMark.PracticalExam.ToString();
                    txtStudentTotalScore.Text = selectedMark.Total.ToString();

                    // Display the student's name in the correct field
                    txtStudentName.Text = selectedStudent.Name; // Make sure you have a TextBox to display the student name
                }
            }
        }


        private void resetInput()
        {
            txttudentID.Clear();
            txtStudentclassName.Clear();
            txtStudentPT1Score.Clear();
            txtStudentPT2Score.Clear();
            txtStudentLab1Score.Clear();
            txtStudentLab2Score.Clear();
            txtStudentFEScore.Clear();
            txtStudentPEScore.Clear();
            txtStudentTotalScore.Clear(); // Ensure this is cleared as well.    
        }


        private void cmbsemester_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedSemester = (cmbsemester.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (!string.IsNullOrEmpty(selectedSemester))
            {
                try
                {
                    if (_markRepository == null) return;

                    if (selectedSemester == "Semester")
                    {
                        var allMarks = _markRepository.GetallMarks();
                        var combinedData = allMarks.Select(mark => new StudentMarkViewModel
                        {
                            Student = _studentRepository.GetStudentByID(mark.Idstudent),
                            Mark = mark
                        }).ToList();
                        dgData.ItemsSource = combinedData;
                    }
                    else
                    {
                        var filteredMarks = _markRepository.GetMarksBySemester(selectedSemester);
                        var combinedData = filteredMarks.Select(mark => new StudentMarkViewModel
                        {
                            Student = _studentRepository.GetStudentByID(mark.Idstudent),
                            Mark = mark
                        }).ToList();
                        dgData.ItemsSource = combinedData;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải dữ liệu học kỳ: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                dgData.ItemsSource = null;
            }
        }

        private void cmbClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedClass = cmbclass.SelectedValue as string;

            if (!string.IsNullOrEmpty(selectedClass))
            {
                try
                {
                    if (_markRepository == null || _studentRepository == null) return;

                    List<StudentMarkViewModel> combinedData;

                    if (selectedClass == "Class")
                    {
                        // Retrieve all marks when "Class" is selected
                        var allMarks = _markRepository.GetallMarks();
                        combinedData = allMarks.Select(mark => new StudentMarkViewModel
                        {
                            Student = _studentRepository.GetStudentByID(mark.Idstudent),
                            Mark = mark
                        }).ToList();
                    }
                    else
                    {
                        // Retrieve marks for the selected class only
                        var filteredMarks = _markRepository.GetMarksByClass(selectedClass);
                        combinedData = filteredMarks.Select(mark => new StudentMarkViewModel
                        {
                            Student = _studentRepository.GetStudentByID(mark.Idstudent),
                            Mark = mark
                        }).ToList();
                    }

                    dgData.ItemsSource = combinedData;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data for class '{selectedClass}': {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                // Clear DataGrid if no class is selected
                dgData.ItemsSource = null;
            }
        }
        private void cmbSubject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedSubject = cmbSubject.SelectedValue as string;

            if (!string.IsNullOrEmpty(selectedSubject))
            {
                try
                {
                    if (_markRepository == null || _studentRepository == null) return;

                    // Retrieve marks filtered by the selected subject
                    var filteredMarks = _markRepository.GetMarksBySubject(selectedSubject);
                    var combinedData = filteredMarks.Select(mark => new StudentMarkViewModel
                    {
                        Student = _studentRepository.GetStudentByID(mark.Idstudent),
                        Mark = mark
                    }).ToList();

                    dgData.ItemsSource = combinedData;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data for subject '{selectedSubject}': {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                dgData.ItemsSource = null;
            }
        }



        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var selectedSubject = cmbSubject.SelectedValue as string; // Retrieve the selected subject by its Idsubject
            var idStudent = txttudentID.Text;

            try
            {
                if (!string.IsNullOrEmpty(idStudent) && !string.IsNullOrEmpty(selectedSubject))
                {
                    // Ensure all text fields are properly filled in
                    Mark mark = new Mark
                    {
                        Idstudent = idStudent,
                        NameClass = txtStudentclassName.Text,
                        ProgressTest1 = float.TryParse(txtStudentPT1Score.Text, out float pt1) ? pt1 : 0f,
                        ProgressTest2 = float.TryParse(txtStudentPT2Score.Text, out float pt2) ? pt2 : 0f,
                        Lab1 = float.TryParse(txtStudentLab1Score.Text, out float lab1) ? lab1 : 0f,
                        Lab2 = float.TryParse(txtStudentLab2Score.Text, out float lab2) ? lab2 : 0f,
                        FinalExam = float.TryParse(txtStudentFEScore.Text, out float finalExam) ? finalExam : 0f,
                        PracticalExam = float.TryParse(txtStudentPEScore.Text, out float practicalExam) ? practicalExam : 0f,
                        Total = float.TryParse(txtStudentTotalScore.Text, out float total) ? total : 0f,
                        Idsubject = selectedSubject,
                        Semester = _markRepository.GetSemById(idStudent),
                        SchoolYear = _markRepository.GetSchoolYearById(idStudent)
                    };

                    // Update mark in the repository
                    _markRepository.Updatemark(mark);
                    MessageBox.Show("Student mark updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Please ensure all required fields are filled in.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Update Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }




        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txttudentID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtStudentName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtStudentPT1Score_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtStudentPT2Score_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtStudentLab1Score_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtStudentLab2Score_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtStudentFEScore_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtStudentPEScore_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtStudentTotalScore_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txttudentName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtStudentclassName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        // Window loaded event

    }
}
