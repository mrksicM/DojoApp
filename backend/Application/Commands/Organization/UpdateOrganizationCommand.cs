using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.ValueObjects;

namespace Application.Commands.Organization
{
    public record UpdateOrganizationCommand(int Id, string Name, int PresidentId, Contact Contact, Address Address, List<DojoDTO> Dojos);
}