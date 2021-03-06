using NUnit.Framework;

namespace Transportation.Tests
{
  public class TransportTests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TrainTest()
    {
      Train train = new Train()
      {
        TrainNumber = "10",
        CarNumber = "6",
        SeatNumber = "24"
      };

      Assert.That(train.getInstruction("Moscow", "Saint Petersburg"), Is.EqualTo("Take train 10 from Moscow to Saint Petersburg. Car 6, sit 24."));
    }

    [Test]
    public void AirportBusTest()
    {
      Bus airportbus = new Bus()
      {
        BusNumber = "airport",
        SeatNumber = ""
      };

      Assert.That(airportbus.getInstruction("Genua Center", "Genua Airport"), Is.EqualTo("Take the airport bus from Genua Center to Genua Airport. No seat assignment."));
    }

    [Test]
    public void CityBusTest()
    {
      Bus airportbus = new Bus()
      {
        BusNumber = "10",
        SeatNumber = "8"
      };

      Assert.That(airportbus.getInstruction("Central Square", "Downtown"), Is.EqualTo("Take the 10 bus from Central Square to Downtown. Seat: 8."));
    }

    [Test]
    public void FlightTestWithCounter()
    {
      Flight flight = new Flight()
      {
        FlightNumber = "AR2319",
        GateNumber = "16",
        BaggageCounter = "56",
        SeatNumber = "8"
      };

      Assert.That(flight.getInstruction("Moscow", "Berlin"), Is.EqualTo("From Moscow, take flight AR2319 to Berlin. Gate 16. Seat 8. Baggage drop at ticket counter 56."));
    }

    [Test]
    public void FlightTestNoCounter()
    {
      Flight flight = new Flight()
      {
        FlightNumber = "AR2319",
        GateNumber = "16",
        BaggageInstructions = "Baggage will be automatically transferred from your last leg.",
        SeatNumber = "8"
      };

      Assert.That(flight.getInstruction("Moscow", "Berlin"), Is.EqualTo("From Moscow, take flight AR2319 to Berlin. Gate 16. Seat 8. Baggage will be automatically transferred from your last leg."));
    }
  }
}