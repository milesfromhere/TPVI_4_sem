
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

// Добавляем сервис HTTP-логирования
builder.Services.AddHttpLogging(logging =>
{
    // Настройка параметров логирования
    logging.LoggingFields = HttpLoggingFields.All; // Логируем все поля
    logging.RequestHeaders.Add("User-Agent"); // Логируем заголовок User-Agent
    logging.ResponseHeaders.Add("Content-Type"); // Логируем заголовок Content-Type
    logging.MediaTypeOptions.AddText("application/json"); // Логируем тело запроса/ответа для JSON
    logging.RequestBodyLogLimit = 4096; // Максимальный размер тела запроса для логирования (в байтах)
    logging.ResponseBodyLogLimit = 4096; // Максимальный размер тела ответа для логирования (в байтах)
});

var app = builder.Build();

// Используем middleware для HTTP-логирования
app.UseHttpLogging();

// Пример маршрута
app.MapGet("/1", () => "Hello, World!");
app.MapGet("/", () => "Моё первое ASPA");


app.Run();


///Program.Main

/*using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Hello, World!");

        app.Run();
    }
}*/