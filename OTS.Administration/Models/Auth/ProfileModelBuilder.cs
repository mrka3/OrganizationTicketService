using System;
using OTS.DataLayer.Entities.Users;

namespace OTS.Administration.Models.Auth
{
    public class ProfileModelBuilder : IProfileModelBuilder
    {
        private readonly IUserRepository userRepository;
        public ProfileModelBuilder(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public ProfileModel Build(Guid id)
        {
            var user = userRepository.Find(id);

            if(user == null) throw  new Exception("Пользователя не существует");

            return new ProfileModel()
            {
                Login = user.Login,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname
            };
        }
    }
}