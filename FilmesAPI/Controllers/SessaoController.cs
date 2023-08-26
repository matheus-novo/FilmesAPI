using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private IMapper _mapper;
        private FilmeContext _context;

        public SessaoController(IMapper mapper, FilmeContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            var sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(LerSessaoPorID), new { FilmeId = sessao.FilmeId, CinemaId = sessao.CinemaId }, sessaoDto);
        }

        [HttpGet]
        public IEnumerable<ReadSessaoDto> LerSessoes([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            return _mapper.Map<List<ReadSessaoDto>>(_context.Sessoes.Skip(skip).Take(take).ToList());
        }

        [HttpGet("{filmeId}/{cinemaId}")]

        public IActionResult LerSessaoPorID(int filmeId, int cinemaId)
        {
            var sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.FilmeId == filmeId && sessao.CinemaId == cinemaId);
            if (sessao == null) return NotFound();
            var sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);
            return Ok(sessaoDto);
        }

        
        [HttpDelete("{filmeId}/{cinemaId}")]
        public IActionResult DeletarSessao(int filmeId, int cinemaId)
        {
            var sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.FilmeId == filmeId && sessao.CinemaId == cinemaId);
            if (sessao == null) return NotFound();
            _context.Sessoes.Remove(sessao);
            _context.SaveChanges();
            return NoContent();
        }
        
    }
}
