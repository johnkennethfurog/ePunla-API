using System;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.Domain.Dtos;
using MediatR;

namespace ePunla.Query.Business.AdminQueries
{
    public class GetDashboardItemQuery : IRequest<MediatrResponse<StatDashboardDto>>
    {
      
    }
}
