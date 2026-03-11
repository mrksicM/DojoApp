using Application.DTOs;
using Domain.ValueObjects;

namespace Application.Commands.Members
{
    public record CreateMemberCommand(MembersDTO memberDTO);
}
