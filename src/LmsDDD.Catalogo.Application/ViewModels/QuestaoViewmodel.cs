using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LmsDDD.Catalogo.Application.ViewModels
{
    public class QuestaoViewmodel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Numero { get;  set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Enunciado { get;  set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Ativo { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid AvaliacaoId { get;  set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataCadastro { get;  set; }
        public IEnumerable<OpcaoViewModel> Opcoes { get; set; }
    }
}
