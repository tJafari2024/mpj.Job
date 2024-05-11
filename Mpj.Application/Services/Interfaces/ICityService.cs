
using Microsoft.AspNetCore.Mvc.Rendering;
using Mpj.DataLayer.Entities.ProvinceAndCity;

namespace Mpj.Application.Services.Interfaces
{
    public interface ICityService:IAsyncDisposable
    {
        Task<List<SelectListItem>> GetAllProvince();
        Task<List<SelectListItem>> GetCityByProvinceId(long ProvienceId);
    }
}
