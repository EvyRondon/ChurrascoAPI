using Churrasco.Entities;
using Microsoft.EntityFrameworkCore;

namespace Churrasco.Context
{
  public class ChurrascoContext : DbContext
  {
    public ChurrascoContext(DbContextOptions<ChurrascoContext> options) : base(options)
    {

    }

    public DbSet<Event> Events { get; private set; }
    public DbSet<Participant> Participants { get; private set; }
  }
}