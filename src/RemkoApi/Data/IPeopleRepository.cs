using System.Collections.Generic;
using RemkoApi.Models;

namespace RemkoApi.Data {
    public interface IPeopleRepository {
        List<Person> GetPeople();
        Person GetPersonById(int id);
    }
}