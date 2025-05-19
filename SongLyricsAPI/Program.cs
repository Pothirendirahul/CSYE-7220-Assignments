var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "5000"; // (you can change port here if you want)

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "API is running");

// Listen on all network interfaces (0.0.0.0) on port 5000
app.Urls.Add("http://0.0.0.0:5000");

app.Run();


