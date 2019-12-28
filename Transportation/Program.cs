using System;
using System.Collections.Generic;

namespace Transportation
{
  class Program
  {
    static void Main(string[] args)
    {
      List<Ticket> tickets = new List<Ticket>();

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
        FromStation = "4 Helsinki",
        ToStation = "5 Rovaniemi"
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

      Sorter.SortTickets(tickets);

      foreach (var ticket in tickets)
      {
        Console.WriteLine(ticket.PrintInstructions());
      }
    }
  }
}
