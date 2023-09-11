using BlogApp.Api;
using BlogApp.Application.Comments;
using BlogApp.Application.Posts;
using BlogApp.Contracts.Comments.Commands;
using BlogApp.Contracts.Posts.Commands;
using BlogApp.Contracts.Posts.Repositories;
using BlogApp.Infrastructure;
using BlogApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<BlogDbContext>(options =>
    options.UseSqlServer(connectionString)
);
// Add services to the container.

builder.Services.AddControllers(config => 
{
    config.Filters.Add(new FilterAction());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a=> a.FullName.Contains("BlogApp.Contracts")).ToArray();
builder.Services.AddMediatR(conf => conf.RegisterServicesFromAssemblies(assemblies));

builder.Services.AddScoped<IPostRepository , PostRepository>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICommentService , CommentService>();

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
