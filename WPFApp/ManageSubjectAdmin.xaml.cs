using BusinessObjects.Models;
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

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for ManageSubjectAdmin.xaml
    /// </summary>
    public partial class ManageSubjectAdmin : Window
    {
        private readonly ISubjectRepository subjectRepository;
        private readonly Admin currentAdmin;
        public ManageSubjectAdmin(Admin admin)
        {
            InitializeComponent();
            subjectRepository = new SubjectRepository();
            currentAdmin = admin;
        }
        public void LoadAllSubject()
        {
            try
            {
                var subjectList = subjectRepository.GetAllSubjects();
                dgData.ItemsSource = subjectList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        private void Btn_MngAssign(object sender, RoutedEventArgs e)
        {
            this.Close();
            ManageAssignAdmin manageAssignAdmin = new ManageAssignAdmin(currentAdmin);
            manageAssignAdmin.Show();
        }

        private void btn_MngStudent(object sender, RoutedEventArgs e)
        {
            this.Close();
            ManageStudentAdmin man = new ManageStudentAdmin(currentAdmin);
            man.Show();
        }

        private void Btn_MngTeacher(object sender, RoutedEventArgs e)
        {
            this.Close();
            ManageTeacherAdmin admin   = new ManageTeacherAdmin(currentAdmin);
            admin.Show();
        }

        private void Btn_MngClass(object sender, RoutedEventArgs e)
        {
            this.Close();
            ManageClassAdmin admin = new ManageClassAdmin(currentAdmin);
            admin.Show();
        }

        private void Btn_MngSubject(object sender, RoutedEventArgs e)
        {

        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem == null)
                return;
            Subject? selectedAssign = dgData.SelectedItem as Subject;
            if (selectedAssign != null)
            {
                if (selectedAssign.Idsubject != null)
                {
                    txtSubjectId.Text = selectedAssign.Idsubject.ToString();
                }
                if (selectedAssign.NameSubject != null)
                {
                    txtSubjectName.Text = selectedAssign.NameSubject.ToString();
                }
            }
        }

        private void btnAddClass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (subjectRepository.GetSubject(txtSubjectId.Text) == null)
                {
                    Subject subject = new Subject
                    {
                        Idsubject = txtSubjectId.Text,
                        NameSubject = txtSubjectName.Text,
                    };
                    subjectRepository.AddSubject(subject);
                }
                else
                {
                    MessageBox.Show("Subject already exist!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadAllSubject();
            }
        }

        private void resetInput()
        {
            txtSubjectId.Text = "";
            txtSubjectName.Text = "";
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSubjectId.Text))
                {
                    Subject subject = subjectRepository.GetSubject(txtSubjectId.Text);

                    if (subject != null)
                    {
                        subject.Idsubject = txtSubjectId.Text;
                        subject.NameSubject = txtSubjectName.Text;
                        subjectRepository.UpdateSubject(subject);
                    };
                }
                else
                {
                    MessageBox.Show("You must select a subject!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadAllSubject();
                resetInput();
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAllSubject();
        }

        private void Btn_Info(object sender, RoutedEventArgs e)
        {
            this.Close();
            AdminInformation admin = new AdminInformation(currentAdmin);
            admin.Show();
        }
    }
}
