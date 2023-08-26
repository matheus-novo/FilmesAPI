using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private IMapper _mapper;
        private FilmeContext _context;

        public EnderecoController(IMapper mapper, FilmeContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(LerEnderecoPorID), new { id = endereco.Id }, enderecoDto);
        }

        [HttpGet]
        public IEnumerable<ReadEnderecoDto> LerEnderecos([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            return _mapper.Map<IEnumerable<ReadEnderecoDto>>(_context.Enderecos.Skip(skip).Take(take));
        }

        [HttpGet("{id}")]

        public IActionResult LerEnderecoPorID(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null) return NotFound();
            var enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
            return Ok(enderecoDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null) return NotFound();
            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEndereco(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null) return NotFound();
            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
