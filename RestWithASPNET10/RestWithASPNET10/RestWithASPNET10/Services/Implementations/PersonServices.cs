using Microsoft.EntityFrameworkCore;
using RestWithASPNET10.Model;
using RestWithASPNET10.Model.Context;
using System;

namespace RestWithASPNET10.Services.Implementations
{
    public class PersonServices(SqlContext sqlContext) : IPersonServices
    {
        private readonly SqlContext _sqlContext = sqlContext;

        public List<Person> FindAll() => [.. _sqlContext.Persons];

        public Person? FindById(long id) => _sqlContext.Persons.SingleOrDefault(p => p.Id == id);

        public Person Create(Person person)
        {
            _sqlContext.Persons.Add(person);
            _sqlContext.SaveChanges();

            return person;
        }

        public Person? Update(Person person)
        {
            var personToUpdate = _sqlContext.Persons.SingleOrDefault(p => p.Id == person.Id);

            if (personToUpdate == null) return null;

            personToUpdate.Update(person.FirstName, person.LastName, person.Address, person.Gender);
            _sqlContext.SaveChanges();

            return person;
        }

        public void Delete(long id)
        {
            var personToDelete = _sqlContext.Persons.SingleOrDefault(p => p.Id == id);

            if (personToDelete != null)
            {
                _sqlContext.Persons.Remove(personToDelete);
                _sqlContext.SaveChanges();
            }
        }
    }
}
