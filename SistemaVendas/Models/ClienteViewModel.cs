using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    public class ClienteViewModel
    {
        public int? Codigo { get; set; }

        [Required(ErrorMessage ="informe o nome do Cliente") ]
        public string Nome { get; set; }

        [Required(ErrorMessage = "informe o CNPJ/CPF do Cliente")]
        public string CNPJ_CPF { get; set; }

        [Required(ErrorMessage = "informe o Email do Cliente")]
        public string Email { get; set; }

        [Required(ErrorMessage = "informe o Celular do Cliente")]
        public string Celular { get; set; }
    }
}
