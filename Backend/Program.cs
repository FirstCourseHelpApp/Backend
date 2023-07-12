using Backend;
using Backend.Controllers;
using Backend.DAL.Entities;
using Backend.Services.Auth;
using Backend.Services.Context;
using Backend.Services.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddHttpClient();
builder.Services.AddGraphQLServer();
builder.Services.AddAuthorization();


builder.Services.AddDataProtection();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.Issuer,
            ValidateAudience = true,
            ValidAudience = AuthOptions.Audience,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddDbContext<FirstCusrHelpAppContext>(options => options.UseSqlite("Data Source=firstCursHelpApp.db"));


builder.Services
    .AddGraphQLServer()
    .AddAuthorization()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .AddMutationConventions()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .RegisterDbContext<FirstCusrHelpAppContext>();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});


builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<IChapterRepository, ChapterRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPointRepository, PointRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<ISubChapterRepository, SubChapterRepository>();
builder.Services.AddScoped<ITermRepository, TermRepository>();
builder.Services.AddScoped<ITestRepository, TestRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapGraphQL();
app.UseCors();

// Configure the HTTP request pipeline.


app.Run();
