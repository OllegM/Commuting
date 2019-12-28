using System;

namespace Transportation {
  public abstract class Transport : ITransport
  {
    public abstract string getInstruction(string fromStation, string toStation);
  }
}