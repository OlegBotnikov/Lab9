using Lab9.BusinessLayer.Models;
using System.Windows;


namespace Lab9.Dialogs
{
    public partial class EditStudent : Window
    {
        StudentViewModel studentViewModel;
        public EditStudent(StudentViewModel studentViewModel)
        {
            InitializeComponent();
            this.studentViewModel = studentViewModel;
            grid.DataContext = studentViewModel;

        }
        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(studentViewModel.FileName + " " + studentViewModel.DateOfBirth);
            this.DialogResult = true;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
