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
    public partial class ManageTeacherAdmin : Window
    {
        private readonly ITeacherService iTeacherService;

        public ManageTeacherAdmin()
        {
            InitializeComponent();
            iTeacherService = new TeacherService();
            if(iTeacherService == null)
            {
                MessageBox.Show("Service is null");
            }
        }

        private void LoadTeacherList()
        {
            try
            {
                var teacherList = iTeacherService.GetTeachers();
                dgData.ItemsSource = teacherList;
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
            LoadTeacherList();
        }

        private void resetInput()
        {
            txtTeacherID.Text = "";
            txtTeacheName.Text = "";
            cbxGender.SelectedIndex = -1;
            txtEmail.Text = "";
            txtPhone.Text = "";
            dpTeacherBirthday.SelectedDate = null;
            cbxIsActive.SelectedIndex = -1;
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem == null)
                return;

            Teacher? selectedTeacher = dgData.SelectedItem as Teacher;
            if (selectedTeacher != null)
            {
                txtTeacherID.Text = selectedTeacher.Idteacher?.ToString() ?? string.Empty;

                // Kiểm tra tên có null không
                txtTeacheName.Text = selectedTeacher.Name ?? string.Empty;

                // Kiểm tra giới tính có null không
                if (selectedTeacher.Gender != null)
                {
                    cbxGender.SelectedItem = cbxGender.Items
                        .OfType<ComboBoxItem>()
                        .FirstOrDefault(item => item.Content.ToString() == selectedTeacher.Gender);
                }
                else
                {
                    cbxGender.SelectedIndex = -1; // Đặt lại nếu null
                }

                // Kiểm tra email có null không
                txtEmail.Text = selectedTeacher.Email ?? string.Empty;

                // Kiểm tra số điện thoại có null không
                txtPhone.Text = selectedTeacher.Phone ?? string.Empty;

                // Kiểm tra ngày sinh có null không
                dpTeacherBirthday.SelectedDate = selectedTeacher.BirthDay?.ToDateTime(TimeOnly.MinValue);

                // Kiểm tra trạng thái hoạt động
                if (selectedTeacher.IsActive != null)
                {
                    cbxIsActive.SelectedItem = cbxIsActive.Items
                        .OfType<ComboBoxItem>()
                        .FirstOrDefault(item => item.Content.ToString() == (selectedTeacher.IsActive == "Y" ? "Y" : "N"));
                }
                else
                {
                    cbxIsActive.SelectedIndex = -1; // Đặt lại nếu null
                }
            }
        }




        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Teacher teacher = iTeacherService.GetTeacherByID(txtTeacherID.Text);
                iTeacherService.DeleteTeacher(teacher);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Delete Teacher", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                LoadTeacherList();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTeacherID.Text))
                {
                    MessageBox.Show("You must select a Teacher!");
                    return;
                }

                Teacher teacher = new Teacher
                {
                    Idteacher = txtTeacherID.Text,
                    Name = string.IsNullOrEmpty(txtTeacheName.Text) ? null : txtTeacheName.Text,
                    Gender = cbxGender.SelectedItem is ComboBoxItem selectedGender ? selectedGender.Content.ToString() : null,
                    Email = string.IsNullOrEmpty(txtEmail.Text) ? null : txtEmail.Text,
                    Phone = string.IsNullOrEmpty(txtPhone.Text) ? null : txtPhone.Text,
                    BirthDay = dpTeacherBirthday.SelectedDate.HasValue ? DateOnly.FromDateTime(dpTeacherBirthday.SelectedDate.Value) : null,
                    IsActive = cbxIsActive.SelectedItem is ComboBoxItem selectedActive ? selectedActive.Content.ToString() : null
                };

                iTeacherService.UpdateTeacher(teacher);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Updating Teacher", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                LoadTeacherList();
            }
        }
    }
}
