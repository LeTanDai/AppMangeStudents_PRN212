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
    /// Interaction logic for TeacherManageStudent.xaml
    /// </summary>
    public partial class TeacherManageStudent : Window
    {
        private readonly IStudentService _studentService;
        private readonly IStudentClassService _studentClassService;
        private readonly Teacher currentTeacher;
        public TeacherManageStudent(Teacher teacher)
        {
            InitializeComponent();
            _studentService = new StudentService();
            _studentClassService = new StudentClassService();
            currentTeacher = teacher;
        }
            private void Window_Loaded_Student(object sender, RoutedEventArgs e)
            {
                LoadClasses();
                LoadYears();
                LoadStudents();
            }

            private void LoadClasses()
            {
                var classes = _studentClassService.GetAllStudentClasses()
                                .Select(sc => sc.NameClass)
                                .Distinct()
                                .OrderBy(classes => classes)
                                .ToList();
                chooseClass.ItemsSource = classes;
            }

            private void LoadYears()
            {
                var years = _studentClassService.GetAllStudentClasses()
                               .Select(sc => sc.SchoolYear)
                               .Distinct()
                               .OrderBy(years => years)
                               .ToList();

                chooseYear.ItemsSource = years;
            }

            private void LoadStudents()
            {
                var students = _studentService.GetAllStudent();
                listviewStudent.ItemsSource = null;
                listviewStudent.ItemsSource = students;
            }

            private void SearchUser_TextChanged(object sender, TextChangedEventArgs e)
            {
                SearchStudents();
            }

            private void Btn_Search_Click(object sender, RoutedEventArgs e)
            {
                SearchStudents();
            }

            private IEnumerable<Student> SearchStudentsByCriteria(string searchText, string selectedClass, string selectedYear)
            {
                if (_studentService == null)
                {
                    MessageBox.Show("Student service is not initialized.");
                    return new List<Student>();
                }
                var res = _studentService.GetAllStudent();
                if (!string.IsNullOrEmpty(searchText))
                {
                    res = res.Where(s => s.Name.ToLower().Contains(searchText.ToLower()) || s.Idstudent.Contains(searchText));
                }
                if (!string.IsNullOrEmpty(selectedClass))
                {
                    res = res.Where(s => s.StudentClasses.Any(sc => sc.NameClass == selectedClass));
                }
                if (!string.IsNullOrEmpty(selectedYear))
                {
                    res = res.Where(s => s.StudentClasses.Any(sc => sc.SchoolYear == selectedYear));
                }

                return res;
            }
            private void SearchStudents()
            {
                string searchText = searchUser.Text.ToLower().Trim();
                string? selectedClass = chooseClass.SelectedItem?.ToString();
                string? selectedYear = chooseYear.SelectedItem?.ToString();

                var students = SearchStudentsByCriteria(searchText, selectedClass, selectedYear);
                listviewStudent.ItemsSource = null;
                listviewStudent.ItemsSource = students;
            }

            private void ResetInput()
            {
            }

            private void ComboBox_Classes_Loaded(object sender, RoutedEventArgs e)
            {
                LoadClasses();
            }

            private void ComboBox_Years_Loaded(object sender, RoutedEventArgs e)
            {
                LoadYears();
            }

            private void ChooseClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                SearchStudents();
            }

            private void ChooseYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                SearchStudents();
            }

            private void ListViewStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (listviewStudent.SelectedItem is Student selectedStudent)
                {
                    fullname_st_infor.Text = selectedStudent.Name;
                    birthofday_st_infor.SelectedDate = selectedStudent.BirthDay.HasValue ? selectedStudent.BirthDay.Value.ToDateTime(TimeOnly.MinValue) : null;
                    email_st_infor.Text = selectedStudent.Email;
                    gender_st_infor.Text = selectedStudent.Gender;
                    phone_st_infor.Text = selectedStudent.Phone;
                }
            }

            private void btn_Reload_Click(object sender, RoutedEventArgs e)
            {
                resetInput();
            }

            private void resetInput()
            {
                searchUser.Text = string.Empty;

                chooseClass.SelectedItem = null;
                chooseYear.SelectedItem = null;

                fullname_st_infor.Text = "";
                birthofday_st_infor.SelectedDate = null;
                email_st_infor.Text = "";
                gender_st_infor.Text = "";
                phone_st_infor.Text = "";

                var students = SearchStudentsByCriteria(string.Empty, null, null);
                listviewStudent.ItemsSource = null;
                listviewStudent.ItemsSource = students;
            }

            private void btn_Edit_Click(object sender, RoutedEventArgs e)
            {
                if (listviewStudent.SelectedItem is Student selectedStudent)
                {
                    var updatedStudent = new Student
                    {
                        Idstudent = selectedStudent.Idstudent,
                        Name = fullname_st_infor.Text,
                        BirthDay = birthofday_st_infor.SelectedDate.HasValue ? DateOnly.FromDateTime(birthofday_st_infor.SelectedDate.Value) : null,

                        Email = email_st_infor.Text,
                        Gender = gender_st_infor.Text,
                        Phone = phone_st_infor.Text
                    };
                    _studentService.UpdateStudent(updatedStudent);
                    MessageBox.Show("Student information updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadStudents();
                }
                else
                {
                    MessageBox.Show("Please select a student to edit.");
                }
            }

            private void btn_Delete_Click(object sender, RoutedEventArgs e)
            {
                if (listviewStudent.SelectedItem is Student selectedStudent)
                {
                    var result = MessageBox.Show("Are you sure you want to delete this student?", "Confirm Delete", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        _studentService.DeleteStudent(selectedStudent);
                        MessageBox.Show("Student deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadStudents();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a student to delete.");
                }
            }

            private void btn_Add_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    Student s = new Student
                    {
                        Name = fullname_st_infor.Text,
                        BirthDay = birthofday_st_infor.SelectedDate.HasValue ? DateOnly.FromDateTime(birthofday_st_infor.SelectedDate.Value) : null,
                        Email = email_st_infor.Text,
                        Gender = gender_st_infor.Text,
                        Phone = phone_st_infor.Text
                    };
                    if (string.IsNullOrEmpty(s.PassWord))
                    {
                        s.PassWord = "123";
                    }
                    _studentService.CreateStudent(s);
                    MessageBox.Show("Student add successfully", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    LoadStudents();
                }
            }

        private void Btn_Return_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            TeacherInformation teacherInformation = new TeacherInformation(currentTeacher);
            teacherInformation.Show();
        }
    }
}
