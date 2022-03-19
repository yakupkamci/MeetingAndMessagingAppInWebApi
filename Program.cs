
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(opt=>{
    opt.RegisterValidatorsFromAssemblyContaining<Program>();
}).AddJsonOptions(x=>x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);;

builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddScoped<SahaBTMeetContext>();
builder.Services.AddScoped<IAccountService,AccountService>();
builder.Services.AddScoped<IAccountRepository,AccountRepository>();
builder.Services.AddScoped<IRoleService,RoleService>();
builder.Services.AddScoped<IRoleRepository,RoleRepository>();
builder.Services.AddScoped<IAddressService,AddressService>();
builder.Services.AddScoped<IAddressRepository,AddressRepository>();
builder.Services.AddScoped<IDepartmanService,DepartmanService>();
builder.Services.AddScoped<IDepartmanRepository,DepartmanRepository>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IIndividualMessageService,IndividualMessageService>();
builder.Services.AddScoped<IIndividualMessageRepository,IndividualMessageRepository>();
builder.Services.AddScoped<IMeetingService,MeetingService>();
builder.Services.AddScoped<IMeetingRepository,MeetingRepository>();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
