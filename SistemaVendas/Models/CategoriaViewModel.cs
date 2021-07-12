using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    public class CategoriaViewModel
    {
        public int? Codigo { get; set; }
        [Required(ErrorMessage ="informe a Descrição da Categoria") ]
        public string Descricao { get; set; }
    }
}
