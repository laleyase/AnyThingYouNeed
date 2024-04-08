
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using AnyThingYouNeed.Bussiness.Abstract;
using AnyThingYouNeed.Bussiness.Concrate;
using AnyThingYouNeed.DataAccess.Abstract;
using AnyThingYouNeed.DataAccess.Concrate;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(logging =>
{
    logging.AddConsole();
    logging.AddDebug();
});

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddDbContext<AnyThingYouNeedContext>(options =>
{
    options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;initial catalog=AnyThingYouNeed;integrated security=SSPI"); // Veritabaný baðlantý dizesini burada belirtin
});

builder.Services.AddScoped<AnyThingYouNeedContext>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IUserDal, UserDal>();
builder.Services.AddScoped<IRequestService, RequestManager>();
builder.Services.AddScoped<IRequestDal, RequestDal>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();