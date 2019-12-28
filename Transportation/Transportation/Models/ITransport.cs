using System;

namespace Transportation
{
  public interface ITransport<T>
  {
    public string getInstruction(string fromStation, string Transportation);
  }
}