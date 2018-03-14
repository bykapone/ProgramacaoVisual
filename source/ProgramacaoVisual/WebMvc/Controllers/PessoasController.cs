using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;

namespace WebMvc.Controllers
{
    public class PessoasController : Controller
    {
        public static IList<Pessoa> pessoaList = new List<Pessoa>
        {
            new Pessoa {Id = 1, Nome = "Kapone"},
            new Pessoa {Id = 2, Nome = "Guimaraes"},
            new Pessoa {Id = 3, Nome = "Bruno"}
    };

        // localhost:5000/Pessoas
        //localhost:5000/Pessoas/Index

        public IActionResult Index()
        {
            //busca de dados
            var viewModel = new PessoaViewModel
            {

                Items = pessoaList
            };
            //transforma dados em dados de vizualização
            //vizualização dos dados
            return View(viewModel);
        }

        public IActionResult Create()
        {
               return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create([Bind("Nome")]Pessoa newPessoa)
        {
                 if (!ModelState.IsValid)
                      return View(newPessoa);

                      newPessoa.Id = pessoaList.Max(p => p.Id) + 1;
                      pessoaList.Add(newPessoa);
                      return RedirectToAction(nameof(Index));

        }


    }
}