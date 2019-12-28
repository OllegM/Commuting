using System;

namespace Transportation
{
  public class Flight : Transport
  {
    public string FlightNumber { get; set; } //номер рейса
    public string GateNumber { get; set; } //gate
    public string SeatNumber { get; set; } // место
    public string BaggageCounter { get; set; } // baggage instructions
    public string BaggageInstructions { get; set; } // baggage instructions

    public override string getInstruction(string fromStation, string toStation)
    {
      string baggageText = String.Empty; //do I need a stringbuilder for a few concatenations?

      if (false == String.IsNullOrEmpty(BaggageCounter))
      {
        baggageText += $" Baggage drop at ticket counter {BaggageCounter}.";
      }

      if (false == String.IsNullOrEmpty(BaggageInstructions))
      {
        baggageText += $" {BaggageInstructions}";
      }

      return $"From {fromStation} take flight {FlightNumber} to {toStation}. Gate {GateNumber}. Seat {SeatNumber}.{baggageText}";
    }
  }
}