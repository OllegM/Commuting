using System;

namespace Transportation
{
  public interface ITransport
  {
    // public string TransportType { get; }
    public string getInstruction(string fromStation, string Transportation);
  }
}