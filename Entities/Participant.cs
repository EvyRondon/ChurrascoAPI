using System.ComponentModel;
namespace Churrasco.Entities
{
  public class Participant
  {
    public int Id { get; set; }
    public String name { get; set; }
    [DefaultValue(20.0)]
    public Double price { get; set; }
  }
}