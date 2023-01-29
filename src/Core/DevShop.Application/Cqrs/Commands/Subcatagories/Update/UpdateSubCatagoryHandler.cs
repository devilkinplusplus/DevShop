using AutoMapper;
using DevShop.Application.Repositories.Subcatagory;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Subcatagories.Update
{
    public class UpdateSubCatagoryHandler : IRequestHandler<UpdateSubCatagoryCommand, UpdateSubCatagoryCommandResponse>
    {
        private readonly ISubcatagoryReadRepository _subcatagoryRead;
        private readonly ISubcatagoryWriteRepository _subcatagoryWrite;
        private readonly IMapper _mapper;
        public UpdateSubCatagoryHandler(ISubcatagoryReadRepository subcatagoryRead, ISubcatagoryWriteRepository subcatagoryWrite, IMapper mapper)
        {
            _subcatagoryRead = subcatagoryRead;
            _subcatagoryWrite = subcatagoryWrite;
            _mapper = mapper;
        }

        public async Task<UpdateSubCatagoryCommandResponse> Handle(UpdateSubCatagoryCommand request, CancellationToken cancellationToken)
        {
            if (request.Subcatagory.Name is null || request.Id == null)
                return new() { Succeeded = false };
            //new data
            SubCatagory newData = _mapper.Map<SubCatagory>(request.Subcatagory);
            SubCatagory currentData = await _subcatagoryRead.GetByIdAsync(request.Id);

            currentData.Name = newData.Name;
            await _subcatagoryWrite.UpdateAsync(currentData);
            return new() { Succeeded = true };
        }
    }
}
