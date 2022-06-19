using ASquaredRonDB.Access;
using ASquaredRonDB.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsPolicy", opt =>
    {
        opt.AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod();
    });
});

builder.Services.AddSingleton<IDbAccess, DbAccess>();
builder.Services.AddScoped<IDbAccessContext, DbAccessContext>();

builder.WebHost.UseUrls("https://*:5011");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
