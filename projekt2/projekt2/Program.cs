using projekt2.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


//tunapraw
builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
builder.Services.AddSingleton<IAnimalRepository, AnimalRepository>(); //wazne!!!
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
//dotad

var app = builder.Build();
app.Configuration.GetConnectionString("Default");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
