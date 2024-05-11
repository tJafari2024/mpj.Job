
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Mpj.Application.Services.Interfaces;
using Mpj.DataLayer.DTOs.EmploymentForm;
using Mpj.DataLayer.Entities.EmploymentForm;
using Mpj.DataLayer.Enums;
using Mpj.DataLayer.Repository;
using System.Linq;
using Mpj.Application.Utils;

namespace Mpj.Application.Services.Implementations
{
    public class EmploymentSpouseService : IEmploymentSpouseService
    {
        private readonly IGenericRepository<Sponsorship> _repository;

        public EmploymentSpouseService(IGenericRepository<Sponsorship> repository)
        {
            _repository = repository;
        }
        public async ValueTask DisposeAsync()
        {
            await _repository.DisposeAsync();
        }
        public async Task<List<Sponsorship>> GetSponserRecode(long employmentId)
        {
            List<Sponsorship> sponsorships = await _repository.GetQuery().AsQueryable()
                .Where(e => e.EmploymentId == employmentId).ToListAsync();
            return sponsorships;
        }
        public async Task<bool> AddSpouse(List<SpouseDTO> lst, long employmentId, List<SpouseDTO>? lstsponser)
        {
            try
            {
                if (lstsponser.Any(s => (s.Name ?? "").Length > 0)) //مدیریت اطلاعات تکمیلی برای همسر
                {
                    var list = await GetSponserRecode(employmentId); //رکوردهای داخل دیتابیس
                    foreach (var item in list)
                    {
                        _repository.DeletePermanent(item);
                        await _repository.SaveChanges();
                    }

                   
                    var lstSpouses = new List<Sponsorship>();
                    int index =0 ;
                    foreach (var item in lstsponser.Where(s=>s.Relation==(byte)Relation.Spouse))
                    {
                        var newitem = new Sponsorship()
                        {
                            SpouseMobile = lst[index].SpouseMobile,
                            SpouseJob = lst[index].SpouseJob,
                            EmploymentId = employmentId,
                            Name = item.Name,
                            Family = item.Family,
                            NationCode = item.NationCode,
                            Relation = item.Relation,
                            ProvinceOfIssueId = item.ProvinceOfIssueId,
                            SerialInsurance = item.SerialInsurance,
                            BasicInsurance = item.BasicInsurance,
                            BirthCertificateId = item.BirthCertificateId,
                            BrithDate = item.BrithDate?.ToMiladiDateTime(),
                            FatherName = item.FatherName,
                            Gender = item.Gender,
                            IsCovered = item.IsCovered,
                            MaritalStatus = item.MaritalStatus,
                            ProvinceId = item.ProvinceId,
                           
                        };
                        lstSpouses.Add(newitem);
                        index++;
                    }
                    foreach (var item in lstsponser.Where(s => s.Relation == (byte)Relation.Child))
                    {
                        var newitem = new Sponsorship()
                        {
                            SpouseMobile = item.SpouseMobile,
                            SpouseJob = item.SpouseJob,
                            EmploymentId = employmentId,
                            Name = item.Name,
                            Family = item.Family,
                            NationCode = item.NationCode,
                            Relation = item.Relation,
                            ProvinceOfIssueId = item.ProvinceOfIssueId,
                            SerialInsurance = item.SerialInsurance,
                            BasicInsurance = item.BasicInsurance,
                            BirthCertificateId = item.BirthCertificateId,
                            BrithDate = item.BrithDate?.ToMiladiDateTime(),
                            FatherName = item.FatherName,
                            Gender = item.Gender,
                            IsCovered = item.IsCovered,
                            MaritalStatus = item.MaritalStatus,
                            ProvinceId = item.ProvinceId,

                        };
                        lstSpouses.Add(newitem);
                    }

                    foreach (var item in lst)
                    {
                       
                        if(!lstSpouses.Any(s=>s.SpouseJob==item.SpouseJob && s.SpouseMobile==item.SpouseMobile))
                            lstSpouses.Add(new Sponsorship()
                            {
                                SpouseJob = item.SpouseJob,
                                SpouseMobile = item.SpouseMobile,
                                Relation = (byte)Relation.Spouse
                            });
                    }
                    if (lstSpouses.Any())
                        await _repository.AddRangeEntities(lstSpouses);
                }
                else if (lst.Any())
                {
                    var list = await GetSponserRecode(employmentId); //رکوردهای داخل دیتابیس
                    foreach (var item in list)
                    {
                        _repository.DeletePermanent(item);
                        await _repository.SaveChanges();
                    }
                    var lstSpouse = new List<Sponsorship>();
                    foreach (var item in lst)
                    {
                        // if ((item.SpouseJob != "") || (item.SpouseMobile != "") )
                        //{
                        var newitem = new Sponsorship()
                        {
                            SpouseMobile = item.SpouseMobile,
                            SpouseJob = item.SpouseJob,
                            EmploymentId = employmentId,
                            Name = item.Name,
                            Family = item.Family,
                            NationCode = item.NationCode,
                            Relation = item.Relation,
                            ProvinceOfIssueId = item.ProvinceOfIssueId,
                            SerialInsurance = item.SerialInsurance,
                            BasicInsurance = item.BasicInsurance,
                            BirthCertificateId = item.BirthCertificateId,
                            BrithDate = item.BrithDate?.ToMiladiDateTime(),
                            FatherName = item.FatherName,
                            Gender = item.Gender,
                            IsCovered = item.IsCovered,
                            MaritalStatus = item.MaritalStatus,
                            ProvinceId = item.ProvinceId
                        };
                        lstSpouse.Add(newitem);
                        // }
                    }
                    foreach (var item in lstsponser.Where(s => s.Relation == (byte)Relation.Child))
                    {
                        var newitem = new Sponsorship()
                        {
                            SpouseMobile = item.SpouseMobile,
                            SpouseJob = item.SpouseJob,
                            EmploymentId = employmentId,
                            Name = item.Name,
                            Family = item.Family,
                            NationCode = item.NationCode,
                            Relation = item.Relation,
                            ProvinceOfIssueId = item.ProvinceOfIssueId,
                            SerialInsurance = item.SerialInsurance,
                            BasicInsurance = item.BasicInsurance,
                            BirthCertificateId = item.BirthCertificateId,
                            BrithDate = item.BrithDate?.ToMiladiDateTime(),
                            FatherName = item.FatherName,
                            Gender = item.Gender,
                            IsCovered = item.IsCovered,
                            MaritalStatus = item.MaritalStatus,
                            ProvinceId = item.ProvinceId,

                        };
                        lstSpouse.Add(newitem);
                    }

                    if (lstSpouse.Any())
                        await _repository.AddRangeEntities(lstSpouse);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        //public async Task<bool> EditSpouse(List<SpouseDTO> lst)
        //{
        //    try
        //    {
        //        foreach (var item in lst)
        //        {
        //            var spouse = _repository.GetQuery().AsQueryable().Where(s =>
        //                s.Relation == (byte)Relation.Spouse && s.EmploymentId == item.EmploymentId).ToList();
        //        }
        //        foreach (var item in list)
        //        {
        //            _repository.DeletePermanent(item);
        //            await _repository.SaveChanges();
        //        }
        //        var lstSpouse = new List<Sponsorship>();
        //        foreach (var item in lst)
        //        {
        //            // if ((item.SpouseJob != "") || (item.SpouseMobile != "") )
        //            //{
        //            var newitem = new Sponsorship()
        //            {
        //                SpouseMobile = item.SpouseMobile,
        //                SpouseJob = item.SpouseJob,
        //                EmploymentId = lst.First().EmploymentId,
        //                Name = item.Name,
        //                Family = item.Family,
        //                NationCode = item.NationCode,
        //                Relation = item.Relation,
        //                ProvinceOfIssueId = item.ProvinceOfIssueId,
        //                SerialInsurance = item.SerialInsurance,
        //                BasicInsurance = item.BasicInsurance,
        //                BirthCertificateId = item.BirthCertificateId,
        //                BrithDate = item.BrithDate.ToMiladiDateTime(),
        //                FatherName = item.FatherName,
        //                Gender = item.Gender,
        //                IsCovered = item.IsCovered,
        //                MaritalStatus = item.MaritalStatus,
        //                ProvinceId = item.ProvinceId
        //            };
        //            lstSpouse.Add(newitem);
        //            // }
        //        }
        //        if (lstSpouse.Any())
        //            await _repository.AddRangeEntities(lstSpouse);
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }

        //}
        public async Task<bool> AddSponsorShip(List<SpouseDTO> lst)
        {
            try
            {
                var list = await GetSponserRecode(lst.First().EmploymentId);//رکوردهای داخل دیتابیس
                foreach (var item in list)
                {
                    _repository.DeletePermanent(item);
                    await _repository.SaveChanges();
                }
                var lstSpouse = new List<Sponsorship>();
                foreach (var item in lst)
                {

                    var newitem = new Sponsorship()
                    {
                        SpouseMobile = item.SpouseMobile,
                        SpouseJob = item.SpouseJob,
                        EmploymentId = lst.First().EmploymentId,
                        Name = item.Name,
                        Family = item.Family,
                        NationCode = item.NationCode,
                        BasicInsurance = item.BasicInsurance,
                        BirthCertificateId = item.BirthCertificateId,
                        BrithDate = item.BrithDate.ToMiladiDateTime(),
                        FatherName = item.FatherName,
                        Gender = item.Gender,
                        IsCovered = item.IsCovered,
                        MaritalStatus = item.MaritalStatus,
                        ProvinceId = item.ProvinceId,
                        ProvinceOfIssueId = item.ProvinceOfIssueId,
                        Relation = item.Relation,
                        SerialInsurance = item.SerialInsurance
                    };
                    lstSpouse.Add(newitem);

                }
                if (lstSpouse.Any())
                    await _repository.AddRangeEntities(lstSpouse);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public async Task<bool> AddSupllementaryInfo(List<SponsershipDTO> lst, long employmentId)
        {
            try
            {
                List<Sponsorship> sponsorships = await _repository.GetQuery().AsQueryable()
                    .Where(e => e.EmploymentId == employmentId).ToListAsync();

                var listChild = lst.Where(x => x.Relation == (byte)Relation.Child).ToList();
                var listSpouse = lst.Where(x => x.Relation == (byte)Relation.Spouse).ToList();
                if (sponsorships.Any())
                {
                    #region Spouse

                    if (listSpouse.Any())
                    {

                        int index = 0;
                        foreach (var x in sponsorships)
                        {
                            var itemToChange = listSpouse.FirstOrDefault(d => d.EmploymentId == x.EmploymentId);
                            if (itemToChange != null)
                            {
                                x.Name = itemToChange.Name;
                                x.Family = itemToChange.Family;
                                x.FatherName = itemToChange.FatherName;
                                x.NationCode = itemToChange.NationCode;
                                x.BrithDate = itemToChange.BrithDate.ToMiladiDateTime();
                                x.ProvinceId = itemToChange.ProvinceId;
                                x.ProvinceOfIssueId = itemToChange.ProvinceOfIssueId;
                                x.MaritalStatus = itemToChange.MaritalStatus;
                                x.BasicInsurance = itemToChange.BasicInsurance;
                                x.Gender = itemToChange.Gender;
                                x.IsCovered = itemToChange.IsCovered;
                                x.BirthCertificateId = itemToChange.BirthCertificateId;
                                x.Relation = itemToChange.Relation;
                                x.SerialInsurance = itemToChange.SerialInsurance;
                            }

                            listSpouse.RemoveAt(index);
                            await _repository.SaveChanges();
                            index++;
                        }

                    }

                    #endregion

                    #region child

                    var childList = listChild
                        .Select(x => new Sponsorship()
                        {
                            EmploymentId = employmentId,
                            Name = x.Name,
                            Family = x.Family,
                            FatherName = x.FatherName,
                            NationCode = x.NationCode,
                            BrithDate = x.BrithDate.ToString()?.ToMiladiDateTime(),
                            ProvinceId = x.ProvinceId,
                            ProvinceOfIssueId = x.ProvinceOfIssueId,
                            MaritalStatus = x.MaritalStatus,
                            BasicInsurance = x.BasicInsurance,
                            Gender = x.Gender,
                            IsCovered = x.IsCovered,
                            BirthCertificateId = x.BirthCertificateId,
                            Relation = x.Relation,
                            SerialInsurance = x.SerialInsurance,
                        }
                        )
                        .ToList();
                    await _repository.AddRangeEntities(childList);

                    #endregion
                }
                else
                {
                    var targetList = lst
                    .Select(x => new Sponsorship()
                    {
                        EmploymentId = employmentId,
                        Name = x.Name,
                        Family = x.Family,
                        FatherName = x.FatherName,
                        NationCode = x.NationCode,
                        BrithDate = x.BrithDate.ToString()?.ToMiladiDateTime(),
                        ProvinceId = x.ProvinceId,
                        ProvinceOfIssueId = x.ProvinceOfIssueId,
                        MaritalStatus = x.MaritalStatus,
                        BasicInsurance = x.BasicInsurance,
                        Gender = x.Gender,
                        IsCovered = x.IsCovered,
                        BirthCertificateId = x.BirthCertificateId,
                        Relation = x.Relation,
                        SerialInsurance = x.SerialInsurance,
                    }
                    )
                    .ToList();
                    await _repository.AddRangeEntities(targetList);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
