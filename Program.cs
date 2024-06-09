using Microsoft.EntityFrameworkCore;
using MindWell_ResourcesServices.Resource.Domain.Repositories;
using MindWell_ResourcesServices.Resource.Domain.Services;
using MindWell_ResourcesServices.Resource.Mapping;
using MindWell_ResourcesServices.Resource.Persistence.Repositories;
using MindWell_ResourcesServices.Resource.Services;
using MindWell_ResourcesServices.Shared.Persistence.Contexts;
using MindWell_ResourcesServices.Shared.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddHttpClient<NhsApiService>();
builder.Services.AddScoped<ResourceRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString)
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors());

// Add lowercase routes
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Dependency injection
builder.Services.AddScoped<IResourceRepository, ResourceRepository>();
builder.Services.AddScoped<IResourceService, ResourceService>();
builder.Services.AddScoped<IUserResourceRepository, UserResourceRepository>();
builder.Services.AddScoped<IUserResourceService, UserResourceService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AutoMapper Configuration
builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ResourceToModelProfile));

var app = builder.Build();

// Validation for ensuring Database Objects are created
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

/*// NO MOSTRAR SWAGGER EN PRODUCCION
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

// MOSTRAR SWAGGER EN PRODUCCION
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // Serve Swagger at the app's root
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
