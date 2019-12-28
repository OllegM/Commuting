using System.Collections.Generic;
using NUnit.Framework;

namespace Transportation.Tests
{
  public class SortingTests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
      var tickets = new List<Ticket<Transport>>();

      Train train = new Train()
      {
        TrainNumber = "001",
        CarNumber = "0",
        SeatNumber = "0"
      };

      tickets.Add(new Ticket<Transport>(train)
      {
        FromStation = "Helsinki",
        ToStation = "Rovaniemi"
      });

      tickets.Add(new Ticket<Transport>(train)
      {
        FromStation = "SPb",
        ToStation = "Helsinki"
      });

      tickets.Add(new Ticket<Transport>(train)
      {
        FromStation = "Moscow",
        ToStation = "SPb"
      });

      tickets.Add(new Ticket<Transport>(train)
      {
        FromStation = "Novosibirsk",
        ToStation = "Moscow"
      });

      Sorter<Transport>.SortTickets(tickets);

      Assert.That(tickets[0].FromStation, Is.EqualTo("Novosibirsk"));
      Assert.That(tickets[1].FromStation, Is.EqualTo("Moscow"));
      Assert.That(tickets[2].FromStation, Is.EqualTo("SPb"));
      Assert.That(tickets[3].FromStation, Is.EqualTo("Helsinki"));
    }
  }
}