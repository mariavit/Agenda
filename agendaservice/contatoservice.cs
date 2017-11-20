using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace agendaservice
{
    public class contatoservice
    {

        Contato _repositorio = new Contato();

        public List<Contato> ConsultaContatos()
        {
            return _repositorio.ConsultarContatos();
        }

        public int InserirContato(Contato contato)
        {
            return _repositorio.InserirContato(contato);
        }

        public void AlterarContato(Contato contato)
        {
            _repositorio.AlterarContato(contato);
        }

        public void ApagarContato(int codigoContato)
        {
            _repositorio.ApagarContato(codigoContato);
        }

        public object ConsultaContato()
        {
            throw new NotImplementedException();
        }
    }
}