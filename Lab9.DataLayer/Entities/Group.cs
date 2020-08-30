using System;
using System.Collections.Generic;

namespace Lab9.DataLayer.Entities
{
    public class Group
    {
        public Group()
        {
            Students = new List<Student>();
        }
        public int GroupId { get; set; }            // ключ
        public string CourseName { get; set; }      // название курса
        public DateTime Commence { get; set; }      // дата начала
        public decimal BasePrice { get; set; }      // стоимость
        // навигационное свойство
        public List<Student> Students { get; set; }
    }
}
