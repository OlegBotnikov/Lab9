using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Lab9.DataLayer.EFContext;
using Lab9.DataLayer.Entities;
using Lab9.DataLayer.Interfaces;

namespace Lab9.DataLayer.Repositories
{
    class StudentRepository : IRepository<Student>
    {
        CoursesContext context;
        public StudentRepository(CoursesContext context)
        {
            this.context = context;
        }
        public void Create(Student t)
        {
            context.Students.Add(t);
        }
        public void Delete(int id)
        {
            var student = context.Students.Find(id);
            context.Students.Remove(student);
        }
        public IEnumerable<Student> Find(Func<Student, bool> predicate)
        {
            return context.Students
                          .Where(predicate)
                          .ToList();
        }
        public Student Get(int id)
        {
            return context.Students.Find(id);
        }
        public IEnumerable<Student> GetAll()
        {
            return context.Students;
        }
        public void Update(Student t)
        {
            //context.Entry<Student>(t).State = EntityState.Modified;
            var student = context.Students.Find(t.StudentId);
            student.FullName = t.FullName;
            student.DateOfBirth = t.DateOfBirth;
            student.FileName = t.FileName;
            student.IndividualPrice = t.IndividualPrice;
        }
    }
}
