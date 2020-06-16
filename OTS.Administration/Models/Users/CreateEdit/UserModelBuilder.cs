using System;
using OTS.DataLayer.Entities.Users;

namespace OTS.Administration.Models.Users.CreateEdit
{
    public class UserModelBuilder : IUserModelBuilder
    {
        private readonly IUserRepository userRepository;

        public UserModelBuilder(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserModel BuildNew()
        {
            return new UserModel(null, new UserForm());
        }

        public UserModel BuildEdit(Guid id)
        {
            var user = userRepository.Find(id);

            if(user == null) throw new Exception("Пользователь не найден");

            return new UserModel(id,
                new UserForm()
                {
                    Email = user.Email, Login = user.Login, Surname = user.Surname, IsAdmin = user.IsAdmin,
                    Name = user.Name
                });
        }
    }
}