using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.DAL.Interfaces;
using ePunla.Query.Domain.Dtos;
using MediatR;

namespace ePunla.Query.Business.AdminQueries
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, MediatrResponse<IEnumerable<CategoryDto>>>
    {
        private readonly IAdminContext _adminContext;
        private readonly IMapper _mapper;

        public GetCategoriesHandler(IAdminContext adminContext, IMapper mapper)
        {
            _adminContext = adminContext;
            _mapper = mapper;
        }

        public async Task<MediatrResponse<IEnumerable<CategoryDto>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var mediatorResponse = await _adminContext.GetCategories();
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(mediatorResponse.Value);

            return new MediatrResponse<IEnumerable<CategoryDto>>(categoriesDto);
        }
    }
}
