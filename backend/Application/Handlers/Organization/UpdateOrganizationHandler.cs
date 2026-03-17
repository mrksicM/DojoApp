using Application.Commands.Organization;
using Domain.Interfaces;

namespace Application.Handlers.Organization
{
    public class UpdateOrganizationHandler
    {
        private readonly IOrganizationRepository _repo;
        public UpdateOrganizationHandler(IOrganizationRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> Handle(UpdateOrganizationCommand cmd)
        {
            var organization = await _repo.GetByIdAsync(cmd.Id);
            if (organization == null) return false;

            // Apply updates from command
            organization.Name = cmd.Name;
            organization.PresidentId = cmd.PresidentId;
            organization.Contact = cmd.Contact;
            organization.Address = cmd.Address;

            await _repo.UpdateAsync(organization);
            return true;
        }
    }
}