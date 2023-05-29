using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class ContatosController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatosController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.FindAll();
            return View(contatos);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update(int id)
        {
            var contato = _contatoRepositorio.FindById(id);
            return View(contato);
        }

        public IActionResult ConfirmDelete(int id)
        {
            var contato = _contatoRepositorio.FindById(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Create(ContatoModel contato)
        {
            if (ModelState.IsValid)
            {
                _contatoRepositorio.Create(contato);
                return RedirectToAction("Index");
            }

            return View(contato);
        }

        [HttpPost]
        public IActionResult UpdateChanges(ContatoModel contato)
        {
            _contatoRepositorio.Update(contato);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _contatoRepositorio.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
