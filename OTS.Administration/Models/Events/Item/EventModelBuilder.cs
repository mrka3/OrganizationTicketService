using System;
using System.Collections.Generic;
using System.Linq;
using OTS.DataLayer.Entities.Events;
using OTS.DataLayer.Entities.Users;

namespace OTS.Administration.Models.Events.Item
{
    public class EventModelBuilder : IEventModelBuilder
    {
        private readonly IEventRepository eventRepository;
        private readonly IUserRepository userRepository;
        private readonly IUserEventLinkRepository userEventLinkRepository;

        public EventModelBuilder(IEventRepository eventRepository, IUserRepository userRepository, IUserEventLinkRepository userEventLinkRepository)
        {
            this.eventRepository = eventRepository;
            this.userRepository = userRepository;
            this.userEventLinkRepository = userEventLinkRepository;
        }

        public EventModel Build(Guid id)
        {
            var eventModel = eventRepository.Find(id);

            if (eventModel == null) throw new Exception("Мероприятие не найдено");

            var userIds = userEventLinkRepository.AllByEventId(id).Select(ue => ue.UserId).ToList();

            var users = userRepository.AllByIds(userIds);

            var visitors = users.Select(u => new EventUsersModel()
                {Email = u.Email, Name = $"{u.Surname} {u.Name[0]}."}).ToList();

            var ticketCount = eventModel.TicketCount - userIds.Count;

            return new EventModel(id, eventModel.Title, eventModel.Description, eventModel.IssueDate, ticketCount, eventModel.Duration, visitors);
        }
    }
}