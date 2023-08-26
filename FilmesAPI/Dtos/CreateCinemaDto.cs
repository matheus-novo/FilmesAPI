using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Dtos
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string nome { get; set; }
        public int EnderecoId { get; set; }
    }
}
