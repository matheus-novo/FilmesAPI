﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Dtos
{
    public class ReadEnderecoDto
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
    }
}
