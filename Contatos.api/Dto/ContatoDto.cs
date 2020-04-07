using System.ComponentModel.DataAnnotations;

namespace Contatos.api.Dto
{
    public class ContatoDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage="Defina um canal de Contato, podendo ser email, celular ou fixo.")]
        public string Canal { get; set; }
        [Required(ErrorMessage="Defina um valor para o contato.")]
        public string Valor { get; set; }
        public string Observacao { get; set; }
    }
}