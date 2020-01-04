using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Transportation
{
  class Program
  {
    private static void Main(string[] args)
    {
		if (ArgumentsAreEmpty(args)) 
		{
		    PrintUsage();
		}
		else if (RequestForSample(args[0]))
		{
			GenerateSampleJSON();
		} 
		else 
		{
			ProcessTickets(args[0]);
		}
	}
	
	private static bool ArgumentsAreEmpty(string[] args) {
		return args.Length == 0;
	}
	
	private static bool RequestForSample(string arg) {
		return arg.ToLower() == "example";
	}

    private static void PrintUsage()
    {
      Console.WriteLine("Использование:");
      Console.WriteLine("Transportation [filename] - Чтение JSON файла и сортировка билетов");
      Console.WriteLine("Transportation example - вывод на экран примера JSON файла");
    }
	
	private static void ProcessTickets(string fileName) {

      string ticketsString;
      // прочитать JSON файл с несортированными билетами
      if (File.Exists(fileName))
      {
        ticketsString = File.ReadAllText(fileName);
      }
      else
      {
        Console.WriteLine($"File not found: {fileName}");
        return;
      }

      var options = new JsonSerializerOptions();
      // подключаем свой конвертер для JSON с билетами
      options.Converters.Add(new TicketConverter());

      List<Ticket> tickets = null;
      // десериализация JSON файла
      try
      {
        tickets = JsonSerializer.Deserialize<List<Ticket>>(ticketsString, options);
      }
      catch (System.Exception ex)
      {
        Console.WriteLine($"Error reaing JSON file: {ex.Message}");
        return;
      }

      // сортировка билетов
      Sorter.SortTickets(tickets);

      // вывод указаний по порядку использования билетов
      foreach (var ticket in tickets)
      {
        Console.WriteLine(ticket.PrintInstructions());
      }
    }
	
    private static void GenerateSampleJSON()
    {
      var tickets = new List<Ticket>();

      Train train = new Train()
      {
        TrainNumber = "001",
        CarNumber = "6",
        SeatNumber = "12"
      };

      Flight flight = new Flight()
      {
        FlightNumber = "AB0001",
        GateNumber = "16",
        SeatNumber = "24",
        BaggageCounter = "58"
      };

      tickets.Add(new Ticket(flight)
      {
        FromStation = "5 Helsinki Airport",
        ToStation = "6 Rovaniemi"
      });

      tickets.Add(new Ticket(train)
      {
        FromStation = "3 SPb",
        ToStation = "4 Helsinki"
      });

      tickets.Add(new Ticket(train)
      {
        FromStation = "2 Moscow",
        ToStation = "3 SPb"
      });

      tickets.Add(new Ticket(train)
      {
        FromStation = "1 Novosibirsk",
        ToStation = "2 Moscow"
      });

      tickets.Add(new Ticket(new Bus() { BusNumber = "airport" })
      {
        FromStation = "4 Helsinki",
        ToStation = "5 Helsinki Airport"
      });

      var options = new JsonSerializerOptions();
      options.Converters.Add(new TransportConverter());
      options.WriteIndented = true;
      Console.WriteLine(JsonSerializer.Serialize<List<Ticket>>(tickets, options));
    }
  }
}