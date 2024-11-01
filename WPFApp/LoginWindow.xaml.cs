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
        public LoginWindow()
        {
            InitializeComponent();
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
            // Xử lý logic đăng nhập tại đây
            MessageBox.Show("Đăng nhập thành công!");
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            // Xử lý logic đăng ký tại đây
            MessageBox.Show("Đăng ký thành công!");
        }
    }
}
