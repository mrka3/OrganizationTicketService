using System.Collections.Generic;

namespace OTS.Administration.Models.Users.List
{
    public class UserListModel
    {
        public IList<UserListItemModel> Users { get; set; }

        public UserListModel(IList<UserListItemModel> users)
        {
            Users = users;
        }
    }
}