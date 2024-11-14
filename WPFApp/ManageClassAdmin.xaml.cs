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
    /// Interaction logic for ManageClassAdmin.xaml
    /// </summary>
    public partial class ManageClassAdmin : Window
    {
        private readonly IClassService iClassService;
        private Class? selectedClass;
        private Admin admin = new Admin();
        public ManageClassAdmin(Admin admin)
        {
            InitializeComponent();
            iClassService = new ClassService();
            this.admin = admin;
            if (iClassService == null)
            {
                MessageBox.Show("Service is null");
            }

            this.admin = admin;
        }

        private void LoadClassList()
        {
            try
            {
                var classList = iClassService.GetClasses();
                dgData.ItemsSource = classList;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadClassList();
        }

        private void resetInput()
        {
            txtClassName.Text = "";
            txtSchoolYear.Text = ""; 
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem == null)
                return;

            selectedClass = dgData.SelectedItem as Class;
            if (selectedClass != null)
            {
                txtClassName.Text = selectedClass.NameClass.ToString();
                txtSchoolYear.Text = selectedClass.SchoolYear.ToString();
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class cl = new Class
                {
                    NameClass = txtClassName.Text,
                    SchoolYear = txtSchoolYear.Text,
                };
                iClassService.CreateClass(cl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Create Class", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                LoadClassList();
            }
        }

        

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class cl = new Class
                {
                    NameClass = txtClassName.Text,
                    SchoolYear = txtSchoolYear.Text,
                };
                iClassService.DeleteClass(cl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Delete Class", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                LoadClassList();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnEditClass_Click(object sender, RoutedEventArgs e)
        {
            Class cl = selectedClass;
            WindowListStudentByClass window = new WindowListStudentByClass(cl);
            window.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminInformation adminInformation = new AdminInformation(admin);
            this.Hide();
            adminInformation.Show();
        }
    }
}
