using Minimal_ASP.NET_Application;
using Minimal_ASP.NET_Application.Services;
using Minimal_ASP.NET_Application.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IBookService, BookService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Books}/{action=Index}/{id?}");

app.MapControllerRoute(

    name: "add",
    pattern: "{controller=Books}/{action=AddBook}");

app.MapControllerRoute(

    name: "remove",
    pattern: "{controller=Books}/{action=RemoveBook}");

app.UseMiddleware<CustomMiddleware>();

app.Run();
