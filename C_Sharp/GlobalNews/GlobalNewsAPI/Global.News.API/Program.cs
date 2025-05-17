using Global.News.API.DTOs.ResponseDTOs;
using Global.News.API.Repository.Implementations;
using Global.News.API.Repository.Services;
using Global.News.API.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IReadNewsService, ReadNewsServiceImplementation>();
builder.Services.AddScoped<ResponseDto>();

//builder.Services.AddHttpClient<IReadNewsService, ReadNewsServiceImplementation>(client =>
//{
//    client.BaseAddress = new Uri("https://newsapi.org/v2/");
//    client.DefaultRequestHeaders.Add("X-Api-Key", "YOUR_API_KEY");
//});

builder.Services.AddHttpClient();

StaticDetails.GlobalNewsApiUrl = builder.Configuration[key: "ServiceUrls:GlobalNewsApi"];

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
