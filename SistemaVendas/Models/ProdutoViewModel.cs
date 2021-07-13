using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    public class ProdutoViewModel
    {
        public int? Codigo { get; set; }

        [Required(ErrorMessage ="informe") ]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "informe ")]
        public double Quantidade { get; set; }

        [Required(ErrorMessage = "informe")]
        [Range(0.1, double.PositiveInfinity)]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "informe")]
        public int? CodigoCategoria { get; set; }
        public IEnumerable<SelectListItem> ListaCategorias { get; set; }

    }
}
