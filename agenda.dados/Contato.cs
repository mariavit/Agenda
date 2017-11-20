using MySql.Data.MySqlClient;

namespace agenda.dados
{
    public class Contato
    {
        public List<Contato> ConsultarContatos()
        {
            List<Contato> retornoConsulta = new List<Contato>();

            string comandoSQL = "SELECT * FROM Contato;";

            MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=AgedaContatos;Uid=root;Pwd=;");
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            conexao.Open();

            MySqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                retornoConsulta.Add(new Contato
                {
                    Codigo = Convert.ToInt32(dr["Codigo"]),
                    Nome = dr["Nome"].ToString(),
                    Endereco = dr["Endereco"].ToString(),
                    Bairro = dr["Bairro"].ToString(),
                    Cidade = dr["Cidade"].ToString(),
                    Estado = dr["Estado"].ToString(),
                    Telefone = Convert.ToInt32(dr["Telefone"])
                });
            }

            return retornoConsulta;
        }

        public int InserirContato(Contato contato)
        {
            int codigoGerado = 0;

            string comandoSQL = "Insert into Contato (Nome, Endereco, Bairro, Cidade, Estado, Telefone, CodigoTipoContato) values (@Nome, @Endereco, @Bairro, " +
                "@Cidade, @Estado, @Telefone, @CodigoTipoContato);";

            MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=AgendeContatos;Uid=root;Pwd=;");
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            comando.Parameters.AddWithValue("@Nome", contato.Nome);
            comando.Parameters.AddWithValue("@Endereco", contato.Endereco);
            comando.Parameters.AddWithValue("@Bairro", contato.Bairro);
            comando.Parameters.AddWithValue("@Cidade", contato.Cidade);
            comando.Parameters.AddWithValue("@Estado", contato.Estado);
            comando.Parameters.AddWithValue("@Telefone", contato.Telefone);
            comando.Parameters.AddWithValue("@CodigoTipoContato", contato.TipoContato.Codigo);

            conexao.Open();

            comando.ExecuteNonQuery();

            comando = new MySqlCommand("SELECT MAX(Codigo) from Contato", conexao);

            MySqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                codigoGerado = Convert.ToInt32(dr[0]);
            }

            conexao.Close();

            return codigoGerado;
        }

        public void AlterarContato(Contatocontato)
        {
            string comandoSQL = "Update Contato set Nome=@Nome, Endereco=@Endereco, Bairro=@Bairro, Cidade=@Cidade, Estado=@Estado, " +
                "Telefone=@Telefone, CodigoTipoContato=@CodigoTipoContato where Codigo=@Codigo;";

            MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=AgendaContatos;Uid=root;Pwd=;");
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            comando.Parameters.AddWithValue("@Codigo", contato.Codigo);
            comando.Parameters.AddWithValue("@Nome", contato.Nome);
            comando.Parameters.AddWithValue("@Endereco", contato.Endereco);
            comando.Parameters.AddWithValue("@Bairro", contato.Bairro);
            comando.Parameters.AddWithValue("@Cidade", contato.Cidade);
            comando.Parameters.AddWithValue("@Estado", contato.Estado);
            comando.Parameters.AddWithValue("@Telefone", contato.Telefone);
            comando.Parameters.AddWithValue("@CodigoTipoContato", contato.Categoria.Codigo);

            conexao.Open();

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public void ApagarContato(int codigoContato)
        {
            string comandoSQL = "Delete from Contato where Codigo=@Codigo;";

            MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=AgendaContatos;Uid=root;Pwd=;");
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            comando.Parameters.AddWithValue("@Codigo", codigoContato);

            conexao.Open();

            comando.ExecuteNonQuery();

            conexao.Close();
        }
    }
}