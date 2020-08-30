using Lab9.DataLayer.EFContext;
using Lab9.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Lab9.DataLayer.Interfaces;

namespace Lab9.DataLayer.Repositories
{
    class GroupsRepository : IRepository<Group>
    {
        CoursesContext context;
        public GroupsRepository(CoursesContext context)
        {
            this.context = context;
        }
        public void Create(Group t)
        {
            context.Groups.Add(t);
        }
        public void Delete(int id)
        {
            var group = context.Groups.Find(id);
            context.Groups.Remove(group);
        }
        public IEnumerable<Group> Find(Func<Group, bool> predicate)
        {
            return context
            .Groups
            .Include(g => g.Students)
            .Where(predicate)
            .ToList();
        }
        public Group Get(int id)
        {
            return context.Groups.Find(id);
        }
        public IEnumerable<Group> GetAll()
        {
            return context.Groups.Include(g => g.Students);
        }
        public void Update(Group t)
        {
            //context.Entry<Group>(t).State = EntityState.Modified;
            var group = context.Groups.Find(t.GroupId);
            group.BasePrice = t.BasePrice;
            group.CourseName = t.CourseName;
            group.Commence = t.Commence;
        }
    }
}
