using System;

namespace Transportation
{
  public class Flight : Transport
  {
    public string FlightNumber { get; set; } //номер рейса
    public string GateNumber { get; set; } //gate
    public string SeatNumber { get; set; } // место
    public string BaggageCounter { get; set; } // стойка регистрации
    public string BaggageInstructions { get; set; } // инструкции для багажа

    public override string getInstruction(string fromStation, string toStation)
    {
      string baggageText = String.Empty; //нужен ли stringbuilder для пары сложений?

      if (false == String.IsNullOrEmpty(BaggageCounter))
      {
        baggageText += $" Baggage drop at ticket counter {BaggageCounter}.";
      }

      if (false == String.IsNullOrEmpty(BaggageInstructions))
      {
        baggageText += $" {BaggageInstructions}";
      }

      return $"From {fromStation}, take flight {FlightNumber} to {toStation}. Gate {GateNumber}. Seat {SeatNumber}.{baggageText}";
    }
  }
}