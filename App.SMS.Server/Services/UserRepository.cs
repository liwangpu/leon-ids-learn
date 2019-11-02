using System.Collections.Generic;

namespace App.SMS.Server.Services
{

    public interface IUserRepository
    {
        List<string> GetAll();

        void Create(string name);
    }
    public class UserRepository : IUserRepository
    {
        private List<string> _Users = new List<string>() { "Leon", "Hellen" };

        public void Create(string name)
        {
            _Users.Add(name);
        }

        public List<string> GetAll()
        {
            return _Users;
        }
    }
}
