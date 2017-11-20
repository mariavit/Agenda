using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace agenda.dados
{
    public class tipocontatorepositorio
    {
        public List<TipoContato> ConsultaTipoContato()
        {
            List<TipoContato> retornoConsulta = new List<TipoContato>();

            string comandoSQL = "SELECT * FROM TipoContato;";

            MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=AgendaContatos;Uid=root;Pwd=;"); //Ponte
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            conexao.Open();

            MySqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                retornoConsulta.Add(new TipoContato
                {
                    Codigo = Convert.ToInt32(dr["Codigo"]),
                    Descricao = dr["Descricao"].ToString()
                });
            }

            return retornoConsulta;
        }



        public int InserirTipoContato(TipoContato tipocontato)
        {
            int codigoGerado = 0;

            string comandoSQL = "Insert into TipoContato(Nome,  Descricao) values (@Nome,  @Descricao);";

            MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=AgendaContatos;Uid=root;Pwd=;");
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            comando.Parameters.AddWithValue("@Nome", tipocontato.Nome);
            comando.Parameters.AddWithValue("@Descricao", tipocontato.Descricao);

            conexao.Open();

            comando.ExecuteNonQuery();

            comando = new MySqlCommand("SELECT MAX(Codigo) from TipoContato", conexao);

            MySqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                codigoGerado = Convert.ToInt32(dr[0]);
            }

            return codigoGerado;
        }

        public void AlterarTipoContato(TipoContato tipocontato)
        {
            string comandoSQL = "Update TipoContato set Nome=@Nome,  Descricao=@Descricao where Codigo=@Codigo;";

            MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=AgendaContatos;Uid=root;Pwd=;");
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            comando.Parameters.AddWithValue("@Codigo", tipocontato.Codigo);
            comando.Parameters.AddWithValue("@Descricao", tipocontato.Descricao);

            conexao.Open();

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public void ApagarTipoContato(int codigoTipoContato)
        {
            string comandoSQL = "Delete from TipoContato where Codigo=@Codigo;";

            MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=AgendaContatos;Uid=root;Pwd=;");
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            comando.Parameters.AddWithValue("@Codigo", codigoTipoContato);

            conexao.Open();

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public TipoContato ConsultaTipoContato(Int32 codigo)
        {
            TipoContato retornoConsulta = new TipoContato();

            string comandoSQL = "SELECT * FROM TipoContato where Codigo=@Codigo;";

            MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=AgendaContatos;Uid=root;Pwd=;"); //Ponte
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            comando.Parameters.AddWithValue("@Codigo", codigo);

            conexao.Open();

            MySqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                retornoConsulta = new TipoContato
                {
                    Codigo = Convert.ToInt32(dr["Codigo"]),
                    Nome = dr["Nome"].ToString()
                };
            }

            return retornoConsulta;
        }
    }
}