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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class TeacherInformation : Window
    {
        private readonly ITeacherRepository repository;
        private readonly Teacher teach;
        public TeacherInformation( String id )
        {
            repository = new TeacherRepository();
            teach = repository.GetTeacherByID(id);
            InitializeComponent();
        }
        private void Window_Loaded( object sender, RoutedEventArgs e )
        {
            teachername.Text = teach.Name.ToString();
            teacherid.Text = teach.Idteacher.ToString();
            teacherdob.Text = teach.BirthDay.ToString();
            teachergender.Text = teach.Gender.ToString();
            teacheremail.Text = teach.Email.ToString();
            teacherphone.Text = teach.Phone.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_click(object sender, RoutedEventArgs e)
        {
            EditTeacherInformation editTeacherInformation = new EditTeacherInformation(teach.Idteacher);
            this.Hide();
            editTeacherInformation.Show();
        }

        private void btnCancel_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
