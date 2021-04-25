using System;
using System.Collections.Generic;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.Domain.Dtos;
using MediatR;

namespace ePunla.Query.Business.Queries
{
    public class GetFarmersCropQuery : IRequest<MediatrResponse<IEnumerable<FarmCropDto>>>
    {
        public int FarmerId { get; set; }
        public SearchCropFieldsDto SearchField { get; set; }
    }
}
