using System;

namespace OTS.Administration.Models.Auth
{
    public interface ILoginModelHandler
    {
        Guid Create(RegisterModel form);
        void Edit(Guid id, ProfileModel form);
        bool IsPasswordValid(LoginModel form);
        Guid? GetUserId(string login);
        bool IsExist(string login);
        bool IsAdmin(Guid userId);
    }
}