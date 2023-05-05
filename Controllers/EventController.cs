using Churrasco.Context;
using Churrasco.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ChurrascoAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class EventController : ControllerBase
  {
    private readonly ChurrascoContext _context;
    public EventController(ChurrascoContext context)
    {
      _context = context;
    }

    [HttpPost]
    public IActionResult Create(Event evt)
    {
      _context.Add(evt);
      _context.SaveChanges();
      return Ok(evt);
    }

    [HttpGet("{id}")]
    public IActionResult ObterDetalhes(int id)
    {
      var evt = _context.Events.Find(id);

      if (evt == null)
        return NotFound();

      var totalParticipants = evt.participant;

      return Ok(totalParticipants);
    }

    [HttpGet("ObterPorNome")]
    public IActionResult ObterPorNome(string descript)
    {
      var eventos = _context.Events.Where(x => x.description.Contains(descript));
      return Ok(eventos);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Event evt)
    {
      var evtBd = _context.Events.Find(id);

      if (evtBd == null)
        return NotFound();

      evtBd.date = evt.date;
      evtBd.description = evt.description;
      evtBd.moreInformations = evt.moreInformations;
      evtBd.participant = evt.participant;

      _context.Events.Update(evtBd);
      _context.SaveChanges();

      return Ok(evtBd);
    }
  }
}