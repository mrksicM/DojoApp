using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Dojo;
using Domain.Interfaces;

namespace Application.Handlers.Dojos
{
    public class DeleteDojoHandler
    {
        private readonly IDojoRepository _repo;

        public DeleteDojoHandler(IDojoRepository repo)
        {
            _repo = repo;
        }
        public async Task Handle(DeleteDojoCommand cmd)
        {
            await _repo.DeleteAsync(cmd.Id);
        }
    }
}