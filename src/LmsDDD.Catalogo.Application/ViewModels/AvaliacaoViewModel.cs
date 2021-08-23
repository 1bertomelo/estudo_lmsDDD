using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LmsDDD.Catalogo.Application.ViewModels
{
    public class AvaliacaoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get;  set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Ativo { get;  set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataCadastro { get;  set; }

        [Range(0, 100, ErrorMessage = "O campo {0} precisa ter o valor mínimo de {1}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal ValorTotal { get;  set; }
        public IEnumerable<QuestaoViewmodel> Questoes { get; set; }
    }
}
