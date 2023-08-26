using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Sessao
    {
        public int? CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }
        public int? FilmeId { get; set; }
        public virtual Filme Filme { get; set; }
    }
}
