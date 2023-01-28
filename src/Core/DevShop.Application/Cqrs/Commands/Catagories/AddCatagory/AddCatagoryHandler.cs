using AutoMapper;
using DevShop.Application.Repositories.Catagory;
using DevShop.Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShop.Application.Cqrs.Commands.Catagories.AddCatagory
{
    public class AddCatagoryHandler : IRequestHandler<AddCatagoryCommand, bool>
    {
        private readonly ICatagoryWriteRepository _catagoryWrite;
        private readonly IMapper _mapper;

        public AddCatagoryHandler(IMapper mapper, ICatagoryWriteRepository catagoryWrite)
        {
            _mapper = mapper;
            _catagoryWrite = catagoryWrite;
        }

        public async Task<bool> Handle(AddCatagoryCommand request, CancellationToken cancellationToken)
        {
            Catagory data = _mapper.Map<Catagory>(request.Catagory);
            if (request.Catagory.Name is null)
                return false;
            await _catagoryWrite.AddAsync(data);
            return true;
        }
    }
}
