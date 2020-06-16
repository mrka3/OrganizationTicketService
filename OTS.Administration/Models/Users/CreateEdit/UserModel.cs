using System;

namespace OTS.Administration.Models.Users.CreateEdit
{
    public class UserModel
    {
        public Guid? Id { get; set; }
        public UserForm Form { get; set; }

        public UserModel(Guid? id, UserForm form)
        {
            Id = id;
            Form = form;
        }
    }
}