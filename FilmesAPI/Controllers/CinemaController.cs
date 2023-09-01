using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private IMapper _mapper;
        private FilmeContext _context;

        public CinemaController(IMapper mapper, FilmeContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionarCinema([FromBody]CreateCinemaDto cinemaDto)
        {
            var cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction (nameof(LerCinemaPorID), new { id = cinema.Id }, cinemaDto);
        }

        [HttpGet]
        public IEnumerable<ReadCinemaDto> LerCinemas([FromQuery]int skip = 0, [FromQuery]int take = 10, [FromQuery]int? enderecoId = null)
        {
            if (enderecoId == null)
            {
                var listaCinemas = _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.Skip(skip).Take(take).ToList());
                return listaCinemas;
            }
            return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.FromSqlRaw($"SELECT Id, nome, EnderecoId FROM cinemas WHERE EnderecoId = {enderecoId}").ToList());

        }

        [HttpGet("{id}")]

        public IActionResult LerCinemaPorID(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null) return NotFound();
            var cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
            return Ok(cinemaDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCinema (int id,[FromBody] UpdateCinemaDto cinemaDto)
        {
            var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null) return NotFound();
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null) return NotFound();
            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
