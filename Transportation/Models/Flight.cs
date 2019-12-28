using System;

namespace Transportation
{
  public class Flight : ITransport
  {
    public string flightNumber { get; set; } //номер рейса
    public string gateNumber { get; set; } //gate
    public string seatNumber { get; set; } // место
    public string baggageCounter { get; set; } // baggage instructions
    public string baggageInstructions { get; set; } // baggage instructions

    public string getInstruction(string fromStation, string toStation)
    {
      string baggageText = String.Empty;

      if (false == String.IsNullOrEmpty(baggageCounter))
      {
        baggageText += $" Baggage drop at ticket counter {baggageCounter}.";
      }

      if (false == String.IsNullOrEmpty(baggageInstructions))
      {
        baggageText += $" {baggageInstructions}";
      }

      return $"From {fromStation}, take flight {flightNumber} to {toStation}. Gate {gateNumber}. Seat {seatNumber}.{baggageText}";
    }
  }
}