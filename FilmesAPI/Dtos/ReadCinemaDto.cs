using FilmesAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Dtos
{
    public class ReadCinemaDto
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public ReadEnderecoDto EnderecoDto { get; set; }
        public ICollection<ReadSessaoDto> Sessoes { get; set; }
    }
}
