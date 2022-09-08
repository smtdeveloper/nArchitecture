using Application.Features.Brands.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetListBrand
{
    public class GetListBrandQuery : IRequest<BrandListModel>
    {
        public PageRequest pageRequest { get; set; }
        public class GetListBrandHandler : IRequestHandler<GetListBrandQuery, BrandListModel>
        {
           private readonly IBrandRepository _brandRepository;
           private readonly IMapper _mapper;

            public GetListBrandHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<BrandListModel> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Brand> brands = await _brandRepository
                    .GetListAsync
                    ( 
                    b=> b.IsActive == true, 
                    index: request.pageRequest.Page, 
                    size: request.pageRequest.PageSize
                    );
                

                BrandListModel mappedBrandListModel = _mapper.Map<BrandListModel>(brands);

                return mappedBrandListModel;
            }
        }

    }
}
