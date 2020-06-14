using System;

namespace OTS.DataLayer.Entities.Users
{
    public class UserFactory : IUserFactory
    {
        public User Create(string name, string surname, string email, string login, string password, bool isAdmin)
        {
            return new User()
            {
                Id = Guid.NewGuid(),
                Login = login,
                Password = password,
                IsAdmin = isAdmin
            };

        }
    }
}