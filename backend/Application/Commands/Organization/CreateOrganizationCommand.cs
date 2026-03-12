using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Commands.Organization
{
    public record CreateOrganizationCommand(OrganizationDTO OrganizationDTO);
}