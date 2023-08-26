﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Dtos
{
    public class UpdateEnderecoDto
    {
        [Required(ErrorMessage = "O logradouro é obrigatório")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "O número é obrigatório")]
        public int Numero { get; set; }
    }
}