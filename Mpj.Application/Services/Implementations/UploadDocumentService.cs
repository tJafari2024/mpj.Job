
using System.Data;
using Mpj.Application.Services.Interfaces;
using Mpj.DataLayer.DTOs.EmploymentForm;
using Mpj.DataLayer.Entities.EmploymentForm;
using Mpj.DataLayer.Repository;
using System.Reflection;
using Microsoft.Data.SqlClient;
using Mpj.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Mpj.Application.Services.Implementations
{
    public class UploadDocumentService : IUploadDocumentService
    {
        private readonly IGenericRepository<RegistrationDocuments> _repository;
        //private readonly IEmploymentService _employmentService;
        private readonly MpgDbContext _context;

        public UploadDocumentService(IGenericRepository<RegistrationDocuments> repository, MpgDbContext context)
        {
            _repository = repository;
            _context = context;
        }
        public async ValueTask DisposeAsync()
        {
            await _repository.DisposeAsync();
        }

        public async Task<List<RegistrationDocuments>> GetEmploymentDocument(long employmentId)
        {
            return await _repository.GetQuery().AsQueryable().Where(d => d.EmploymentId == employmentId)
                .ToListAsync();
            
        }

        public async Task<bool> UploadDocument(List<DocumentFileDTO> lstDoc)
        {
              string lst = "";
                foreach (var doc in lstDoc)
                {
                  lst+= doc.EmploymentId.ToString()+","+((int)doc.TypeDocument).ToString()+","+doc.FileName+"~";
              
                }

                lst = lst.Substring(0, lst.Length - 1);
                var document = new SqlParameter("@lst", lst);
                var result = new SqlParameter("@Result", SqlDbType.Bit)
                    { Direction = ParameterDirection.Output };
                try
                {
                    _context.Database.ExecuteSqlRaw("EXEC dbo.InsertDocuments @lst,@Result OUTPUT", document, result);
                    await _context.SaveChangesAsync();
                    return (bool)result.Value;

                }
                catch (Exception e)
                {
                    return (bool)result.Value;
                }
              
        }
    }
}
