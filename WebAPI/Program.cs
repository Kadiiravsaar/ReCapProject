using Autofac.Extensions.DependencyInjection;
using Autofac;
using Buisness.Abstract;
using Buisness.Concrete;
using Buisness.Constants.Messages;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Buisness.DependencyResolvers.AutoFac;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<IBrandService, BrandManager>();
//builder.Services.AddScoped<IBrandDal, EFBrandDal>();

//builder.Services.AddScoped<ICarService, CarManager>();
//builder.Services.AddScoped<ICarDal, EFCarDal>();

//builder.Services.AddScoped<IColorService, ColorManager>();
//builder.Services.AddScoped<IColorDal, EFColorDal>();

//builder.Services.AddScoped<ICustomerService, CustomerManager>();
//builder.Services.AddScoped<ICustomerDal, EFCustomerDal>();

//builder.Services.AddScoped<IRentalService, RentalManager>();
//builder.Services.AddScoped<IRentalDal, EFRentalDal>();

//builder.Services.AddScoped<IUserService, UserManager>();
//builder.Services.AddScoped<IUserDal, EFUserDal>();

builder.Host.UseServiceProviderFactory
    (new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new AutoFacBuisnessModule()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
