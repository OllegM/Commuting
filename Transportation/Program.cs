using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Transportation
{
  class Program
  {
    static void Main(string[] args)
    {
      // прочитать билеты из JSON файла
      string ticketsString = File.ReadAllText(@"./Transportation/tickets.json");

      var options = new JsonSerializerOptions();
      // подключаем свой конвертер для JSON с билетами
      options.Converters.Add(new TicketConverter());
      // десериализация JSON файла
      List<Ticket> tickets = JsonSerializer.Deserialize<List<Ticket>>(ticketsString, options);

      // сортировка билетов
      Sorter.SortTickets(tickets);

      // вывод указаний по порядку использования билетов
      foreach (var ticket in tickets)
      {
        Console.WriteLine(ticket.PrintInstructions());
      }

      // Сгеренировать пример JSON с билетами
      // GenerateCards();
    }

    static void GenerateCards()
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
