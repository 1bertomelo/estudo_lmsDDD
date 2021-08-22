using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LmsDDD.Catalogo.Application.ViewModels
{
    public class CursoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid CategoriaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Imagem { get; set; }

        public Guid? AvaliacaoId { get; private set; }


        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor mínimo de {1}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Hora { get; set; }

        [Range(1, 59, ErrorMessage = "O campo {0} precisa ter o valor mínimo de {1} e máximo de {2}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Minuto { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} precisa ter o valor mínimo de {1} e máximo de {2}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int CursoStatus { get; set; }
        
        public IEnumerable<CategoriaViewModel> Categorias { get; set; }
    }
}
