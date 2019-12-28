using System;
using System.Runtime.Serialization;

namespace Transportation {
  [DataContract()]
  public abstract class Transport : ITransport
  {
    public abstract string getInstruction(string fromStation, string toStation);
  }
}