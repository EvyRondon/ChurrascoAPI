using Churrasco.Context;
using Churrasco.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Churrasco.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ParticipantController : ControllerBase
  {
    private readonly ChurrascoContext _context;
    public ParticipantController(ChurrascoContext context)
    {
      _context = context;
    }

    [HttpPost]
    public IActionResult Create(Participant participant)
    {
      _context.Add(participant);
      _context.SaveChanges();
      return Ok(participant);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var participantBD = _context.Participants.Find(id);

      if (participantBD == null)
        return NotFound();

      _context.Participants.Remove(participantBD);
      _context.SaveChanges();
      return NoContent();
    }

    [HttpGet("{id}")]
    public IActionResult ObterPorId(int id)
    {
      var participant = _context.Participants.Find(id);

      if (participant == null)
        return NotFound();

      return Ok(participant);
    }
  }
}