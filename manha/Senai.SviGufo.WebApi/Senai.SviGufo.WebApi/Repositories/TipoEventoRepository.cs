using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;

namespace Senai.SviGufo.WebApi.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=SENAI_SVIGUFO_MANHA_BACKEND;integrated security=true";

        /// <summary>
        /// Altera um tipo de evento
        /// </summary>
        /// <param name="tipoEvento">TipoEventoDomain</param>
        public void Alterar(TipoEventoDomain tipoEvento)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "UPDATE TIPOS_EVENTOS SET TITULO = @TITULO WHERE ID = @ID";

                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@TITULO", tipoEvento.Nome);
                cmd.Parameters.AddWithValue("@ID", tipoEvento.Id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Cadastra um novo tipo de evento
        /// </summary>
        /// <param name="tipoEvento">TipoEventoDomain</param>
        public void Cadastrar(TipoEventoDomain tipoEvento)
        {
            //Declara a conexão passando sua string de conexão
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                // string QuerySerExecutada = "INSERT INTO TIPOS_EVENTOS(TITULO) VALUES ('" + tipoEvento.Nome + "')";
                //Declara a query passando o valor como parametro
                string QueryASerExecutada = "INSERT INTO TIPOS_EVENTOS (TITULO) VALUES (@TITULO)";
                //Declara o command passando a query e a conexão
                SqlCommand cmd = new SqlCommand(QueryASerExecutada, con);
                //Passa o valor do parametro
                cmd.Parameters.AddWithValue("@TITULO", tipoEvento.Nome);
                //abre a conexão
                con.Open();
                //Executa o comando
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Lista os tipos de eventos
        /// </summary>
        /// <returns>List<TipoEventoDomain></returns>
        public List<TipoEventoDomain> Listar()
        {
            List<TipoEventoDomain> tiposEventos = new List<TipoEventoDomain>();

            //Declaro a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrução a ser executada
                string QueryaSerExecutada = "SELECT ID, TITULO FROM TIPOS_EVENTOS";

                //Abre o banco de dados
                con.Open();

                //Declaro um SqlDataReader para percorrer a lista
                SqlDataReader rdr;

                //Declaro um command passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(QueryaSerExecutada, con))
                {
                    //Executa a query
                    rdr = cmd.ExecuteReader();

                    //Percorre os dados 
                    while (rdr.Read())
                    {
                        TipoEventoDomain tipoEvento = new TipoEventoDomain
                        {
                            Id = Convert.ToInt32(rdr["ID"]),
                            Nome = rdr["TITULO"].ToString()
                        };

                        tiposEventos.Add(tipoEvento);
                    }
                }
            }

            return tiposEventos;
        }

        /// <summary>
        /// Deleta um Tipo Evento pelo seu ID
        /// </summary>
        /// <param name="id">Id do tipo de evento</param>
        public void Deletar(int id)
        {
            //Declara a conexão com o banco de dados
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                //Query de deleção
                string Query = "DELETE FROM TIPOS_EVENTOS WHERE ID = @ID";
                //Cria objeto command passando a query e a conexão
                SqlCommand cmd = new SqlCommand(Query, con);
                //Da um replace no parametro da Query
                cmd.Parameters.AddWithValue("@ID", id);
                //Abre o banco
                con.Open();
                //Executa o command
                cmd.ExecuteNonQuery();
            }
        }

    }
}
