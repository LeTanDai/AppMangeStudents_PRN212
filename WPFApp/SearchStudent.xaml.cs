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
    /// Interaction logic for SearchStudent.xaml
    /// </summary>
    public partial class SearchStudent : Window
    {
        private readonly IStudentService _studentService;
        private readonly IStudentClassService _studentClassService;
        private readonly Teacher teach;
        public SearchStudent(Teacher teacher)
        {
            InitializeComponent();
            _studentService = new StudentService();
            _studentClassService = new StudentClassService();
            this.teach = teacher;
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
                fullname_st_infor.Content = selectedStudent.Name;
                birthofday_st_infor.Content = selectedStudent.BirthDay.HasValue ? selectedStudent.BirthDay.Value.ToDateTime(TimeOnly.MinValue) : null;
                email_st_infor.Content = selectedStudent.Email;
                gender_st_infor.Content = selectedStudent.Gender;
                phone_st_infor.Content = selectedStudent.Phone;

                var studentClass = selectedStudent.StudentClasses.FirstOrDefault();
                if (studentClass != null)
                {
                    nameclass_st_infor.Content = studentClass.NameClass;
                    yearSchool_st_infor.Content = studentClass.SchoolYear;
                }
                else
                {
                    nameclass_st_infor.Content = "No class available";
                    yearSchool_st_infor.Content = "No year available";
                }
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

            fullname_st_infor.Content = "Select student to view";
            birthofday_st_infor.Content = "Select student to view";
            email_st_infor.Content = "Select student to view";
            gender_st_infor.Content = "Select student to view";
            phone_st_infor.Content = "Select student to view";
            nameclass_st_infor.Content = "Select student to view";
            yearSchool_st_infor.Content = "Select student to view";

            var students = SearchStudentsByCriteria(string.Empty, null, null);
            listviewStudent.ItemsSource = null;
            listviewStudent.ItemsSource = students;
        }

        private void btn_Return_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            TeacherInformation teacher = new TeacherInformation(teach);
            teacher.Show();
        }
    }
}
