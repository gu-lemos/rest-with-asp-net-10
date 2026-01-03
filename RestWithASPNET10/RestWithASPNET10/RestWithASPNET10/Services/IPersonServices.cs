using RestWithASPNET10.Model;

namespace RestWithASPNET10.Services
{
    public interface IPersonServices
    {
        Person Create(Person person);
        Person? Update(Person person);
        void Delete(long id);
        Person? FindById(long id);
        List<Person> FindAll();
    }
}
