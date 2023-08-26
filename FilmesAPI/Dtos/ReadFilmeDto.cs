using FilmesAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Dtos
{
    public class ReadFilmeDto
    {
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
        public ICollection<ReadSessaoDto> Sessoes { get; set; }
        public DateTime horaConsulta { get; set; } = DateTime.Now;
    }
}
