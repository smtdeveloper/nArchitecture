using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommand : IRequest<UpdateBrandDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdateBrandDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;

            public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
            }

            public async Task<UpdateBrandDto> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
            {
                var brand = await _brandRepository.GetAsync(b => b.Id == request.Id);

                brand.Name = request.Name;
                brand.IsActive = request.IsActive;

                var updateBrand = await _brandRepository.UpdateAsync(brand);

                var mappedBrand = _mapper.Map<UpdateBrandDto>(updateBrand);

                return mappedBrand;

            }
        }
    }
}
