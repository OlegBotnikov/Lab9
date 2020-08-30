using Lab9.BusinessLayer.Interfaces;
using Lab9.BusinessLayer.Models;
using Lab9.BusinessLayer.Services;
using Lab9.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Lab9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<GroupViewModel> groups;
        IGroupService groupService;
        public MainWindow()
        {
            InitializeComponent();
            groupService = new GroupService("CoursesContext");
            groups = groupService.GetAll();
            cBoxGroup.DataContext = groups;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var student = new StudentViewModel();
            student.DateOfBirth = new DateTime(1990, 01, 01);
            var dialog = new EditStudent(student);
            var result = dialog.ShowDialog();
            if (result == true)
            {
                var group = (GroupViewModel)cBoxGroup.SelectedItem;
                group.Students.Add(student);
                groupService.AddStudentToGroup(group.GroupId, student);
                dialog.Close();
            }
        }

        private void TextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            GroupViewModel groupViewModel = new GroupViewModel();
            groupViewModel.Commence = new DateTime(1990, 01, 01);
            EditGroup dialog = new EditGroup(groupViewModel);
            var result = dialog.ShowDialog();
            if (result == true)
                groupService.CreateGroup(groupViewModel);
            groups = groupService.GetAll();
            cBoxGroup.DataContext = groups;
        }

        private void CBoxGroup_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Delete)
            {// удаление по клавише delete
                if (cBoxGroup.SelectedIndex > -1)
                {
                    groupService.DeleteGroup((cBoxGroup.SelectedItem as GroupViewModel).GroupId);
                    groups = groupService.GetAll();     // для обновления окна
                    cBoxGroup.DataContext = groups;     // для обновления окна
                    cBoxGroup.SelectedIndex = 0;
                }
            }
        }

        private void ListBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Delete)
            {// удаление по клавише delete
                if (listBox.SelectedIndex > -1)
                {
                    int si = cBoxGroup.SelectedIndex;
                    GroupViewModel groupViewModel = cBoxGroup.SelectedItem as GroupViewModel;
                    StudentViewModel studentViewModel = listBox.SelectedItem as StudentViewModel;

                    groupService.RemoveStudentFromGroup(groupViewModel.GroupId, studentViewModel.StudentId);
                    groups = groupService.GetAll();     // для обновления окна
                    cBoxGroup.DataContext = groups;     // для обновления окна
                    cBoxGroup.SelectedIndex = si;        // для обновления окна

                }
            }
            if (e.Key == System.Windows.Input.Key.Insert)
            {// обновление по клавише Insert
                // не работает
                if (cBoxGroup.SelectedIndex > -1)
                {
                    GroupViewModel groupViewModel = cBoxGroup.SelectedItem as GroupViewModel;
                    EditGroup dialog = new EditGroup(groupViewModel);
                    var result = dialog.ShowDialog();
                    if (result == true)
                        groupService.UpdateGroup(groupViewModel);
                    groups = groupService.GetAll();
                    cBoxGroup.DataContext = groups;
                }
            }
            if (e.Key == System.Windows.Input.Key.Insert)
            {// обновление по клавише Insert
                // не работает
                if (listBox.SelectedIndex > -1)
                {
                    StudentViewModel studentViewModel = listBox.SelectedItem as StudentViewModel;
                    var dialog = new EditStudent(studentViewModel);
                    var result = dialog.ShowDialog();
                    if (result == true)
                    {
                        groupService.UpdateStudent(studentViewModel);
                        dialog.Close();
                    }

                }
            }

        }
    }
}
