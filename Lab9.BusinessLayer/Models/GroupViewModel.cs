using System;
using System.Collections.ObjectModel;

namespace Lab9.BusinessLayer.Models
{
    public class GroupViewModel
    {
        public int GroupId { get; set; }
        public string CourseName { get; set; }
        public DateTime Commence { get; set; }
        public decimal BasePrice { get; set; }
        public ObservableCollection<StudentViewModel> Students
        { get; set; }
    }
}
