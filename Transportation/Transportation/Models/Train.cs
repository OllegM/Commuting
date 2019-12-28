using System;

namespace Transportation {
  class Train : ITransport
  {
    public string trainNumber { get; set; } //номер поезда
    public string carNumber {get; set;} // номер вагона
    public string sitNumber {get; set;} // место

    public getInstruction (string fromStation, string toStation) {
      return $"Take train {trainNumber} from {from} to {to}. Car {carNumber}, sit {sitNumber}.";
    }
  }
}