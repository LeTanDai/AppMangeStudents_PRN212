using BusinessObjects.Models;
using Repositories;
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
        private readonly IAdminService iAdminService;
        private readonly IStudentService iStudentService;
        private readonly ITeacherService iTeacherService;
        public LoginWindow()
        {
            InitializeComponent();
            iAdminService = new AdminService();
            iStudentService = new StudentService();
            iTeacherService = new TeacherService();
            cbxTypeAccount.SelectedIndex = 0;
            cbxTypeAccountSignUp.SelectedIndex = 0;
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
                Admin? admin = iAdminService.GetAdminByID(id);
                if(admin!=null && admin.PassWord == password)
                {
                    
                    this.Hide();
                    ManageClassAdmin manageTeacherAdmin = new ManageClassAdmin();
                    manageTeacherAdmin.Show();
                    return;
                }
                else
                {
                    MessageBox.Show("Wrong admin account!");
                }
            } else if (type.Equals("Student"))
            {
                Student? student = iStudentService.GetStudentByID(id);
                if (student != null && student.PassWord == password)
                {
                    
                    this.Hide();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    return;
                }
                else
                {
                    MessageBox.Show("Wrong student account!");
                }
            } else if (type.Equals("Teacher"))
            {
                Teacher? teacher = iTeacherService.GetTeacherByID(id);
                if (teacher != null && teacher.PassWord == password)
                {
                    
                    this.Hide();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    return;
                }
                else
                {
                    MessageBox.Show("Wrong teacher account!");
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
                Student? existingStudent = iStudentService.GetStudentByID(id);
                if (existingStudent != null)
                {
                    MessageBox.Show("ID already exist. Please use different ID!", "Notification", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }else if(txtPasswordSignUp.Password == txtPasswordSignUpCheck.Password)
                {
                    iStudentService.Register(txtAccountSignUp.Text, txtPasswordSignUp.Password);
                    MessageBox.Show("Sign Up Successfully!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Hide();
                    LoginWindow loginWindow = new LoginWindow();
                    loginWindow.Show();
                    return;
                }
            }
            else if (type.Equals("Teacher"))
            {
                Teacher? existingTeacher = iTeacherService.GetTeacherByID(id);
                if (existingTeacher != null)
                {
                    MessageBox.Show("ID already exist. Please use different ID!", "Notification", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                else if (txtPasswordSignUp.Password == txtPasswordSignUpCheck.Password)
                {
                    iTeacherService.Register(txtAccountSignUp.Text, txtPasswordSignUp.Password);
                    MessageBox.Show("Sign Up Successfully!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Hide();
                    LoginWindow loginWindow = new LoginWindow();
                    loginWindow.Show();
                    return;
                }
            }
        }

        
    }
}
