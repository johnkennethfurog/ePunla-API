using System;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.Domain.Dtos;
using MediatR;

namespace ePunla.Query.Business.AdminQueries
{
    public class GetAdminProfileQuery : IRequest<MediatrResponse<AdminProfileDto>> {
        public int UserId { get; set; }
    }
}

