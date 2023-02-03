using DevShop.Application.DTOs.Products;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Reviews.Create
{
    public class CreateReviewCommandRequest:IRequest<CreateReviewCommandResponse>
    {
        public string UserId { get; set; }
        public Review Review { get; set; }
    }
}
