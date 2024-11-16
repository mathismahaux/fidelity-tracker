using Application.UseCases;
using Application.UseCases.Gift.Create;
using Application.UseCases.Gift.FetchAll;
using Application.UseCases.Person.AssignSponsor;
using Application.UseCases.Person.Create;
using Application.UseCases.Person.FetchAll;
using Application.UseCases.Person.GetDetails;
using Application.UseCases.Person.GiveGift;
using Application.UseCases.Person.SearchByName;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var corsPolicyName = "AllowAllOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName, policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ProfileMapper));

builder.Services.AddDbContext<FidelityTrackerDbContext>(cfg => 
    cfg.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")
    ));

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IGiftRepository, GiftRepository>();

builder.Services.AddScoped<UseCaseFetchAllPeople>();
builder.Services.AddScoped<UseCaseCreatePerson>();
builder.Services.AddScoped<UseCaseAssignSponsor>();
builder.Services.AddScoped<UseCaseSearchPersonByName>();
builder.Services.AddScoped<UseCaseGetPersonDetails>();
builder.Services.AddScoped<UseCaseGiveGiftToPerson>();

builder.Services.AddScoped<UseCaseFetchAllGifts>();
builder.Services.AddScoped<UseCaseCreateGift>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(corsPolicyName);

app.UseResponseCaching();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();