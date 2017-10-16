using Specian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Specian.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Persons.Any())
            {
                return;   // DB has been seeded
            }

            var persons = new Person[]
            {
                new Person{Id=Guid.NewGuid(), FirstName ="Petr",LastName="Veliky"},
                new Person{Id=Guid.NewGuid(), FirstName ="Jan",LastName="Maly"},
                new Person{Id=Guid.NewGuid(), FirstName ="Ivan",LastName="Stredni"},

            };
            foreach (Person p in persons)
            {
                context.Persons.Add(p);
            }
            context.SaveChanges();



            var groups = new Group[]
            {
                new Group{Id=Guid.NewGuid(), Name="Skupina1", Persons=new List<Person>()},
                new Group{Id=Guid.NewGuid(), Name="Skupina2", Persons=new List<Person>()},
                new Group{Id=Guid.NewGuid(), Name="Skupina3", Persons=new List<Person>()},
                new Group{Id=Guid.NewGuid(), Name="Skupina4", Persons=new List<Person>()},
                new Group{Id=Guid.NewGuid(), Name="Skupina5", Persons=new List<Person>()},

            };
            foreach (Group g in groups)
            {
                g.Persons.Add(persons[0]);
                context.Groups.Add(g);
            }
            context.SaveChanges();






        }
    }
}
