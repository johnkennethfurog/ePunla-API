using System.Collections.Generic;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.Domain.Dtos;
using MediatR;

namespace ePunla.Query.Business.Queries
{
    public class CropLookupQuery : IRequest<MediatrResponse<IEnumerable<LookupDto>>>
    {
        public PageRequestDto<CropsLookupFieldsDto> CropsLookupFields { get; set; }
    }
}
