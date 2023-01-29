﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Subcatagories.Delete
{
    public class DeleteSubcatagoryCommand:IRequest<DeleteSubcatagoryCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
