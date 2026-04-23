using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Dojo;
using Domain.Interfaces;

namespace Application.Handlers.Dojos
{
    public class UpdateDojoHandler
    {
        private readonly IDojoRepository _repo;

        public UpdateDojoHandler(IDojoRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(UpdateDojoCommand cmd)
        {
            var dojo = await _repo.GetByIdAsync(cmd.Id);
            if (dojo == null) return false;

            // Apply updates from command
            dojo.Name = cmd.Name;
            dojo.Address = new Domain.ValueObjects.Address
            {
                Street = cmd.Street,
                StreetNumber = cmd.StreetNumber,
                City = cmd.City,
                Country = cmd.Country
            };
            dojo.Contact = new Domain.ValueObjects.Contact
            {
                Email = cmd.Email,
                PhoneNumber = cmd.PhoneNumber
            };
            dojo.DojoChoId = cmd.DojoChoId;

            await _repo.UpdateAsync(dojo);
            return true;
        }
    }
}