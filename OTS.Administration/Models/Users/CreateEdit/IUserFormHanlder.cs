using System;

namespace OTS.Administration.Models.Users.CreateEdit
{
    public interface IUserFormHanlder
    {
        void HandleCreate(UserForm form);
        void HandleEdit(Guid id, UserForm form);
    }
}