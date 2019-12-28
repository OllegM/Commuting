using System;
using System.Runtime.Serialization;

namespace Transportation
{
  public class Ticket<T> where T : Transport
  {
    private readonly T _transport;
    public Ticket(T transport)
    {
      _transport = transport;
    }

    public T Transport
    {
      get
      {
        return _transport;
      }
    }
    public string FromStation { get; set; }
    public string ToStation { get; set; }

    public string PrintInstructions()
    {
      return _transport.getInstruction(FromStation, ToStation);
    }
  }
}