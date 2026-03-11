using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Application.Commands.Members;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Handlers.Members
{
    public class DeleteMemberHandler
    {
        private readonly IMemberRepository _repo;

        public DeleteMemberHandler(IMemberRepository repo)
        {
            _repo = repo;
        }
        public async Task Handle(DeleteMemberCommand cmd)
        {
            await _repo.DeleteAsync(cmd.id);
        }
    }
}