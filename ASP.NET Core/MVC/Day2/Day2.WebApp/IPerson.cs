using Day2.WebApp.Models;

namespace Day2.WebApp
{
    public interface IPerson
    {
        void Create(People people);
        void Update(int id);
        void Delete(int id);
        List<People> ListAll();
    }
}
