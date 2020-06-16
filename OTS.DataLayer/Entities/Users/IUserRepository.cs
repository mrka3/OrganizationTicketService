using System;
using System.Collections.Generic;

namespace OTS.DataLayer.Entities.Users
{
    public interface IUserRepository
    {
        User Find(Guid id);
        IList<User> All();
        User FindByLogin(string login);
        bool IsExist(string login);
        IList<User> AllByIds(IList<Guid> ids);
    }
}