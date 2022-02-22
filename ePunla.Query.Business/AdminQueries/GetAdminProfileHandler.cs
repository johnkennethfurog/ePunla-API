using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.DAL.Interfaces;
using ePunla.Query.Domain.Dtos;
using MediatR;

namespace ePunla.Query.Business.AdminQueries
{
    public class GetAdminProfileHandler : IRequestHandler<GetAdminProfileQuery, MediatrResponse<AdminProfileDto>>
    {
        private readonly IAdminContext _adminContext;
        private readonly IMapper _mapper;

        public GetAdminProfileHandler(IAdminContext adminContext, IMapper mapper)
        {
            _mapper = mapper;
            _adminContext = adminContext;
        }

        public async Task<MediatrResponse<AdminProfileDto>> Handle(GetAdminProfileQuery request, CancellationToken cancellationToken)
        {
            var response = await _adminContext.GetAdminProfile(request.UserId);
            var profileModel = response.Value;
            var profileDto = _mapper.Map<AdminProfileDto>(profileModel);


            return new MediatrResponse<AdminProfileDto>(profileDto);
        }
    }
}
