using Backend.Controllers;
using Backend.DAL.Entities;
using Backend.Services.Context;
using Backend.Services.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextPool<ApplicationContext>(options => options.UseSqlite(connectionString));

using (ApplicationContext db = new ApplicationContext())
{
    db.Users.Add(new User { Id = Guid.NewGuid() });
}

    builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
        });


builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<IChapterRepository, ChapterRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPointRepository, PointRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<ISubChapterRepository, SubChapterRepository>();
builder.Services.AddScoped<ITermRepository, TermRepository>();
builder.Services.AddScoped<ITestRepository, TestRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer()
    .AddSwaggerGen();


var app = builder.Build();

app.MapGraphQL();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
