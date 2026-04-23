using Application.DTOs;
using Domain.ValueObjects;

namespace Application.Commands.Dojo
{
    public record UpdateDojoCommand(
        int Id,
        string Name,
        string Street,
        string StreetNumber,
        string City,
        string Country,
        string Email,
        string PhoneNumber,
        int DojoChoId,
        String DojoChoName,
        List<MembersDTO> Members
    );
}