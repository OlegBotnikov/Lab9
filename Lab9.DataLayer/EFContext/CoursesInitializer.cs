using Lab9.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Lab9.DataLayer.EFContext
{
    class CoursesInitializer : CreateDatabaseIfNotExists<CoursesContext>
    {
        protected override void Seed(CoursesContext context)
        {
            context.Groups.AddRange(new Group[] {
                new Group { BasePrice=300, Commence=new DateTime(2020, 09, 10),
                            CourseName ="Обучение на категорию А (Мотоцикл)",
                            Students =new List<Student>{
                                new Student { IndividualPrice=250,
                                    DateOfBirth =new DateTime (2000, 10,23),
                                    FullName="Иван Мотоциклов", FileName="11.jpg" },
                                new Student { IndividualPrice=250,
                                    DateOfBirth =new DateTime (1995, 03,05),
                                    FullName ="Димон Байкеров", FileName="12.jpg" }
                            }
                },
                new Group { BasePrice=500, Commence=new DateTime(2020, 10, 11),
                            CourseName ="Обучение на категорию В (Легковой)",
                    Students =new List<Student>{
                                new Student { IndividualPrice=450,
                                    DateOfBirth =new DateTime (1991, 06,14),
                                    FullName ="Митя Жигулёв", FileName="10.jpg" },
                                new Student { IndividualPrice=450,
                                    DateOfBirth =new DateTime (1989, 12,06),
                                    FullName ="Эдуард Вольвов", FileName="14.jpg" },
                                new Student { IndividualPrice=450,
                                    DateOfBirth =new DateTime (1985, 09,11),
                                    FullName ="Рудольф Бэхин", FileName="15.jpg" }
                    }
                }
            });
            context.SaveChanges();
        }
    }
}
