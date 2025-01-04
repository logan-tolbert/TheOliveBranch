using Microsoft.EntityFrameworkCore;
using TheOliveBranch.Contracts;
using TheOliveBranch.Data;
using TheOliveBranch.Repo;

var builder = WebApplication.CreateBuilder(args);

#region Services

builder.Services.AddRazorPages();
builder.Services.AddDbContext<OliveBranchDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

#endregion

var app = builder.Build();

#region Middleware pipeline

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();

#endregion