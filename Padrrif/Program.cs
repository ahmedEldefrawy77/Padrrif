using Microsoft.OpenApi.Models;
using Padrrif;
using Padrrif.Authorization;
using Padrrif.UnitOfWork;
using Padrrif.UnitOfWork.Interface;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
        });
});

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
               .EnableDetailedErrors()
               .EnableSensitiveDataLogging()
               .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
//builder.Services.AddDbContext<ApplicationDbContext>(options => {

//    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
//           .EnableDetailedErrors()
//           .EnableSensitiveDataLogging()
//           .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
//});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequirePrivilege", policy =>
        policy.Requirements.Add(new PrivilegeRequirement(new[] { "Add_New_Farms", "Edit_Farm_Data", "Delete_Farm_Data", "View_Farmers_Archive", "Add_New_Damage_Documentation_Form"
        ,"Edit_Damage_Documentation_Form","View_Damage_Documentation_Forms_Archive","Sign_Damage_Documentation_Form","Damage_Settings","Add_New_Price_Sheet","Price_Settings",
            "Link_Units_to_Pricing_for_Agricultural_Units","Delete/Edit_or_Activate/Deactivate_Prices","View_Prices","Edit_Compensations","Compensations_Archive",
            "Completed_Compensations","Sign_the_Form","View_Statistics","View_Evaluations","Error_Corrector","Follow_up_Forms_Entered_by_the_Farmer","View_Paid_Compensation_Item",
            "Verification","View_Only_Account","View_Farm_Evaluation_Archive","Agricultural_Holdings","View_Paid_Expenses_in_sheet_index_Section","Access_Deleted_Villages_in_Damage_Archive"})));
});

builder.Services.AddOptions();
builder.Services.ConfigureOptions<JwtAccessOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();


builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IAuthUnitOfWork, AuthUnitOfWork>();
builder.Services.AddSingleton<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IGovernorateUnitOfWork, GovernorateUnitOfWork>();
builder.Services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
builder.Services.AddScoped<IPriviliegeUnitOfWork, PriviliegeUnitOfWork>();
builder.Services.AddScoped<INotifactionUnitOfWork, NotifactionUnitOfWork>();
builder.Services.AddScoped<IComitteeUnitOfWork, ComitteeUnitOfWork>();
builder.Services.AddScoped<IEducationLevelDtoUnitOfWork, EducationLevelDtoUnitOfWork>();
builder.Services.AddScoped<IVillageUnitOfWork, VillageUnitOfWork>();
builder.Services.AddScoped<IOwnerShipTypeUnitOfWork, OwnerShipTypeUnitOfWork>();
builder.Services.AddScoped<IDamageUnitOfWork, DamageUnitOfWork>();
builder.Services.AddScoped<IUserPrivilegeUnitOfWork, UserPrivilegeUnitOfWork>();
builder.Services.AddScoped<IPriviliegeUnitOfWork, PriviliegeUnitOfWork>();


builder.Services.AddSingleton<NotificationHubConecctedUsers>();
builder.Services.AddSingleton<IAuthorizationHandler, PrivilegeHandler>();

builder.Services.AddSignalR();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseAuthorization();


app.UseHttpsRedirection();

app.MapControllers();

app.MapHub<NotificationHub>("/notification-Hub");

app.MapFallbackToFile("index.html");


app.Run();
