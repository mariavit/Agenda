using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace agenda.Controllers
{
    public class HomeController : Controller
    {
        private Contato _service;

        public HomeController()
        {
            _service = new Contato();
        }
        public ActionResult Index()
        {
            ViewBag.Contatos = _service.ConsultaContato()
                .Select(contatoDominio => new ContatoViewModel
                {

                    Codigo = contato.Codigo,
                    Nome = contato.Nome,
                    Endereco = contato.Endereco,
                    Bairro = contato.Bairro,
                    Cidade = contato.Cidade,
                    Estado = contato.Estado,
                    Telefone = contato.Telefone

                });
            ViewBag.Contatos = _service.ConsultaContato()
                .Select(contatoDominio => new ContatoViewModel
                {

                    Codigo = contato.Codigo,
                    Nome = contato.Nome,
                    Endereco = contato.Endereco,
                    Bairro = contato.Bairro,
                    Cidade = contato.Cidade,
                    Estado = contato.Estado,
                    Telefone = contato.Telefone

                });

            return View();
        }
    }
}