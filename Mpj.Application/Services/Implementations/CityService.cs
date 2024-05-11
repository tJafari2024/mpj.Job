
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mpj.Application.Services.Interfaces;
using Mpj.DataLayer.Entities.ProvinceAndCity;
using Mpj.DataLayer.Repository;

namespace Mpj.Application.Services.Implementations
{
    public class CityService : ICityService
    {
        #region constructor
        private readonly IGenericRepository<City> _cityRepository;
        private readonly IGenericRepository<Province> _provinceRepository;

        public CityService(IGenericRepository<City> cityRepository, IGenericRepository<Province> provinceRepository)
        {
            _cityRepository = cityRepository;
            _provinceRepository = provinceRepository;
        }

        #endregion


        #region dispose

        public async ValueTask DisposeAsync()
        {
            
            if (_cityRepository != null) await _cityRepository.DisposeAsync();
            if (_provinceRepository != null) await _provinceRepository.DisposeAsync();



        }
        #endregion

        public async Task<List<SelectListItem>> GetAllProvince()
        {
           
            return await _provinceRepository.GetQuery()
                .AsQueryable()
                .Select(u => new SelectListItem()
                {
                    Value = u.Id.ToString(),
                    Text = u.ProvinceName.ToString()
                }).ToListAsync();
        }

        public async Task<List<SelectListItem>> GetCityByProvinceId(long ProvienceId)
        {
            return await _cityRepository.GetQuery()
                .AsQueryable().Where(c=>c.ProvinceId==ProvienceId)
                .Select(u => new SelectListItem()
                {
                    Value = u.Id.ToString(),
                    Text = u.CityName.ToString()
                }).ToListAsync();
        }
    }
}
