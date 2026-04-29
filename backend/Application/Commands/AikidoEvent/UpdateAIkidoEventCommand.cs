using Domain.ValueObjects;

namespace Application.Commands.AikidoEvent
{
    public record UpdateAikidoEventCommand(int Id, string Title, string Type, DateTime Date, String? Street, String? StreetNumber, String? City, String? Country, String Email, String PhoneNumber, string? Description, int? OrganizerId, int? PresenterId);
}