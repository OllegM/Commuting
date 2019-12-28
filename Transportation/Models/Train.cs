using System;

namespace Transportation {
  public class Train : Transport
  {
    public string TrainNumber { get; set; } //номер поезда
    public string CarNumber {get; set;} // номер вагона
    public string SeatNumber {get; set;} // место

    public override string getInstruction (string fromStation, string toStation) {
      return $"Take train {TrainNumber} from {fromStation} to {toStation}. Car {CarNumber}, sit {SeatNumber}.";
    }
  }
}