using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Data.Entities;
using RealEstate.Services;
using RealEstate.Services.Agent;
using RealEstate.Services.Appointment;
using RealEstate.Services.Buyer;
using RealEstate.Services.HomeStyle;
using RealEstate.Services.Transaction;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IBuyerService, BuyerService>();
builder.Services.AddScoped<IAgentService, AgentService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IListingService, ListingService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IHomeStyleService, HomeStyleService>();

builder.Services.AddHttpContextAccessor();

// Add connection string and DbContext setup
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AgentEntity>(options =>
{
    // Password configuration
    options.Password.RequiredLength = 4;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
})

    .AddRoles<IdentityRole<int>>() // Enable Roles
    .AddEntityFrameworkStores<ApplicationDbContext>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();