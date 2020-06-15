using System;
using System.Collections.Generic;
using System.Linq;
using OTS.DataLayer.Infrastructure;

namespace OTS.DataLayer.Entities.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly IEntityRepository<IOtsEntity> entityRepository;

        public UserRepository(IEntityRepository<IOtsEntity> entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public User Find(Guid id)
        {
            return entityRepository.GetTable<User>().FirstOrDefault(u => u.Id == id);
        }
        public User FindByLogin(string login)
        {
            return entityRepository.GetTable<User>().FirstOrDefault(u => u.Login == login);
        }

        public bool IsExist(string login)
        {
            return entityRepository.GetTable<User>().Any(u => u.Login == login);
        }

        public IList<User> AllByIds(IList<Guid> ids)
        {
            return entityRepository.GetTable<User>().Where(u => ids.Contains(u.Id)).ToList();
        }
    }
}