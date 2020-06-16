using System.Linq;
using OTS.DataLayer.Entities.Users;

namespace OTS.Administration.Models.Users.List
{
    public class UserListModelBuilder : IUserListModelBuilder
    {
        private readonly IUserRepository userRepository;

        public UserListModelBuilder(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserListModel Build()
        {
            var users = userRepository.All();

            var modelList = users.Select(u => new UserListItemModel()
                {Id = u.Id, Login = u.Login, Name = u.Surname + " " + u.Name}).ToList();

            return new UserListModel(modelList);
        }
    }
}