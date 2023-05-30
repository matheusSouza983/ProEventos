using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Application.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório."),
        //MinLength(3, ErrorMessage = "O campo {0} Deve ter no minimo 3 caracteres"),
        //MaxLength(50, ErrorMessage = "O campo {0} Deve ter no maximo 50 caracteres")
        StringLength(50, MinimumLength = 3, ErrorMessage = "Intervalo Permitido de 3 a 50 caracteres")]
        public string Tema { get; set; }
        [Range(1,120000, ErrorMessage = "{0} não pode ser menor que 1 e maior que 120.000"),
        Display(Name = "Qtd Pessoas")]
        public int QtdPessoas { get; set; }
        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", ErrorMessage = "não é uma imagem valida (gif, jpg, jpeg, bmp, png)")]
        public string ImagemUrl { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatorio"),
        Phone(ErrorMessage = "O campo {0} está com número invalido")]
        public string Telefone { get; set; }
        [Display(Name = "e-mail"),
        Required(ErrorMessage = "O campo {0} é obrigatório."),
        EmailAddress(ErrorMessage = "É necessario ser um {0} valido")]
        public string Email { get; set; }


        public IEnumerable<LoteDto> Lotes { get; set; }
        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }
        public IEnumerable<PalestranteDto> Palestrantes { get; set; }
    }
}