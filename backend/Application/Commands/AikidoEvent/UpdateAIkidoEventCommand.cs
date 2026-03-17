using Domain.ValueObjects;

namespace Application.Commands.AikidoEvent
{
    public record UpdateAikidoEventCommand(int Id, string Title, string Type, DateTime Date, Address Address, Contact Contact, 
        string? Description, int? OrganizerId, int? PresenterId, List<int> AttendeesIds);
}