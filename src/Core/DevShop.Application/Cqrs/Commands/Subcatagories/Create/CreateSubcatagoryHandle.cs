using AutoMapper;
using DevShop.Application.Repositories.Catagorysub;
using DevShop.Application.Repositories.Subcatagory;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Subcatagories.Create
{
    public class CreateSubcatagoryHandle : IRequestHandler<CreateSubcatagoryCommand, CreateSubcatagoryCommandResponse>
    {
        private readonly ISubcatagoryWriteRepository _subcatagoryWrite;
        private readonly ICatagorysubWriteRepository _catagorysubWrite;
        private readonly IMapper _mapper;
        public CreateSubcatagoryHandle(ISubcatagoryWriteRepository subcatagoryWrite, IMapper mapper, ICatagorysubWriteRepository catagorysubWrite)
        {
            _subcatagoryWrite = subcatagoryWrite;
            _mapper = mapper;
            _catagorysubWrite = catagorysubWrite;
        }

        public async Task<CreateSubcatagoryCommandResponse> Handle(CreateSubcatagoryCommand request, CancellationToken cancellationToken)
        {
            if (request.Subcatagory.Name is null || request.CatagoryIds.Count == 0)
                return new() { Succeeded = false };

            SubCatagory data = _mapper.Map<SubCatagory>(request.Subcatagory);
            await _subcatagoryWrite.AddAsync(data);

            for (int i = 0; i < request.CatagoryIds.Count; i++)
            {
                CatagorySub catagorySub = new()
                {
                    SubCatagoryId = data.Id,
                    CatagoryId = request.CatagoryIds[i]
                };
                await _catagorysubWrite.AddAsync(catagorySub);
            }

            return new() { Succeeded = true };
        }
    }
}
