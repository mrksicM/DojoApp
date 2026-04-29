using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.AikidoEvent;
using Application.DTOs;
using Application.Queries.AikidoEvents;
using Domain.Interfaces;

namespace Application.Handlers.AikidoEvent
{
    public class GetAikidoEventHandler
    {
        private readonly IAikidoEventRepository _repo;

        public GetAikidoEventHandler(IAikidoEventRepository repo)
        {
            _repo = repo;
        }

        public async Task<AikidoEventDTO?> Handle(GetAikidoEventByIdQuery query)
        {
            var aikidoEvent = await _repo.GetByIdAsync(query.Id);
            if (aikidoEvent == null) return null;
            return new AikidoEventDTO
            {
                Id = aikidoEvent.Id,
                Title = aikidoEvent.Title,
                Type = aikidoEvent.Type,
                Date = aikidoEvent.Date,
                Street = aikidoEvent.Address.Street,
                StreetNumber = aikidoEvent.Address.StreetNumber,
                City = aikidoEvent.Address.City,
                Country = aikidoEvent.Address.Country,
                Email = aikidoEvent.Contact.Email,
                PhoneNumber = aikidoEvent.Contact.PhoneNumber,
                Description = aikidoEvent.Description,
                OrganizerId = aikidoEvent.OrganizerId,
                PresenterId = aikidoEvent.PresenterId
            };
        }

        public async Task<IEnumerable<AikidoEventDTO>> Handle(GetAllAikidoEventsQuery query)
        {
            var aikidoEvents = await _repo.GetAllAsync();

            return aikidoEvents.Select(a => new AikidoEventDTO
            {
                Id = a.Id,
                Title = a.Title,
                Type = a.Type,
                Date = a.Date,
                Street = a.Address.Street,
                StreetNumber = a.Address.StreetNumber,
                City = a.Address.City,
                Country = a.Address.Country,
                Email = a.Contact.Email,
                PhoneNumber = a.Contact.PhoneNumber,
                Description = a.Description,
                OrganizerId = a.OrganizerId,
                Organizer = a.Organizer != null ? new MembersDTO
                {
                    Id = a.Organizer.Id,
                    FirstName = a.Organizer.Name.FirstName,
                    LastName = a.Organizer.Name.LastName,
                    Email = a.Organizer.PersonalInfo.Contact.Email,
                    PhoneNumber = a.Organizer.PersonalInfo.Contact.PhoneNumber,
                    DateOfBirth = a.Organizer.PersonalInfo.DateOfBirth
                } : null,
                PresenterId = a.PresenterId,
                Presenter = a.Presenter != null ? new MembersDTO
                {
                    Id = a.Presenter.Id,
                    FirstName = a.Presenter.Name.FirstName,
                    LastName = a.Presenter.Name.LastName,
                    Email = a.Presenter.PersonalInfo.Contact.Email,
                    PhoneNumber = a.Presenter.PersonalInfo.Contact.PhoneNumber,
                    DateOfBirth = a.Presenter.PersonalInfo.DateOfBirth
                } : null
            });
        }

    }
}