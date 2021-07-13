using Microsoft.AspNetCore.Mvc;
using SistemaVendas.DAL;
using SistemaVendas.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SistemaVendas.Controllers
{
    public class ProdutoController : Controller
    {
        protected ApplicationDbContext _Context;
        public ProdutoController(ApplicationDbContext context)
        {
            _Context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Produto> lista = _Context.Produto.Include(x => x.Categoria).ToList();
            _Context.Dispose();
            return View(lista);
        }

        private IEnumerable<SelectListItem> ListaCategoria()
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            lista.Add(new SelectListItem()
            {
                Value = string.Empty,
                Text = string.Empty
            });
            foreach (var item in _Context.Categoria.ToList())
            {
                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao.ToString()
                });
            }
            return lista;
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ProdutoViewModel viewModel = new ProdutoViewModel();
            viewModel.ListaCategorias = ListaCategoria();

            if (id != null)
            {
                var entidade = _Context.Produto.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Descricao = entidade.Descricao;
                viewModel.Quantidade = entidade.Quantidade;
                viewModel.Valor = entidade.Valor;
                viewModel.CodigoCategoria = entidade.CodigoCategoria;
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Cadastro(ProdutoViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                Produto objProduto = new Produto()
                {
                  
                    Codigo = entidade.Codigo,
                    Descricao = entidade.Descricao,
                    Quantidade = entidade.Quantidade,
                    Valor = (decimal)entidade.Valor,
                    CodigoCategoria = (int)entidade.CodigoCategoria
                };

                if(entidade.Codigo == null)
                {
                    _Context.Produto.Add(objProduto);
                }
                else
                {
                    _Context.Entry(objProduto).State = EntityState.Modified;
                }

                _Context.SaveChanges();
            }
            else
            {
                entidade.ListaCategorias = ListaCategoria();
                return View(entidade);
            }

            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var ent = new Produto() { Codigo = id };
            _Context.Attach(ent);
            _Context.Remove(ent);
            _Context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
