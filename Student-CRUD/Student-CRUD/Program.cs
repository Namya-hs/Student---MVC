using Microsoft.EntityFrameworkCore;
using Student_CRUD.DataAccess;
using Student_CRUD.Database;

var builder = WebApplication.CreateBuilder(args);
//Database
builder.Services.AddDbContext<StudentContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StudentContext>();
builder.Services.AddScoped<IStudentRespository, StudentRepository>();

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
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();
