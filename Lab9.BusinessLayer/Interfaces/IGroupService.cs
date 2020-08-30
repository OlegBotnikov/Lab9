using Lab9.BusinessLayer.Models;
using System.Collections.ObjectModel;


namespace Lab9.BusinessLayer.Interfaces
{
    public interface IGroupService
    {
        ObservableCollection<GroupViewModel> GetAll();
        GroupViewModel Get(int id);
        void AddStudentToGroup(int droupId, StudentViewModel student);
        void RemoveStudentFromGroup(int droupId, int studentId);
        void CreateGroup(GroupViewModel group);
        void DeleteGroup(int groupId);
        void UpdateGroup(GroupViewModel group);
        void UpdateStudent(StudentViewModel studentViewModel);
    }
}
