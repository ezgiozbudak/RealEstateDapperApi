using RealEstateDapperApi.Hubs;
using RealEstateDapperApi.Models.DapperContext;
using RealEstateDapperApi.Repositories.BottomGridRepositories;
using RealEstateDapperApi.Repositories.CategoryRepository;
using RealEstateDapperApi.Repositories.ContactRepositories;
using RealEstateDapperApi.Repositories.EmployeeRepositories;
using RealEstateDapperApi.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories;
using RealEstateDapperApi.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;
using RealEstateDapperApi.Repositories.PopularLocationRepositories;
using RealEstateDapperApi.Repositories.ProductRepository;
using RealEstateDapperApi.Repositories.ServiceRepository;
using RealEstateDapperApi.Repositories.StatisticsRepositories;
using RealEstateDapperApi.Repositories.TestimonialRepository;
using RealEstateDapperApi.Repositories.ToDoListRepositories;
using RealEstateDapperApi.Repositories.WhoWeAreRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ICategoryRepository,CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IWhoWeAreRepository, WhoWeAreRepository>();
builder.Services.AddTransient<IServiceRepository, ServiceRepository>();
builder.Services.AddTransient<IBottomGridRepository, BottomGridRepository>();
builder.Services.AddTransient<IPopularLocationRepository,PopularLocationRepository>();
builder.Services.AddTransient<IStatisticsRepository,StatisticsRepository>();
builder.Services.AddTransient<ITestimonialRepository, TestimonialRepository>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<IToDoListRepository, ToDoListRepository>();
builder.Services.AddTransient<IStatisticRepository,StatisticRepository>();
builder.Services.AddTransient<IChartRepository, ChartRepository>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod().AllowAnyMethod()
        .SetIsOriginAllowed((host) => true).AllowCredentials();
    });
});

builder.Services.AddHttpClient();

builder.Services.AddSignalR();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");

app.Run();
