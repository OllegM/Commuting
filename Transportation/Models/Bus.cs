using System;

namespace Transportation {
  public class Bus : ITransport
  {
    public string busNumber { get; set; } //номер автобуса
    public string seatNumber {get; set;} // место

    public string getInstruction (string fromStation, string toStation) {
      return $"Take the {busNumber} bus from {fromStation} to {toStation}. {(String.IsNullOrEmpty(seatNumber) ? "No seat assignment." : $"Seat: {seatNumber}.")}";
    }
  }
}