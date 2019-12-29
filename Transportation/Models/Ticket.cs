namespace Transportation
{
  public class Ticket
  {
    public Ticket() { }
    public Ticket(Transport transport)
    {
      Transport = transport;
    }
    public string FromStation { get; set; }
    public string ToStation { get; set; }
    public string TransportType
    {
      get
      {
        return Transport.GetType().FullName;
      }
    }
    public Transport Transport { get; set; }

    public string PrintInstructions()
    {
      return Transport.getInstruction(FromStation, ToStation);
    }
  }
}