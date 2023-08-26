using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Dtos
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string nome { get; set; }
    }
}
