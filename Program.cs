using Microsoft.EntityFrameworkCore;
using MaritimeData.Models;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>{
    options.AddPolicy("AllowFrontend",
    policy => policy.WithOrigins("http://localhost:4200")
    .AllowAnyHeader()
    .AllowAnyMethod());
    
});

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();




builder.Services.AddOpenApi();

var app = builder.Build();
app.UseCors("AllowFrontend");

using (var scope = app.Services.CreateScope()){
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    try{
        dbContext.Database.CanConnect();
        Console.WriteLine("Conexiunea la baza de date a fost stabilita cu succes");
    } catch(Exception ex){
        Console.WriteLine("Eroare la conectarea la baza de date" + ex.Message);
    }
}


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();


