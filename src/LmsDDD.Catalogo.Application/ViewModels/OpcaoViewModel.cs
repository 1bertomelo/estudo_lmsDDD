using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LmsDDD.Catalogo.Application.ViewModels
{
    public class OpcaoViewModel
    {
        [Key]
        public Guid Id { get; set; }
       
        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor mínimo de {1}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Numero { get; private set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Ativo { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Correta { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataCadastro { get; private set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid QuestaoId { get; private set; }

    }
}
