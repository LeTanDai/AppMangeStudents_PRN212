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
        public TeacherUpdateScore()
        {
            InitializeComponent();
            _studentRepository = new StudentRepository();
            _markRepository = new MarkRepository();

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



            private void Window_Loaded(object sender, RoutedEventArgs e)
            {


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
                var selectedClass = (cmbclass.SelectedItem as ComboBoxItem)?.Content.ToString();

                if (!string.IsNullOrEmpty(selectedClass))
                {
                    try
                    {
                        if (_markRepository == null) return;

                        if (selectedClass == "Class")
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
                            var filteredMarks = _markRepository.GetMarksByClass(selectedClass);
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
                        MessageBox.Show($"Lỗi khi tải dữ liệu lớp học: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    dgData.ItemsSource = null;
                }
            }

            private void cmbSubject_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                var selectedSubject = (cmbSubject.SelectedItem as ComboBoxItem)?.Content.ToString();

                if (!string.IsNullOrEmpty(selectedSubject))
                {
                    try
                    {
                        if (_markRepository == null) return;

                        if (selectedSubject == "All")
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
                            var filteredMarks = _markRepository.GetMarksBySubject(selectedSubject);
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
                        MessageBox.Show($"Lỗi khi tải dữ liệu môn học: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    dgData.ItemsSource = null;
                }
            }



            private void btnUpdate_Click(object sender, RoutedEventArgs e)
            {

                var selectedsubject = (cmbSubject.SelectedItem as ComboBoxItem)?.Content.ToString();
                var idstudent = txttudentID.Text;
                try
                {
                    if (!string.IsNullOrEmpty(txttudentID.Text))
                    {
                        Mark mark = new Mark
                        {
                            Idstudent = txttudentID.Text,
                            NameClass = txtStudentclassName.Text,
                            ProgressTest1 = Convert.ToSingle(txtStudentPT1Score.Text),
                            ProgressTest2 = Convert.ToSingle(txtStudentPT2Score.Text),
                            Lab1 = Convert.ToSingle(txtStudentLab1Score.Text),
                            Lab2 = Convert.ToSingle(txtStudentLab2Score.Text),
                            FinalExam = Convert.ToSingle(txtStudentFEScore.Text),
                            PracticalExam = Convert.ToSingle(txtStudentPEScore.Text),
                            Total = Convert.ToSingle(txtStudentTotalScore.Text),
                            Idsubject = selectedsubject,
                            Semester = _markRepository.GetSemById(idstudent),
                            SchoolYear = _markRepository.GetSchoolYearById(idstudent)
                        };

                        _markRepository.Updatemark(mark);
                        MessageBox.Show("Student mark updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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

