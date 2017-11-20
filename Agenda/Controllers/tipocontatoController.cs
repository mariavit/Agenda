using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace agenda.Controllers
{
    public class tipocontatoController : Controller
    {
        // GET: TipoContato
        public ActionResult Index()
        {
            return View();
        }
        public RedirectToRouteResult Excluir(int id)
        {
            _service.ApagarTipoContato(id);

            return RedirectToAction("Index");
        }
        public ActionResult Detalhes(int id)
        {
            Dominio.TipoContato tipocontato = _service.ConsultaTipoContato(id);

            TipoContatoViewModel tipocontatoViewModel = new TipoContatoViewModel
            {

                Codigo = tipocontato.Codigo,
                Descricao = tipocontato.Descricao,


            };

            return View(tipocontatoViewModel);
        }
        public ActionResult Alterar(int id)
        {
            Dominio.TipoContato tipocontato = _service.ConsultaTipoContato(id);

            TipoContatoViewModel tipocontatoViewModel = new TipoContatoViewModel
            {
                Codigo = tipocontato.Codigo,
                Descricao = tipocontato.Descricao,

            };

            return View(tipocontatoViewModel);
        }

        public RedirectToRouteResult Salvar(TipoContatoViewModel tipocontato)
        {
            var tipocontatoDominio = new Dominio.TipoContato
            {

                Codigo = tipocontato.Codigo,
                Descricao = tipocontato.Descricao,

            };

            if (tipocontato.Codigo == 0)
            {
                int codigoGerado = _service.InserirTipoContato(tipocontato);
            }
            else
            {
                _service.AlterarTipoContato(tipocontato);
            }


            return RedirectToAction("Index");
        }
    }
}