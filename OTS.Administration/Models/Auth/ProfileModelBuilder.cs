using System;
using System.Linq;
using OTS.DataLayer.Entities.Events;
using OTS.DataLayer.Entities.Users;

namespace OTS.Administration.Models.Auth
{
    public class ProfileModelBuilder : IProfileModelBuilder
    {
        private readonly IUserRepository userRepository;
        private readonly IUserEventLinkRepository userEventLinkRepository;
        private readonly IEventRepository eventRepository;
        public ProfileModelBuilder(IUserRepository userRepository, IUserEventLinkRepository userEventLinkRepository, IEventRepository eventRepository)
        {
            this.userRepository = userRepository;
            this.userEventLinkRepository = userEventLinkRepository;
            this.eventRepository = eventRepository;
        }

        public ProfileModel Build(Guid id)
        {
            var user = userRepository.Find(id);

            if(user == null) throw  new Exception("Пользователя не существует");

            var links = userEventLinkRepository.AllByUserId(user.Id).Select(ue => ue.EventId).ToList();

            var events = eventRepository.All().Where(e => links.Contains(e.Id));

            var modelList = events.Select(e => new ProfileEventsModel()
                {Id = e.Id, IssueDate = e.IssueDate, Title = e.Title}).ToList();

            return new ProfileModel()
            {
                Login = user.Login,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname,
                Events = modelList
            };
        }
    }
}