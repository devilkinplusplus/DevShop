using DevShop.Application.Abstractions.Services;
using DevShop.Application.Repositories.Contacts;
using DevShop.Application.Repositories.Replies;
using DevShop.Application.Validations;
using DevShop.Domain.Entities.Concrete;
using DevShop.Domain.Entities.Identity;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Replies.Create
{
    public class CreateReplyCommandHandler : IRequestHandler<CreateReplyCommandRequest, CreateReplyCommandResponse>
    {
        private readonly IReplyWriteRepository _replyWrite;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMailService _mailService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IContactReadRepository _contactRead;
        public CreateReplyCommandHandler(IReplyWriteRepository replyWrite, IHttpContextAccessor contextAccessor, IMailService mailService, UserManager<AppUser> userManager, IContactReadRepository contactRead)
        {
            _replyWrite = replyWrite;
            _contextAccessor = contextAccessor;
            _mailService = mailService;
            _userManager = userManager;
            _contactRead = contactRead;
        }

        public async Task<CreateReplyCommandResponse> Handle(CreateReplyCommandRequest request, CancellationToken cancellationToken)
        {
            string userId = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            AppUser currentUser = await _userManager.FindByIdAsync(userId);
            ReplyValidator validations = new();
            request.Reply.Date = DateTime.Now;
            request.Reply.ContactId = request.ContactId;
            request.Reply.UserId = userId;

            ValidationResult result = validations.Validate(request.Reply);
            if (result.IsValid)
            {
                Contact cn = await _contactRead.GetAsync(x=>x.Id == request.ContactId);
                await _mailService.SendMail(currentUser.Email,"weuopfpeqruiqsbo",cn.Email,request.Reply.Message);
                await _replyWrite.AddAsync(request.Reply);
                return new() { Succeeded = true };
            }

            return new() { Succeeded = false, Errors = result.Errors };
        }
    }
}
