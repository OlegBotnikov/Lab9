using System;

namespace Lab9.DataLayer.Entities
{
    public class Student
    {
        public int StudentId { get; set; }              // ключ
        public string FullName { get; set; }            // фио
        public DateTime DateOfBirth { get; set; }       // дата рождения
        public decimal IndividualPrice { get; set; }    // оплата
        public string FileName { get; set; }            // имя файла с фото
        // Навигационные свойства
        public int GroupId { get; set; }                // ключ группы
        public Group Group { get; set; }                // группа
    }
}
