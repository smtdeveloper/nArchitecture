using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommand : IRequest<DeleteBrandDto>
    {
        public int Id { get; set; }

        public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeleteBrandDto>
        {

            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public DeleteBrandCommandHandler(IBrandRepository programmingLanguageRepository, IMapper mapper)
            {
                _brandRepository = programmingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<DeleteBrandDto> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                var brand = await _brandRepository.GetAsync(p => p.Id == request.Id);


                var deleteBrand = await _brandRepository.DeleteAsync(brand);

                var mapBrand = _mapper.Map<DeleteBrandDto>(deleteBrand);

                return mapBrand;

            }
        }

    }
}
