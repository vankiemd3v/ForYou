using Data.EF;
using ForYou.AutoMapper;
using ForYou.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ForYouDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("KeyConnect"));
});

builder.Services.AddScoped<IContractService, ContractService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// Đăng ký AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

// Thêm RazorPage để xem được thay đổi
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
