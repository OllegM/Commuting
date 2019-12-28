using System;

namespace Transportation {
  public class Train : ITransport
  {
    public string trainNumber { get; set; } //номер поезда
    public string carNumber {get; set;} // номер вагона
    public string seatNumber {get; set;} // место

    public string getInstruction (string fromStation, string toStation) {
      return $"Take train {trainNumber} from {fromStation} to {toStation}. Car {carNumber}, sit {seatNumber}.";
    }
  }
}