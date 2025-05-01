using Microsoft.EntityFrameworkCore;
using MaritimeData.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();



// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

using (var scope = app.Services.CreateScope()){
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    try{
        dbContext.Database.CanConnect();
        Console.WriteLine("Conexiunea la baza de date a fost stabilita cu succes");
    } catch(Exception ex){
        Console.WriteLine("Eroare la conectarea la baza de date" + ex.Message);
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapControllers();
app.Run();


