using System.Collections.Generic;
using System.Threading.Tasks;
using ePunla.Common.Utilitites.Response;
using ePunla.Query.DAL.Models;
using ePunla.Query.Domain.Dtos;

namespace ePunla.Query.DAL.Interfaces
{
    public interface ICropsContext
    {
        Task<ContextResponse<IEnumerable<LookupModel>>> CropsLookup(PageRequestDto<CropsLookupFieldsDto> lookupFieldsDto);
    }
}
