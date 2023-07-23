using System;
using System.Collections.Generic;

namespace ProEventos.Domain
{
    //[Table("EventosDetalhes")] - usar para mudar o nome da tabela
    public class Evento
    {
        //[Key] - usar para definir a primarykey da tabela
        public int Id { get; set; }
        public string Local { get; set; }
        // [NotMapped] - usar para nao criar esse campo dentro da tabela
        public DateTime? DataEvento { get; set; }
        // [Required] - usar para definir como preenchimento obrigatorio
        // [MaxLength(50)] - definir o tamanho do campo
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string ImagemUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public IEnumerable<Lote> Lotes { get; set; }
        public IEnumerable<RedeSocial> RedesSociais { get; set; }
        public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }
    }
}