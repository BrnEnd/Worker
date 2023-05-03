using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using WorkerAgendamento.UseCase;

class Program
{
    static bool isTaskRunning = false;

    
    static void Main(string[] args)
    {

        Timer timer = new Timer(Callback, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        Console.ReadLine();
    }

    static void Callback(object state)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MySql"].ConnectionString;
        UseCaseAgendamento agendamento = new UseCaseAgendamento();
        if (!isTaskRunning)
        {
            isTaskRunning = true;
            Console.WriteLine($"Iniciando a tarefa em: {DateTime.Now}");

            agendamento.ExistingNewAgendamento(connectionString);

            Console.WriteLine($"A tarefa foi concluída em: {DateTime.Now}");
            isTaskRunning = false;
        }
        else
        {
            Console.WriteLine($"A tarefa anterior ainda está em execução em: {DateTime.Now}");
        }
    }
}