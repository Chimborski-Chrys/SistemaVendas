using Microsoft.AspNetCore.Mvc;
using SistemaVendas.DAL;
using SistemaVendas.Entity;
using SistemaVendas.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Controllers
{
    public class HomeController : Controller
    {
        protected ApplicationDbContext _Context;
        public HomeController(ApplicationDbContext context)
        {
            _Context = context;
        }
        public IActionResult Index()
        {
            /*Categoria categoria = new Categoria()
            {
                Descricao = "teste"
            };
            _Context.Categoria.Add(categoria);
            _Context.SaveChanges();
            Categoria objCategoria = _Context.Categoria.Where(x => x.Codigo == 2).FirstOrDefault();
            objCategoria.Descricao = "Bebidas";
            _Context.Entry(objCategoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _Context.SaveChanges();*/

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
