using Application.Commands.Organization;
using Domain.Interfaces;

namespace Application.Handlers.Organization
{
    public class DeleteOrganizationHandler
    {        
        private readonly IOrganizationRepository _repo;

        public DeleteOrganizationHandler(IOrganizationRepository repo)
        {
            _repo = repo;
        }

        public async Task Handle(DeleteOrganizationCommand command)
        {
            var organization = await _repo.GetByIdAsync(command.Id);
            if (organization == null) return;
            await _repo.DeleteAsync(organization.Id);
        }
    }
}