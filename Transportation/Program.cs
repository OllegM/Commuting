using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Transportation
{
  class Program
  {
    static void Main(string[] args)
    {
      var tickets = new List<Ticket<Transport>>();

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

      tickets.Add(new Ticket<Transport>(flight)
      {
        FromStation = "4 Helsinki",
        ToStation = "5 Rovaniemi"
      });

      tickets.Add(new Ticket<Transport>(train)
      {
        FromStation = "3 SPb",
        ToStation = "4 Helsinki"
      });

      tickets.Add(new Ticket<Transport>(train)
      {
        FromStation = "2 Moscow",
        ToStation = "3 SPb"
      });

      tickets.Add(new Ticket<Transport>(train)
      {
        FromStation = "1 Novosibirsk",
        ToStation = "2 Moscow"
      });

      Sorter<Transport>.SortTickets(tickets);

      //   foreach (var ticket in tickets)
      //   {
      //     Console.WriteLine(ticket.PrintInstructions());
      //   }

    //   Ticket<Flight> tf = new Ticket<Flight>(flight)
    //   {
    //     FromStation = "1 Novosibirsk",
    //     ToStation = "2 Moscow"
    //   };
    //   Console.WriteLine(JsonSerializer.Serialize<Ticket<Flight>>(tf, null));
        Console.WriteLine(JsonSerializer.Serialize<List<Ticket<Transport>>> (tickets, 
        new JsonSerializerOptions() {

        }));
    }
  }
}
