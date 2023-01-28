using Microsoft.EntityFrameworkCore;
using System.Net;
using Uzbekgram.DataAccess.DbContexts;
using Uzbekgram.DataAccess.Interfaces;
using Uzbekgram.DataAccess.Repositories;
using Uzbekgram.Service.Interfaces;
using Uzbekgram.Service.Interfaces.Accounts;
using Uzbekgram.Service.Interfaces.Verify;
using Uzbekgram.Service.Security;
using Uzbekgram.Service.Services;
using Uzbekgram.Service.Services.Accounts;
using Uzbekgram.Service.Services.Verify;
using Uzbekgram.Web.Configurations.LayerConfigarions;
using Uzbekgram.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddWeb(builder.Configuration);

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IVerifyEmailService, VerifyEmailService>();

var app = builder.Build();

app.UseStaticFiles();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseStatusCodePages(async context =>
{
    if (context.HttpContext.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
    {
        context.HttpContext.Response.Redirect("accounts/login");
    }
});
app.UseMiddleware<TokenRedirectMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
