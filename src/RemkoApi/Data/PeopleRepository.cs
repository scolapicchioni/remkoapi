using RemkoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemkoApi.Data
{
    public class PeopleRepository : IPeopleRepository {
        private static List<Person> people = new List<Person>() {
            new Person(){Id=0, Name="Maria", Surname="Super" },
            new Person(){Id=1, Name="Luigia", Surname="Super" }
        };

        public Person AddPerson(Person item) {
            item.Id = people.Max(p => p.Id) + 1;
            people.Add(item);
            return item;
        }

        public List<Person> GetPeople() {
            return people;
        }

        public Person GetPersonById(int id) {
            return people.FirstOrDefault(p=>p.Id==id);
        }

        public void UpdatePerson(Person item) {
            var old = people.FirstOrDefault(p => p.Id == item.Id);
            if (old != null) {
                old.Name = item.Name;
                old.Surname = item.Surname;
            }
        }
    }
}
