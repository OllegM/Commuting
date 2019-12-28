using System;

namespace Transportation {
  public class Ticket
  {
    private readonly Transport _transport;
    public Ticket(Transport transport)
    {
      _transport = transport;
    }

    public string FromStation {get; set;}
    public string ToStation {get; set;}

    public string PrintInstructions()
    {
      return _transport.getInstruction(FromStation, ToStation);
    }
  }
}