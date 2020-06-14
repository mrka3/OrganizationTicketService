using System;
using OTS.DataLayer.Entities;
using OTS.DataLayer.Entities.Users;
using OTS.DataLayer.Infrastructure;

namespace OTS.Administration.Models.Auth
{
    public class LoginModelHandler : ILoginModelHandler
    {
        private readonly IUserFactory userFactory;
        private readonly IUserRepository userRepository;
        private readonly IEntityRepository<IOtsEntity> entityRepository;

        public LoginModelHandler(IUserFactory userFactory, IEntityRepository<IOtsEntity> entityRepository, IUserRepository userRepository)
        {
            this.userFactory = userFactory;
            this.entityRepository = entityRepository;
            this.userRepository = userRepository;
        }

        public Guid Create(RegisterModel form)
        {
            var user = userFactory.Create(form.Name, form.Surname, form.Email, form.Login, form.Password, false);

            entityRepository.InsertOnSave(user);
            entityRepository.SaveChanges();

            return user.Id;
        }

        public bool IsPasswordValid(LoginModel form)
        {
            var user = userRepository.FindByLogin(form.Login);

            if (user == null) return false;

            return user.Password == form.Password;
        }

        public Guid? GetUserId(string login)
        {
            var user = userRepository.FindByLogin(login);

            return user?.Id;
        }

        public bool IsExist(string login)
        {
            return userRepository.IsExist(login);
        }
    }
}