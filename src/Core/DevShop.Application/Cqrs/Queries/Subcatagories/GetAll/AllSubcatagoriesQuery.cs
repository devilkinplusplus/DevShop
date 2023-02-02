﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Queries.Subcatagories.GetAll
{
    public class AllSubcatagoriesQuery:IRequest<AllSubcatagoriesResponse>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
