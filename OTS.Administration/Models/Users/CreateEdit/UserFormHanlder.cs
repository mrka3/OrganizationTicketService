using System;
using OTS.DataLayer.Entities;
using OTS.DataLayer.Entities.Users;
using OTS.DataLayer.Infrastructure;

namespace OTS.Administration.Models.Users.CreateEdit
{
    public class UserFormHanlder : IUserFormHanlder
    {
        private readonly IUserFactory userFactory;
        private readonly IUserRepository userRepository;
        private readonly IEntityRepository<IOtsEntity> entityRepository;

        public UserFormHanlder(IUserFactory userFactory, IUserRepository userRepository, IEntityRepository<IOtsEntity> entityRepository)
        {
            this.userFactory = userFactory;
            this.userRepository = userRepository;
            this.entityRepository = entityRepository;
        }

        public void HandleCreate(UserForm form)
        {
            var user = userFactory.Create(form.Name, form.Surname, form.Email, form.Login, "1", form.IsAdmin);

            entityRepository.InsertOnSave(user);
            entityRepository.SaveChanges();
        }
        public void HandleEdit(Guid id, UserForm form)
        {
            var user = userRepository.Find(id);

            if(user == null) throw new Exception("Пользователь не найден");

            user.Name = form.Name;
            user.Surname = form.Surname;
            user.Email = form.Email;
            user.IsAdmin = form.IsAdmin;

            entityRepository.SaveChanges();
        }
    }
}