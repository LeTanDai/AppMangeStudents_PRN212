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
    /// Interaction logic for ManageAssignAdmin.xaml
    /// </summary>
    public partial class ManageAssignAdmin : Window
    {
        private readonly Admin currentAdmin;
        private readonly IAssignRepository _assignRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IClassRepository _classRepository;
        private readonly ITeacherSubjectRepository _teacherSubjectRepository;
        public ManageAssignAdmin(Admin admin)
        {
            InitializeComponent();
            _assignRepository = new AssignRepository();
            _teacherRepository = new TeacherRepository();
            _classRepository = new ClassRepository();
            _teacherSubjectRepository = new TeacherSubjectRepository();
            currentAdmin = admin;
        }
        public void LoadList()
        {
            try
            {
                var assignList = _assignRepository.GetAllAssigns();
                dgData.ItemsSource = assignList;
                var classList = _assignRepository.GetAllAssigns().Select(c => c.NameClass).Distinct().ToList();
                cboClass.ItemsSource = classList;
                var teacherList = _assignRepository.GetAllAssigns().Select(c => c.TeacherSubject.Idteacher).Distinct().Order().ToList();
                cboTeacher.ItemsSource = teacherList;
                var subjectList = _assignRepository.GetAllAssigns().Select(c => c.TeacherSubject.Idsubject).Distinct().ToList();
                cboSubject.ItemsSource = subjectList;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error on load list of classes");
            }
            finally
            {
                resetInput();
            }
        }

        private void resetInput()
        {
            txtAssignId.Text = "";
            cboClass.SelectedValue = "";
            txtYear.Text = "";
            cboSubject.SelectedValue = "";
            cboTeacher.SelectedValue = "";
        }

        private void Btn_MngAssign(object sender, RoutedEventArgs e)
        {

        }

        private void btn_MngStudent(object sender, RoutedEventArgs e)
        {
            this.Close();     
            ManageStudentAdmin admin = new ManageStudentAdmin(currentAdmin);
            admin.Show();
        }

        private void Btn_MngTeacher(object sender, RoutedEventArgs e)
        {
            this.Close();
            ManageTeacherAdmin admin = new ManageTeacherAdmin(currentAdmin);
            admin.Show();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem == null)
                return;
            Assign? selectedAssign = dgData.SelectedItem as Assign;
            if (selectedAssign != null)
            {
                if (selectedAssign.AssignId != 0)
                {
                    txtAssignId.Text = selectedAssign.AssignId.ToString();
                }
                if (selectedAssign.NameClass != null)
                {
                    cboClass.SelectedValue = selectedAssign.NameClass;
                }
                if (selectedAssign.SchoolYear != null)
                {
                    txtYear.Text = selectedAssign.SchoolYear.ToString();
                }
                if (selectedAssign.Idteacher != null)
                {
                    cboTeacher.SelectedValue = selectedAssign.Idteacher;
                }
                if (selectedAssign.Idsubject != null)
                {
                    cboSubject.SelectedValue = selectedAssign.Idsubject;
                }

            }
        }

        private void btnAddClass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_teacherSubjectRepository.GetTeacherSubjectById(cboTeacher.SelectedValue.ToString(), cboSubject.SelectedValue.ToString()) == null)
                {
                    TeacherSubject ts = new TeacherSubject
                    {
                        Idteacher = cboTeacher.SelectedValue.ToString(),
                        Idsubject = cboSubject.SelectedValue.ToString()
                    };
                    _teacherSubjectRepository.CreateTeacherSubject(ts);
                }

                if (_classRepository.GetClass(cboClass.SelectedValue.ToString(), txtYear.Text) == null)
                {
                    Class c = new Class
                    {
                        NameClass = cboClass.SelectedValue.ToString(),
                        SchoolYear = txtYear.Text,
                    };
                    _classRepository.CreateClass(c);
                }

                Assign assign = new Assign
                {
                    NameClass = cboClass.SelectedValue.ToString(),
                    Idsubject = cboSubject.SelectedValue.ToString(),
                    Idteacher = cboTeacher.SelectedValue.ToString(),
                    SchoolYear = txtYear.Text
                };
                _assignRepository.CreateAssign(assign);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                LoadList();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtAssignId.Text.Length > 0)
                {
                    if (_teacherSubjectRepository.GetTeacherSubjectById(cboTeacher.SelectedValue.ToString(), cboSubject.SelectedValue.ToString()) == null)
                    {
                        TeacherSubject ts = new TeacherSubject
                        {
                            Idteacher = cboTeacher.SelectedValue.ToString(),
                            Idsubject = cboSubject.SelectedValue.ToString()
                        };
                        _teacherSubjectRepository.CreateTeacherSubject(ts);
                    }

                    if (_classRepository.GetClass(cboClass.SelectedValue.ToString(), txtYear.Text) == null)
                    {
                        Class c = new Class
                        {
                            NameClass = cboClass.SelectedValue.ToString(),
                            SchoolYear = txtYear.Text,
                        };
                        _classRepository.CreateClass(c);
                    }

                    Assign assign = new Assign
                    {
                        AssignId = Int32.Parse(txtAssignId.Text),
                        NameClass = cboClass.SelectedValue.ToString(),
                        Idsubject = cboSubject.SelectedValue.ToString(),
                        Idteacher = cboTeacher.SelectedValue.ToString(),
                        SchoolYear = txtYear.Text,
                    };
                    _assignRepository.UpdateAssign(assign);
                }
                else
                {
                    MessageBox.Show("You must select an assign");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                LoadList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtAssignId.Text.Length > 0)
                {
                    Assign assign = new Assign
                    {
                        AssignId = Int32.Parse(txtAssignId.Text),
                    };
                    _assignRepository.DeleteAssign(assign);
                }
                else
                {
                    MessageBox.Show("You must select an assign");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                LoadList();
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadList();
        }



        private void chooseTeacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Btn_MngClass(object sender, RoutedEventArgs e)
        {
            this.Close();
            ManageClassAdmin admin  = new ManageClassAdmin(currentAdmin);   
            admin.Show();
        }

        private void Btn_MngSubject(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ManageSubjectAdmin manageSubjectAdmin = new ManageSubjectAdmin(currentAdmin);
            manageSubjectAdmin.Show();
        }

        private void Btn_Info(object sender, RoutedEventArgs e)
        {
            this.Close();
            AdminInformation admin = new AdminInformation(currentAdmin);
            admin.Show();
        }
    }
}
