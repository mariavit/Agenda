using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace agendaservice
{
    public class tipocontatoservice
    {
        TipoContato _repositorio = new TipoContato();

        public List<TipoContato> ConsultaTipoContato()
        {
            return _repositorio.ConsultaTipoContato();
        }

        public object ConsultaTipoContato()
        {
            throw new NotImplementedException();
        }

        public int InserirTipoContato(TipoContato tipocontato)
        {
            return _repositorio.InserirTipoContatotipocontato);
        }

        public void AlterarTipoContato(TipoContato tipocontato)
        {
            _repositorio.AlterarTipoContato(tipocontato);
        }

        public void ApagarTipoContato(int codigoTipoContato)
        {
            _repositorio.ApagarTipoContato(codigoTipoContato);
        }
    }
}