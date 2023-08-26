using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Dtos
{
    public class UpdateFilmeDto
    {
        [Required(ErrorMessage = "O título não pode ser vazio")]
        [StringLength(100, ErrorMessage = "O titulo deve ter, no máximo, 100 caracteres")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "A sinopse não pode ser vazia")]
        [StringLength(300, ErrorMessage = "A sinopse deve ter, no máximo, 300 caracteres")]
        public string Sinopse { get; set; }
        [Required(ErrorMessage = "O genero não pode ser vazio")]
        [StringLength(50, ErrorMessage = "O genero deve ter, no máximo, 50 caracteres")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "A duração não pode ser vazia")]
        [Range(70, 600, ErrorMessage = "A duração deve estar entre 70 e 600")]
        public int Duracao { get; set; }
    }
}
