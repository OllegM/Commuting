using System;

namespace Transportation {
  public class Bus : Transport
  {
    public string BusNumber { get; set; } //номер автобуса
    public string SeatNumber {get; set;} // место

    public override string getInstruction (string fromStation, string toStation) {
      return $"Take the {BusNumber} bus from {fromStation} to {toStation}. {(String.IsNullOrEmpty(SeatNumber) ? "No seat assignment." : $"Seat: {SeatNumber}.")}";
    }
  }
}