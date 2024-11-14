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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IAdminRepository adminRepository;
        private readonly IStudentRepository studentRepository;
        private readonly ITeacherRepository teacherRepository;
        public LoginWindow()
        {
            InitializeComponent();
            adminRepository = new AdminRepository();
            studentRepository = new StudentRepository();
            teacherRepository = new TeacherRepository();
            cbxTypeAccount.SelectedIndex = 0;
            cbxTypeAccountSignUp.SelectedIndex = 0;
            if (Properties.Settings.Default.RememberMe)
            {
                txtAccountID.Text = Properties.Settings.Default.ID;
                txtPassword.Password = Properties.Settings.Default.Password; // Cẩn thận với việc hiển thị mật khẩu
                chkRememberMe.IsChecked = true;
            }
        }

        private void ShowSignUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SignInPanel.Visibility = Visibility.Collapsed;
            SignUpPanel.Visibility = Visibility.Visible;
            SignUpPanel.BeginStoryboard((Storyboard)FindResource("FadeIn"));
        }

        private void ShowSignIn(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SignUpPanel.Visibility = Visibility.Collapsed;
            SignInPanel.Visibility = Visibility.Visible;
            SignInPanel.BeginStoryboard((Storyboard)FindResource("FadeIn"));
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string id = txtAccountID.Text;
            string password = txtPassword.Password;
            string type = cbxTypeAccount.Text;

            if (type.Equals("Admin")){
                Admin? admin = adminRepository.GetAdminByID(id);
                if(admin!=null && admin.PassWord == password)
                {
                    SaveLoginInfo(id, password);
                    this.Hide();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    return;
                }
            } else if (type.Equals("Student"))
            {
                Student? student = studentRepository.GetStudentByID(id);
                if (student != null && student.PassWord == password)
                {
                    SaveLoginInfo(id, password);
                    this.Hide();
                    StudentInformation studentInformation = new StudentInformation(id);
                    studentInformation.Show();
                    return;
                }
            } else if (type.Equals("Teacher"))
            {
                Teacher? teacher = teacherRepository.GetTeacherByID(id);
                if (teacher != null && teacher.PassWord == password)
                {
                    SaveLoginInfo(id, password);
                    this.Hide();
                    TeacherInformation teacherInformation = new TeacherInformation(id);
                    teacherInformation.Show();
                    return;
                }
            }
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            string id = txtAccountSignUp.Text;
            string password = txtPasswordSignUp.Password;
            string checkPass = txtPasswordSignUpCheck.Password;
            string type = cbxTypeAccountSignUp.Text;

            if (type.Equals("Student"))
            {
                Student? existingStudent = studentRepository.GetStudentByID(id);
                if (existingStudent != null)
                {
                    MessageBox.Show("ID already exist. Please use different ID!", "Notification", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                Student newStudent = new Student { Idstudent = id, PassWord = password };
                studentRepository.CreateStudent(newStudent); 
                MessageBox.Show("Sign Up Successfully!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                return;
            }
            else if (type.Equals("Teacher"))
            {
                Teacher? existingTeacher = teacherRepository.GetTeacherByID(id);
                if (existingTeacher != null)
                {
                    MessageBox.Show("Tài khoản đã tồn tại. Vui lòng chọn ID khác.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                Teacher newTeacher = new Teacher { Idteacher = id, PassWord = password };
                teacherRepository.CreateTeacher(newTeacher); 
                MessageBox.Show("Sign Up Successfully!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                return;
            }
        }

        private void SaveLoginInfo(string id, string password)
        {
            //if (chkRememberMe.IsChecked == true)
            //{
            //    Properties.Settings.Default.ID = id;
            //    Properties.Settings.Default.Password = password; 
            //    Properties.Settings.Default.RememberMe = true;
            //}
            //else
            //{
            //    Properties.Settings.Default.ID = string.Empty;
            //    Properties.Settings.Default.Password = string.Empty;
            //    Properties.Settings.Default.RememberMe = false;
            //}
            //Properties.Settings.Default.Save(); 
        }
    }
}
