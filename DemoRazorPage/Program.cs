using DemoRazorPage.Data;
using DemoRazorPage.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddAuthentication("myCookie").AddCookie("myCookie", (options) =>
{
    options.Cookie.Name = "myCookie";
});

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Cart");
    options.Conventions.AuthorizePage("/CarView/Create");
    options.Conventions.AuthorizePage("/CarView/Update");
    options.Conventions.AuthorizePage("/CarView/Delete");
    options.Conventions.AuthorizePage("/CarView/AddToCart");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
