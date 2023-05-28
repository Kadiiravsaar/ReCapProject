using Autofac;
using Autofac.Extensions.DependencyInjection;
using Buisness.DependencyResolvers.AutoFac;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Ultities.IoC;
using Core.Ultities.Security.Encryption;
using Core.Ultities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory
    (new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new AutoFacBuisnessModule()));



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




var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)

        };

    });



builder.Services.AddDependencyResolvers(new ICoreModule[] { new CoreModule() });




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
