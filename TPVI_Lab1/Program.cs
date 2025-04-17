
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

// ��������� ������ HTTP-�����������
builder.Services.AddHttpLogging(logging =>
{
    // ��������� ���������� �����������
    logging.LoggingFields = HttpLoggingFields.All; // �������� ��� ����
    logging.RequestHeaders.Add("User-Agent"); // �������� ��������� User-Agent
    logging.ResponseHeaders.Add("Content-Type"); // �������� ��������� Content-Type
    logging.MediaTypeOptions.AddText("application/json"); // �������� ���� �������/������ ��� JSON
    logging.RequestBodyLogLimit = 4096; // ������������ ������ ���� ������� ��� ����������� (� ������)
    logging.ResponseBodyLogLimit = 4096; // ������������ ������ ���� ������ ��� ����������� (� ������)
});

var app = builder.Build();

// ���������� middleware ��� HTTP-�����������
app.UseHttpLogging();

// ������ ��������
app.MapGet("/1", () => "Hello, World!");
app.MapGet("/", () => "�� ������ ASPA");


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