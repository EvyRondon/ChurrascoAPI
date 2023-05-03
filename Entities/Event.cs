namespace Churrasco.Entities
{
  public class Event
  {
    public int Id { get; set; }
    public DateTime date { get; set; }
    public String description { get; set; }
    public String moreInformations { get; set; }
    public List<Participant> participant { get; set; }
  }
}