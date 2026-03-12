using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Commands.Dojo
{
    public record CreateDojoCommand(DojoDTO DojoDTO);
}