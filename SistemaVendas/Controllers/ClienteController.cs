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
    public class ClienteController : Controller
    {
        protected ApplicationDbContext _Context;
        public ClienteController(ApplicationDbContext context)
        {
            _Context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Cliente> lista = _Context.Cliente.ToList();
            _Context.Dispose();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ClienteViewModel viewModel = new ClienteViewModel();
            if (id != null)
            {
                var entidade = _Context.Cliente.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Nome = entidade.Nome;
                viewModel.CNPJ_CPF = entidade.CNPJ_CPF;
                viewModel.Email = entidade.Email;
                viewModel.Celular = entidade.Celular;
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Cadastro(ClienteViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                Cliente objCliente = new Cliente()
                {
                  
                    Codigo = entidade.Codigo,
                    Nome = entidade.Nome,
                    CNPJ_CPF = entidade.CNPJ_CPF,
                    Email = entidade.Email,
                    Celular = entidade.Celular
                };

                if(entidade.Codigo == null)
                {
                    _Context.Cliente.Add(objCliente);
                }
                else
                {
                    _Context.Entry(objCliente).State = EntityState.Modified;
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
            var ent = new Cliente() { Codigo = id };
            _Context.Attach(ent);
            _Context.Remove(ent);
            _Context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
