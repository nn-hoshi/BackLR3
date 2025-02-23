// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;

// Настройка зависимостей
var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<IGreetingService, GreetingService>();
serviceCollection.AddTransient<App>();

// Создание провайдера сервисов
var serviceProvider = serviceCollection.BuildServiceProvider();

// Запуск приложения
var app = serviceProvider.GetService<App>();
app.Run();

// Интерфейс для сервиса приветствий
public interface IGreetingService
{
    string Greet(string name);
}

// Реализация сервиса приветствий
public class GreetingService : IGreetingService
{
    public string Greet(string name) => $"Hello, {name}!";
}

// Основной класс приложения
public class App
{
    private readonly IGreetingService _greetingService;

    public App(IGreetingService greetingService)
    {
        _greetingService = greetingService;
    }

    public void Run()
    {
        Console.WriteLine("Введите ваше имя:");
        var name = Console.ReadLine();
        var greeting = _greetingService.Greet(name);
        Console.WriteLine(greeting);
    }
}