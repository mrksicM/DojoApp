using Application.DTOs;
using Domain.ValueObjects;

namespace Application.Commands.Dojo
{
    public record UpdateDojoCommand(int Id, string Name, Contact Contact, Address Address, int DojoChoId, List<MembersDTO> Members);
}