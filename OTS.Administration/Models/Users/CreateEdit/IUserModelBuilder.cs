using System;

namespace OTS.Administration.Models.Users.CreateEdit
{
    public interface IUserModelBuilder
    {
        UserModel BuildNew();
        UserModel BuildEdit(Guid id);
    }
}