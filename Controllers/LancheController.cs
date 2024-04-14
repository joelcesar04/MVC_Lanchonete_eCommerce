using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Permissions;

namespace LanchesMac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _repository;
        public LancheController(ILancheRepository repository)
        {
            _repository = repository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _repository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os Lanches";
            }
            else
            {
                //if (string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                //{
                //    lanches = _repository.Lanches
                //            .Where(l => l.Categoria.CategoriaNome.Equals("Normal"))
                //            .OrderBy(l => l.Nome);
                //}
                //else
                //{
                //    lanches = _repository.Lanches
                //            .Where(l => l.Categoria.CategoriaNome.Equals("Natural"))
                //            .OrderBy(l => l.Nome);
                //}

                lanches = _repository.Lanches.Where(l => l.Categoria.CategoriaNome.Equals(categoria));
                categoriaAtual = categoria;
            }

            //return View(lanches);
            var lancheListViewModel = new LancheListViewModel()
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual,
            };

            return View(lancheListViewModel);
        }

        public IActionResult Details(int lancheId)
        {
            var lanche = _repository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
            return View(lanche);
        }

        public IActionResult Search(string searchString)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                lanches = _repository.Lanches.OrderBy(l => l.Nome);
                categoriaAtual = "Todos os Lanches";
            }
            else
            {
                lanches = _repository.Lanches
                    .Where(l => l.Nome.ToLower().Contains(searchString.ToLower()));

                if (lanches.Any())
                    categoriaAtual = "Lanches";
                else
                    categoriaAtual = "Nenhum lanche foi encontrado";
            }
            return View("~/Views/Lanche/List.cshtml", new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            });
        }
    }
}
