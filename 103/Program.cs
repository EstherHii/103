using _103.Data;
using _103.IRepository;
using _103.IService;
using _103.Repository;
using _103.Service;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<UniDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("")));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<UniDbContext>(options =>
options.UseSqlServer(connectionString, sqlServerOptions =>
{
    sqlServerOptions.MigrationsAssembly("WebApi");
}));
builder.Services.AddTransient<IDbConnection>(_ => new SqlConnection(connectionString));

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IUnitService, UnitService>();
builder.Services.AddScoped<IUnitRepository, UnitRepository>();
builder.Services.AddScoped<IMarksService, MarksService>();
builder.Services.AddScoped<IMarksRepository, MarksRepository>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

/*app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
using IServiceScope scope = app.Services.CreateScope();
UniDbContext dbContext = scope.ServiceProvider.GetRequiredService<UniDbContext>();
IEnumerable<string> pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();

if (pendingMigrations.Any())
{
    await dbContext.Database.MigrateAsync();
}*/

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();


