using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Replies.Create
{
    public class CreateReplyCommandResponse
    {
        public bool Succeeded { get; set; }
        public List<ValidationFailure> Errors { get; set; }
    }
}
