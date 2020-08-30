using AutoMapper;
using Lab9.BusinessLayer.Interfaces;
using Lab9.BusinessLayer.Models;
using Lab9.DataLayer.Entities;
using Lab9.DataLayer.Interfaces;
using Lab9.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Lab9.BusinessLayer.Services
{
    public class GroupService : IGroupService
    {
        IUnitOfWork dataBase;
        public GroupService(string name)
        {
            dataBase = new EntityUnitOfWork(name);
        }
        public void AddStudentToGroup(int droupId, StudentViewModel studentViewModel)
        {
            var group = dataBase.Groups.Get(droupId);
            // Конфигурировани AutoMapper
            // Mapper.Initialize(cfg => cfg.CreateMap<StudentViewModel, Student>());
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StudentViewModel, Student>());
            var mapper = new Mapper(config);
            // Отображение объекта StudentViewModel на объект Student
            //var stud = Mapper.Map<Student>(studentViewModel);
            var student = mapper.Map<StudentViewModel, Student>(studentViewModel);
            // Определение цены для студента
            student.IndividualPrice = studentViewModel.HasDiscount == true
                                    ? group.BasePrice * (decimal)0.8
                                    : group.BasePrice;
            // Добавить студента
            group.Students.Add(student);
            // Сохранить изменения
            dataBase.Save();
        }
        public void CreateGroup(GroupViewModel groupvm)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GroupViewModel, Group>());
            var mapper = new Mapper(config);
            Group group = mapper.Map<GroupViewModel, Group>(groupvm);
            dataBase.Groups.Create(group);
            dataBase.Save();
        }

        public void DeleteGroup(int groupId)
        {
            dataBase.Groups.Delete(groupId);
            dataBase.Save();
        }
        public GroupViewModel Get(int id)
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<GroupViewModel> GetAll()
        {
            // Конфигурировани AutoMapper
            //Mapper.Initialize(cfg => {
            //    cfg.CreateMap<Group, GroupViewModel>();
            //    cfg.CreateMap<Student, StudentViewModel>();
            //});

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Student, StudentViewModel>();
                cfg.CreateMap<Group, GroupViewModel>();
            });
            var mapper = new Mapper(config);
            // Отображение List<Group> на ObservableCollection<GroupViewModel>
            // var groups = Mapper.Map<ObservableCollection<GroupViewModel>>(dataBase.Groups.GetAll());
            var groups = mapper.Map<IEnumerable<Group>, ObservableCollection<GroupViewModel>>(dataBase.Groups.GetAll());
            return groups;
        }
        public void RemoveStudentFromGroup(int droupId, int studentId)
        {
            dataBase.Students.Delete(studentId);
            dataBase.Save();
        }
        public void UpdateGroup(GroupViewModel groupvm)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<StudentViewModel, Student>();
                cfg.CreateMap<GroupViewModel, Group>();
            });
            var mapper = new Mapper(config);
            Group group = mapper.Map<GroupViewModel, Group>(groupvm);

            dataBase.Groups.Update(group);
            dataBase.Save();
        }
        public void UpdateStudent(StudentViewModel studentViewModel)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<StudentViewModel, Student>();
            });
            var mapper = new Mapper(config);
            Student student = mapper.Map<StudentViewModel, Student>(studentViewModel);

            dataBase.Students.Update(student);
            dataBase.Save();
        }
    }
}
