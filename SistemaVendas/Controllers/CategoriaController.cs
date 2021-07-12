using Microsoft.AspNetCore.Mvc;
using SistemaVendas.DAL;
using SistemaVendas.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVendas.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaVendas.Controllers
{
    public class CategoriaController : Controller
    {
        protected ApplicationDbContext _Context;
        public CategoriaController(ApplicationDbContext context)
        {
            _Context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Categoria> lista = _Context.Categoria.ToList();
            _Context.Dispose();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            CategoriaViewModel viewModel = new CategoriaViewModel();
            if (id != null)
            {
                var entidade = _Context.Categoria.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Descricao = entidade.Descricao;
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Cadastro(CategoriaViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                Categoria objCategoria = new Categoria()
                {
                  
                    Codigo = entidade.Codigo,
                    Descricao = entidade.Descricao
                };

                if(entidade.Codigo == null)
                {
                    _Context.Categoria.Add(objCategoria);
                }
                else
                {
                    _Context.Entry(objCategoria).State = EntityState.Modified;
                }

                _Context.SaveChanges();
            }
            else
            {
                return View(entidade);
            }

            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var ent = new Categoria() { Codigo = id };
            _Context.Attach(ent);
            _Context.Remove(ent);
            _Context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
