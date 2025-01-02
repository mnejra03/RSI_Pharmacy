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
