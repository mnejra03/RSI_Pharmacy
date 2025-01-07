using Microsoft.EntityFrameworkCore;
using NewPharmacy.Data;
using NewPharmacy.Helper.Auth;
using NewPharmacy.Services;


var config = new ConfigurationBuilder()
.AddJsonFile("appsettings.json", false)
.Build();

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("db1")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => x.OperationFilter<MyAuthorizationSwaggerHeader>());
builder.Services.AddHttpContextAccessor();

//dodajte vaše servise
builder.Services.AddTransient<MyAuthService>();
var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
/*
 var builder = WebApplication.CreateBuilder(args);

// Omoguæavanje CORS-a
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder.WithOrigins("http://localhost:4200") // Angular radi na portu 4200
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();

// Koristite CORS
app.UseCors("AllowAngularApp");

app.MapControllers();

app.Run();

 */