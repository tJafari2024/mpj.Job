using Microsoft.EntityFrameworkCore;
using Mpj.Application.Services.Implementations;
using Mpj.Application.Services.Interfaces;
using Mpj.DataLayer.Context;
using Mpj.DataLayer.InMemoryCache;
using Mpj.DataLayer.Repository;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.AspNetCore.DataProtection;
using Mpj.Application.Services.Implementations.Admin;
using Mpj.Application.Services.Interfaces.Admin;
using Rotativa.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

#region config database
var connectionString = builder.Configuration.GetConnectionString("MPJConnection");
builder.Services.AddDbContext<MpgDbContext>(options => options.UseSqlServer(connectionString));
#endregion

//builder.Services.Configure<IISServerOptions>(options =>
//{
//    options.AutomaticAuthentication = false;
//});
builder.Services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin, UnicodeRanges.Arabic }));
#region Service
builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddControllersAsServices();
builder.Services.AddDataProtection()
    // use 14-day lifetime instead of 90-day lifetime
    .SetDefaultKeyLifetime(TimeSpan.FromDays(14));
builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IMemoryCache<>), typeof(DistributedMemoryCache<>));

builder.Services.AddScoped<ILowMemoryCache, LowMemoryCache>();
builder.Services.AddScoped<IAuthenticationMemoryCache, AuthenticationMemoryCache>();
builder.Services.AddScoped<IAuthorizationMemoryCache, AuthorizationMemoryCache>();
builder.Services.AddScoped<IAuthenticationWithSmsMemoryCache, AuthenticationWithSmsMemoryCache>();
builder.Services.AddScoped<ISpecificationMemoryCache, SpecificationMemoryCache>();
builder.Services.AddScoped<IPersonalImageMemoryCache, PersonalImageMemoryCache>();
builder.Services.AddScoped<IAbilitiesMemoryCache, AbilitiesMemoryCache>();
builder.Services.AddScoped<IAcquaintancesMemoryCache, AcquaintancesMemoryCache>();
builder.Services.AddScoped<IEducationalRecordMemoryCache, EducationalRecordMemoryCache>();
builder.Services.AddScoped<IWorkExperienceMemory, WorkExperienceMemory>();
builder.Services.AddScoped<IEndStepMemoryCache, EndStepMemoryCache>(); 
builder.Services.AddScoped<IDocumentMemoryCache, DocumentMemoryCache>();
builder.Services.AddScoped<IEditItemForEmploymentMemoryCache, EditItemForEmploymentMemoryCache>();
builder.Services.AddScoped<ISupplementaryInfoMemoryCache, SupplementaryInfoMemoryCache>();
builder.Services.AddScoped<ISponserShipMemoryCache, SponserShipMemoryCache>();
builder.Services.AddScoped<IEmploymentSpouseService, EmploymentSpouseService>();



builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IEducationalRecordService, EducationalRecordService>();
builder.Services.AddScoped<IWorkExperienceService, WorkExperienceService>();
builder.Services.AddScoped<IEmploymentService, EmploymentService>();
builder.Services.AddScoped<IUploadDocumentService, UploadDocumentService>();
builder.Services.AddScoped<IEditedItemsForEmploymentService, EditedItemsForEmploymentService>();

#region admin

builder.Services.AddScoped<IAdminEmploymentService, AdminEmploymentService>();


#endregion


#endregion

var app = builder.Build();

IConfiguration configuration = app.Configuration;


app.UseDeveloperExceptionPage();
//if (!app.Environment.IsDevelopment())
//{
app.UseExceptionHandler("/Error");
app.UseHsts();
//}

app.UseStatusCodePagesWithReExecute("/error/{0}");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRotativa();
app.UseRouting(); app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=index}/{id?}");

app.Run();
